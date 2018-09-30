using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Extensions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    /// <remarks>
    /// We can have different finders. Hardcoded one, one based on dependencies etc.
    /// This base class encapsulates the common and exact search logic.
    /// The derived classes are responsible for the heuristic part of the search.
    /// </remarks>
    internal abstract class EquivalentAsynchronousMethodFinder
    {
        private class KnownAwaitableTypeInfo : KnownTypeInfo
        {
            public KnownAwaitableTypeInfo(string typeName, string typeNamespace)
                :base(typeName, typeNamespace) { }
        }

        private static readonly KnownAwaitableTypeInfo[] KnownAwaitableTypes =
        {
            new KnownAwaitableTypeInfo("Task", "System.Threading.Tasks"),
            new KnownAwaitableTypeInfo("ValueTask", "System.Threading.Tasks")
            // TODO-SETTINGS: Allow users to define their own known awaitable types.
            // TODO: Later on we can check for arbitrary types that implement the GetAwaiter() method.
        };

        // This is a bit of misuse of the KnownTypeInfo, I would say. Hmmm.
        // But it's practical and fits into the scheme.
        private class MethodToIgnore : KnownTypeInfo
        {
            /// <summary>
            /// Name of the method whose asynchronous equivalent exists,
            /// but should be ignored. If null, all the methods on the type
            /// should be ignored.
            /// </summary>
            private string MethodName { get; }

            public MethodToIgnore(string typeName, string typeNamespace, string methodName = null)
                : base(typeName, typeNamespace)
            {
                MethodName = methodName;
            }

            public bool RepresentsMethod(IMethodSymbol method)
            {
                return RepresentsType(method.ContainingType) &&
                       (MethodName == null || MethodName == method.Name);
            }
        }

        private static readonly MethodToIgnore[] KnownMethodsToIgnore = 
        {
            new MethodToIgnore("DbSet", "Microsoft.EntityFrameworkCore", "Add"),
            new MethodToIgnore("DbSet", "Microsoft.EntityFrameworkCore", "AddRange")
            // TODO-SETTINGS: Allow users to define their own known methods to ignore.
        };

        private const string AsyncSuffix = "Async";

        /// <summary>
        /// Returns true if an equivalent asynchronous method of the method used in
        /// the <paramref name="invocation"/> exists and is at the same time a
        /// potential candidate to be used exactly in that particular <paramref name="invocation"/>.
        /// </summary>
        /// <remarks>
        /// This method does not only check if an equivalent asynchronous method
        /// exists. In addition, it runs additional checks to see if it make sense
        /// to call such existing asynchronous equivalent in the particular <paramref name="invocation"/>.
        /// For example, the suggestion makes sense only if the enclosing method
        /// within which the invocation happens can be turned into async method.
        /// If the enclosing method is an interface implementation or an override
        /// method it cannot be turned into async method and thus the suggestion
        /// makes no sense.
        /// </remarks>
        public bool EquivalentAsynchronousCandidateExistsFor(InvocationExpressionSyntax invocation, SemanticModel semanticModel)
        {
            if (invocation.Expression == null) return false;

            if (!InvokedMethodPotentiallyHasAsynchronousEquivalent(invocation)) return false;

            if (!(semanticModel.GetSymbolInfo(invocation).Symbol is IMethodSymbol method)) return false;

            if (KnownMethodsToIgnore.Any(methodToIgnore => methodToIgnore.RepresentsMethod(method))) return false;

            // So far we do not suggest turning lambdas and anonymous methods
            // into async. So we will at the moment just ignore that case.
            // TODO: Support suggestion for lambdas and anonymous methods.
            if (MethodIsInvokedWithinLambdaOrAnonymousMethod()) return false;

            // If type authors invoke the synchronous method
            // within the implementation of its containing type
            // we assume that they exactly know what they are doing.
            // They for sure want to call exactly that method on
            // that particular place in code. We are 100% sure that
            // they do not want to call its async equivalent.
            if (MethodIsInvokedWithinItsContainingType()) return false;

            // TODO: Check if the enclosing method in which the invocation
            //       happens can be turned into async method.
            //       - It must not be an override.
            //       - It must not be an interface implementation.
            //       For example see: NHibernate.Test\NHSpecificTest\NH1789\DomainObject.cs

            // We can have the following situations:
            // 1. someObject.SomeInstanceMethod()
            // 2. someObject.SomeExtensionMethod()
            // 3. SomeType.SomeStaticMethod()
            // 4. <build in type keyword>.SomeStaticMethod()
            // 5. SomeInstanceMethod();
            // 6. SomeStaticMethod();
            // 7. this.SomeInstanceMethod();
            // A potential asynchronous equivalent can be defined on
            // the same type on which the synchronous method is defined.
            // But if the synchronous method is itself an extension method,
            // the asynchronous equivalent could be defined on the type
            // of the object on which the method is called.
            // And other way around, if the synchronous method is an instance
            // method, the asynchronous equivalent could be an extension method
            // on an arbitrary type that extends the type of the instance ;-)
            // Long story short, the search for the asynchronous equivalent
            // has to check both the containing type of the synchronous method
            // and all the possible methods that can be called on the instance
            // on which the synchronous method is called (if there is such).

            var asynchronousEquivalentMethodName = method.Name + AsyncSuffix;

            // Let's check the method containing type first.
            if (TypeContainsAsynchronousEquivalent(method.ContainingType)) return true;

            // Let's now check the type on which the method is called,
            // if there is such.
            var calledOnType = GetCalledOnType();
            if (calledOnType == null || calledOnType == method.ContainingType) return false;

            if (TypeContainsAsynchronousEquivalent(calledOnType)) return true;

            return false;

            bool MethodIsInvokedWithinLambdaOrAnonymousMethod()
            {
                return invocation.FirstAncestorOrSelf<AnonymousFunctionExpressionSyntax>() != null;
            }

            bool MethodIsInvokedWithinItsContainingType()
            {
                var invokedInType = invocation.FirstAncestorOrSelf<TypeDeclarationSyntax>();

                // This should never happen. It means we have some issue in the
                // syntax tree. If that's the case, just cancel any further analysis
                // by stating that the method is called withing its containing type.
                if (invokedInType == null) return true;

                if (method.ContainingType?.Equals(semanticModel.GetDeclaredSymbol(invokedInType)) == true)
                    return true;

                return false;
            }

            INamedTypeSymbol GetCalledOnType()
            {
                if (!(invocation.Expression is MemberAccessExpressionSyntax memberAccess)) return null;
                if (memberAccess.Expression == null) return null;

                return semanticModel.GetTypeInfo(memberAccess.Expression).Type as INamedTypeSymbol;
            }

            bool TypeContainsAsynchronousEquivalent(INamedTypeSymbol type)
            {
                if (type == null) return false;

                // We can have overloaded methods ;-)
                // And we have to look for extension methods as well ;-)
                var potentialAsynchronousEquivalents = semanticModel
                        .LookupSymbols(invocation.Expression.Span.Start, type, asynchronousEquivalentMethodName, true)
                        .OfType<IMethodSymbol>()
                        .ToArray();

                return potentialAsynchronousEquivalents.Any(IsAsynchronousEquivalent);

                bool IsAsynchronousEquivalent(IMethodSymbol potentialEquivalent)
                {
                    // We insist that the async method returns an awaitable object.
                    if (potentialEquivalent.ReturnsVoid) return false;

                    if (potentialEquivalent.ReturnType == null) return false;

                    // If the method returns void its async equivalent must return
                    // any of the known awaitable types.
                    if (method.ReturnsVoid)
                    {
                        if (!KnownAwaitableTypes.Any(awaitableType => awaitableType.RepresentsType(potentialEquivalent.ReturnType)))
                            return false;
                    }
                    else
                    {
                        if (method.ReturnType == null) return false;

                        // If the method returns non-void its async equivalent must
                        // return generic awaitable type parametrized exactly with the
                        // method return type.

                        if (!(potentialEquivalent.ReturnType is INamedTypeSymbol potentialEquivalentReturnType))
                            return false;

                        if (potentialEquivalentReturnType.Arity != 1)
                            return false;

                        if (!KnownAwaitableTypes.Any(awaitableType => awaitableType.RepresentsType(potentialEquivalentReturnType.ConstructedFrom)))
                            return false;

                        if (!method.ReturnType.Equals(potentialEquivalentReturnType.TypeArguments[0]))
                            return false;
                    }

                    // Async equivalent must have exactly the same method parameters
                    // (type and name) with only a single exception - an additional
                    // CancellationToken can be there as the last argument.
                    int numberOfParameters = method.Parameters.Length;
                    if (!(potentialEquivalent.Parameters.Length == numberOfParameters ||
                          potentialEquivalent.Parameters.Length == numberOfParameters + 1))
                        return false;

                    for (int i = 0; i < numberOfParameters; i++)
                    {
                        if (method.Parameters[i].Type == null)
                            return false;
                        if (!method.Parameters[i].Type.Equals(potentialEquivalent.Parameters[i].Type))
                            return false;
                        if (method.Parameters[i].Name != potentialEquivalent.Parameters[i].Name)
                            return false;
                    }

                    if (potentialEquivalent.Parameters.Length == numberOfParameters + 1)
                    {
                        if (!potentialEquivalent.Parameters[numberOfParameters].Type
                            .FullNameIsEqualTo("System.Threading", "CancellationToken"))
                            return false;
                    }

                    return true;
                }
            }
        }
       
        protected abstract bool InvokedMethodPotentiallyHasAsynchronousEquivalent(InvocationExpressionSyntax invocation);
    }
}