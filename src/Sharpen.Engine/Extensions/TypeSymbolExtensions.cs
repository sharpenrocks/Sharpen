using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Extensions
{
    internal static class TypeSymbolExtensions
    {
        public static bool IsUnconstrainedTypeParameter(this ITypeSymbol typeSymbol)
        {
            return typeSymbol.TypeKind == TypeKind.TypeParameter &&
                   // For unconstrained type parameters both IsValueType
                   // and IsReferenceType are false.
                   typeSymbol.IsValueType == false &&
                   typeSymbol.IsReferenceType == false;
        }
    }
}
