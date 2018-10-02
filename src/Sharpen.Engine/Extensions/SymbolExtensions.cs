using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.Extensions
{
    internal static class SymbolExtensions
    {
        /// <summary>
        /// Returns true if the method represented by <paramref name="methodSymbol"/>
        /// is either implicit or explicit implementation of any interface method.
        /// </summary>
        public static bool ImplementsInterfaceMethod(this IMethodSymbol methodSymbol)
        {
            if (methodSymbol == null)
                return false;

            if (methodSymbol.MethodKind == MethodKind.ExplicitInterfaceImplementation)
                return true;

            var methodContainingType = methodSymbol.ContainingType;
            if (methodContainingType == null)
                return false;

            return methodContainingType
                .AllInterfaces
                // Beware of the fact that for explicit interface implementations
                // the methodSymbol.Name is not the same as interface name ;-)
                // Therefore, this filtering works only because at the top of the method
                // we have already checked for the explicit interface implementation.
                .SelectMany(@interface => @interface.GetMembers(methodSymbol.Name).OfType<IMethodSymbol>())
                .Any(interfaceMethod => methodContainingType.FindImplementationForInterfaceMember(interfaceMethod)?.Equals(methodSymbol) == true);
        }

        public static IEnumerable<IMethodSymbol> GetImplementedInterfaceMethods(this IMethodSymbol methodSymbol, SemanticModel semanticModel)
        {
            if (methodSymbol == null)
                return Enumerable.Empty<IMethodSymbol>();

            var methodContainingType = methodSymbol.ContainingType;
            if (methodContainingType == null)
                return methodSymbol.ExplicitInterfaceImplementations;

            var implicitInterfaceImplementations = methodContainingType
                .AllInterfaces
                // Beware of the fact that for explicit interface implementations
                // the methodSymbol.Name is not the same as interface name ;-)
                // Therefore, this will filter out only the implicit implementations
                // and at the end we will add the explicit interface implementations.
                .SelectMany(@interface => @interface.GetMembers(methodSymbol.Name).OfType<IMethodSymbol>())
                .Where(interfaceMethod => methodContainingType.FindImplementationForInterfaceMember(interfaceMethod)?.Equals(methodSymbol) == true);

            return implicitInterfaceImplementations.Concat(methodSymbol.ExplicitInterfaceImplementations);
        }
    }
}