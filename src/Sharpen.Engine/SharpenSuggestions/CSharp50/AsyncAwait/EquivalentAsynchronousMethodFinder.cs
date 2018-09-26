using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Extensions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    /// <remarks>
    /// We can have different finders. Hardcoded one, one based on dependencies etc.
    /// That's why this base class and the encapsulation of the logic. 
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
            new KnownAwaitableTypeInfo("Task", "System.Threading.Tasks")
            // TODO-SETTINGS: Allow users to define their own known awaitable types.
            // TODO: Later on we can check for arbitrary types that implement the GetAwaiter() method.
        };

        private const string AsyncSuffix = "Async";

        /// <summary>
        /// Returns true if an equivalent asynchronous method of the method used in
        /// the <paramref name="invocation"/> exists or false if such method does not
        /// exist.
        /// </summary>
        public bool EquivalentAsynchronousMethodExistsFor(InvocationExpressionSyntax invocation, SemanticModel semanticModel)
        {
            if (invocation.Expression == null) return false;

            if (!InvokedMethodPotentiallyHasAsynchronousEquivalent(invocation)) return false;

            if (!(semanticModel.GetSymbolInfo(invocation).Symbol is IMethodSymbol method)) return false;

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