using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Extensions;

namespace Sharpen.Engine.SharpenSuggestions.Common.AsyncAwaitAndAsyncStreams
{
    // TODO-IG: Refactor this. The class heavily violates the single responsibility principle.
    //          It does two heavy things at the moment, searches for the equivalent async methods,
    //          but also checks the "environment" to see if it fits requirements of just a one
    //          specific client. Bad.

    /// <remarks>
    /// We can have different finders. Hardcoded one, one based on dependencies etc.
    /// This base class encapsulates the common and exact search logic.
    /// The derived classes are responsible for the heuristic part of the search.
    /// </remarks>
    internal abstract class EquivalentAsynchronousMethodFinder
    {
        public enum CallerAsyncStatus
        {
            CallerMustBeAsync,
            CallerMustNotBeAsync
        }

        public enum CallerYieldingStatus
        {
            Irrelevant,
            CallerMustYield,
            CallerMustNotYield
        }

        private class KnownAwaitableTypeInfo : KnownTypeInfo
        {            
            public enum ReturnTypeWrappingKind
            {
                /// <summary>
                /// Denotes that the known awaitable type in its generic
                /// form takes the original return type as its generic
                /// type parameter.
                /// E.g. if the original method returns int its async
                /// equivalent can return Task&lt;int&gt;. Thus, Task
                /// wraps the return type of the original method.
                /// </summary>
                WrapsReturnType,
                /// <summary>
                /// Denotes that the known awaitable type in its generic
                /// form takes the type parameter of the original generic return type
                /// as its generic type parameter.
                /// E.g. if the original method returns IEnumerable&lt;int&gt; its async
                /// equivalent can return IAsyncEnumerable&lt;int&gt;. Thus, IAsyncEnumerable
                /// wraps the type parameter of the return type of the original method.
                /// </summary>
                WrapsReturnTypeTypeParameter
            }

            private readonly ReturnTypeWrappingKind wrappingKind;

            /// <summary>
            /// True if the type in its non-generic form is expected to
            /// be return if the original non-async method was returning void.
            /// </summary>
            public bool IsVoidEquivalent { get; }

            public KnownAwaitableTypeInfo(string typeName, string typeNamespace, ReturnTypeWrappingKind wrappingKind, bool isVoidEquivalent)
                :base(typeName, typeNamespace)
            {
                this.wrappingKind = wrappingKind;
                IsVoidEquivalent = isVoidEquivalent;
            }

            public bool WrapsReturnType() => wrappingKind == ReturnTypeWrappingKind.WrapsReturnType;
        }

        private static readonly KnownAwaitableTypeInfo[] KnownAwaitableTypes =
        {
            new KnownAwaitableTypeInfo("Task", "System.Threading.Tasks", KnownAwaitableTypeInfo.ReturnTypeWrappingKind.WrapsReturnType, true),
            new KnownAwaitableTypeInfo("ValueTask", "System.Threading.Tasks", KnownAwaitableTypeInfo.ReturnTypeWrappingKind.WrapsReturnType, true),
            new KnownAwaitableTypeInfo("IAsyncEnumerable", "System.Collections.Generic", KnownAwaitableTypeInfo.ReturnTypeWrappingKind.WrapsReturnTypeTypeParameter, true)
            // TODO-SETTINGS: Allow users to define their own known awaitable types.
            // TODO: Later on we can check for arbitrary types that implement the GetAwaiter() method.
        };

        // This is a bit of misuse of the KnownTypeInfo, I would say. Hmmm.
        // But it's practical and fits into the scheme.
        // TODO-IG: Remove the ugly part that all the methods on a type are ignored
        //          if the MethodName is null. At the moment, this is not needed at
        //          all. And if it is once needed, introduce a proper abstraction
        //          for that case.
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
            // Why do we ignore Add() and AddRange()? See here:
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1.addasync?view=efcore-2.1
            // "This method is async only to allow special value generators [...]. For all other cases the non async method should be used."
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
        /// For example, the suggestion to await asynchronous equivalent
        /// makes sense only if the enclosing method
        /// within which the invocation happens can be turned into async method.
        /// For example, if the enclosing method is an interface implementation or an override
        /// method of an interface or base class that cannot be changed, than it cannot be
        /// turned into async method and thus the suggestion makes no sense.
        /// </remarks>
        public bool EquivalentAsynchronousCandidateExistsFor(InvocationExpressionSyntax invocation, SemanticModel semanticModel, CallerAsyncStatus callerAsyncStatus, CallerYieldingStatus callerYieldingStatus)
        {
            if (invocation.Expression == null) return false;

            if (!InvokedMethodPotentiallyHasAsynchronousEquivalent(invocation)) return false;

            if (!(semanticModel.GetSymbolInfo(invocation).Symbol is IMethodSymbol method)) return false;

            if (KnownMethodsToIgnore.Any(methodToIgnore => methodToIgnore.RepresentsMethod(method))) return false;

            // So far we do not suggest turning lambdas and anonymous methods
            // into async. So we will at the moment just ignore that case.
            // TODO: Support suggestion for lambdas and anonymous methods.
            if (invocation.IsWithinLambdaOrAnonymousMethod()) return false;

            // If type authors invoke the synchronous method
            // within the implementation of its containing type
            // we assume that they exactly know what they are doing.
            // They for sure want to call exactly that method on
            // that particular place in code. We are 100% sure that
            // they do not want to call its async equivalent.
            if (MethodIsInvokedWithinItsContainingType()) return false;

            // The suggestions make sense only if the whole calling chain
            // already is or can be made async by utilizing the async keyword.
            if (!MethodIsInvokedWithinACallerNodeThatCanBeMarkedAsAsync()) return false;

            // Caller is either a method or a local function.
            var (callerSymbol, callerSyntaxNode) = GetEnclosingLocalFunctionOrMethod();
            if (callerSymbol == null) return false;

            if (callerAsyncStatus == CallerAsyncStatus.CallerMustNotBeAsync)
            {
                if (callerSymbol.IsAsync) return false;

                if (!CallerCanBeMadeAsync()) return false;
            }
            else // Caller must be async.
            {
                if (!callerSymbol.IsAsync) return false;
            }

            if (callerYieldingStatus != CallerYieldingStatus.Irrelevant)
            {
                bool callerYields = callerSyntaxNode.Yields();
                if (callerYields && callerYieldingStatus != CallerYieldingStatus.CallerMustYield) return false;
                if (!callerYields && callerYieldingStatus != CallerYieldingStatus.CallerMustNotYield) return false;
            }

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
            // on which the synchronous method is called (if there are such).

            // Let's check the method containing type first.
            if (TypeContainsAsynchronousEquivalentOf(semanticModel, method.ContainingType, method, invocation)) return true;

            // Let's now check the type on which the method is called,
            // if there is such.
            var calledOnType = GetCalledOnType();
            if (calledOnType == null || Equals(calledOnType, method.ContainingType)) return false;

            if (TypeContainsAsynchronousEquivalentOf(semanticModel, calledOnType, method, invocation)) return true;

            return false;

            bool MethodIsInvokedWithinACallerNodeThatCanBeMarkedAsAsync()
            {
                // We do not want to have suggestions on methods with async
                // equivalents that are called in constructors, properties,
                // destructors, etc. because those, with a good reason!,
                // cannot be made async in C#. The suggestion makes sense
                // only if the whole calling chain already is or can be made
                // async.

                // The only two C# elements that can be made async are methods
                // and local functions. Local functions can be nested in e.g.
                // properties. In that case there is no sense of making them
                // async.
                // Thus, ultimately, we have to see if the invocation is done
                // within a method.

                // A MethodDeclarationSyntax cannot be nested within an
                // another MethodDeclarationSyntax. Therefore we can just search
                // for the first parent of type MethodDeclarationSyntax.
                return invocation.FirstAncestorOrSelf<MethodDeclarationSyntax>() != null;

                // (Afterthought. We could have a situation that someone has an async
                // local function within a property and within the function calls a
                // method that has an async equivalent. We will simply ignore this.
                // Having async local functions in properties, constructors, etc. makes
                // zero sense.)
            }

            (IMethodSymbol, SyntaxNode) GetEnclosingLocalFunctionOrMethod()
            {
                // Of course, first we have to check if the invocation happens within a local function.
                // The declaration symbol of a local function implements IMethodSymbol so the cast is safe.
                var enclosingLocalFunction = invocation.FirstAncestorOrSelf<LocalFunctionStatementSyntax>();
                if (enclosingLocalFunction != null)
                    return ((IMethodSymbol)semanticModel.GetDeclaredSymbol(enclosingLocalFunction), enclosingLocalFunction);

                var enclosingMethod = invocation.FirstAncestorOrSelf<MethodDeclarationSyntax>();
                return enclosingMethod == null
                    ? (null, null)
                    : (semanticModel.GetDeclaredSymbol(enclosingMethod), enclosingMethod);
            }

            bool CallerCanBeMadeAsync()
            {
                // In this method we are only checking if adding the "async" keyword
                // and changing the return type to e.g. Task<Something> will not break
                // existing outer contracts posed on the method, e.g. if the method
                // is an interface implementation we cannot change its return type.

                // We do not check if its internal implementation can suppress us from
                // making it async. E.g. if it yields and we are in C# less then 8.0
                // (no async streams). Other checks in this class are responsible
                // for covering those constraints.

                // If we have an enclosing local function, it can neither override base methods
                // nor implement interfaces. So it has no restrictions of that kind.
                // And for the moment, we will assume that there is no an equivalent asynchronous
                // local function in the same scope. I can imagine a case where such and equivalent
                // could exist, but this is corner case. If it ever happens, let's have a false
                // positive and hopefully an issue filled :-)

                // Long story short, if we have a local function then yes, it can always be made async.
                if (callerSymbol.MethodKind == MethodKind.LocalFunction)
                    return true;

                return CallerMethodDoesNotOverrideNonChangeableBaseClassMethod() &&
                       CallerMethodDoesNotImplementNonChangeableInterfaceMethod() &&
                       CallerMethodDoesNotAlreadyHaveAsynchronousEquivalent();

                bool CallerMethodDoesNotOverrideNonChangeableBaseClassMethod()
                {
                    if (!callerSymbol.IsOverride) return true;

                    return callerSymbol.OverriddenMethod?
                            .ContainingType?
                            .Locations.All(location => location.IsInSource) == true;
                }

                bool CallerMethodDoesNotImplementNonChangeableInterfaceMethod()
                {
                    // If the enclosing method implements an interface method
                    // we have to see if that interface can be changed.
                    // Since it could implement more then one interface, we have
                    // to check of all of them can be changed.
                    // (Changed means made async.)
                    // If they cannot, means if they are referenced from an assembly
                    // and not defined in code, we assume that the enclosing
                    // method implements a non-changeable interface method.
                    return callerSymbol.GetImplementedInterfaceMethods(semanticModel)
                        .All(interfaceMethod => interfaceMethod
                            .ContainingType?.Locations.All(location => location.IsInSource) == true);
                }

                bool CallerMethodDoesNotAlreadyHaveAsynchronousEquivalent()
                {
                    return !TypeContainsAsynchronousEquivalentOf(semanticModel, callerSymbol.ContainingType, callerSymbol);
                }
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
        }
       
        protected abstract bool InvokedMethodPotentiallyHasAsynchronousEquivalent(InvocationExpressionSyntax invocation);

        private static bool TypeContainsAsynchronousEquivalentOf(SemanticModel semanticModel, INamedTypeSymbol type, IMethodSymbol method, InvocationExpressionSyntax invocation = null)
        {
            if (type == null) return false;
            if (method == null) return false;

            var asynchronousEquivalentMethodName = method.Name + AsyncSuffix;

            // If the invocation is not defined, we are not searching for eventual
            // extension methods, but only on the methods on the type.
            // In that case we have to directly look at the members on the
            // type by using the GetMembers() method.
            // Why? Because if the type is declared in two or more partials
            // the LookupSymbol() without position provided (0) will not
            // return the symbols declared in other partials.
            var potentialAsynchronousEquivalents =
                (invocation == null
                    ? type
                        .GetMembers(asynchronousEquivalentMethodName)
                    : semanticModel
                        .LookupSymbols(invocation.Expression?.SpanStart ?? 0, type, asynchronousEquivalentMethodName,
                            true)
                )
                .OfType<IMethodSymbol>()
                .ToArray();

            return potentialAsynchronousEquivalents.Any(IsAsynchronousEquivalent);

            bool IsAsynchronousEquivalent(IMethodSymbol potentialEquivalent)
            {
                // We insist that the async method returns an awaitable object.
                if (potentialEquivalent.ReturnsVoid) return false;

                if (potentialEquivalent.ReturnType == null) return false;

                // If the method returns void its async equivalent must return
                // any of the known awaitable types that can be void equivalents.
                if (method.ReturnsVoid)
                {
                    if (!KnownAwaitableTypes.Any(awaitableType =>
                            awaitableType.IsVoidEquivalent
                            &&
                            awaitableType.RepresentsType(potentialEquivalent.ReturnType)))
                        return false;
                }
                else // The method does not return void.
                {
                    if (method.ReturnType == null) return false;

                    // If the method returns non-void its async equivalent must
                    // either return generic awaitable type parametrized exactly with the
                    // method return type or a generic awaitable type parametrized exactly with the
                    // type of the generic type parameter of the method return type.

                    if (!(potentialEquivalent.ReturnType is INamedTypeSymbol potentialEquivalentReturnType))
                        return false;

                    if (potentialEquivalentReturnType.Arity != 1)
                        return false;

                    // Ok, the potential equivalent returns a generic type with exactly
                    // one parameter. First we have to see if this generic return type
                    // is one of the known awaitable types.
                    var returnedKnownAwaitableType = KnownAwaitableTypes.FirstOrDefault(awaitableType => awaitableType.RepresentsType(potentialEquivalentReturnType.ConstructedFrom));
                    if (returnedKnownAwaitableType == null) return false;

                    // And now we have to check if that generic returned awaitable type is
                    // parameterized with the proper type.
                    if (returnedKnownAwaitableType.WrapsReturnType())
                    {
                        if (!method.ReturnType.Equals(potentialEquivalentReturnType.TypeArguments[0]))
                            return false;
                    }
                    else // The returned awaitable type wraps the type parameter of the original generic returned type.
                    {
                        // The method must return generic type with exactly one type parameter.
                        if (!(method.ReturnType is INamedTypeSymbol methodReturnType && methodReturnType.Arity == 1))
                            return false;

                        if (!methodReturnType.TypeArguments[0].Equals(potentialEquivalentReturnType.TypeArguments[0]))
                            return false;
                    }
                }

                // Async equivalent must have exactly the same method parameters
                // (type and name) with only a single exception - an additional
                // CancellationToken can be there as the last argument.
                // TODO: Add support for the IProgress additional argument.
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
}