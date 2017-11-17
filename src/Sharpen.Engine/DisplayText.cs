using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine
{
    internal static class DisplayText
    {
        public static string For(DestructorDeclarationSyntax destructor)
        {
            destructor = destructor.WithoutLeadingTrivia();
            return $"{destructor.Modifiers.ToFullString()}{destructor.TildeToken.ToFullString()}{destructor.Identifier}()".Trim();
        }

        public static string For(ConstructorDeclarationSyntax constructor)
        {
            constructor = constructor.WithoutLeadingTrivia();
            return $"{constructor.Modifiers.ToFullString()}{constructor.Identifier.ToFullString()}{constructor.ParameterList.ToFullString()}".Trim();
        }

        public static string For(PropertyDeclarationSyntax property)
        {
            property = property.WithoutLeadingTrivia();
            return $"{property.Modifiers.ToFullString()}{property.Type.ToFullString()}{property.Identifier.ToFullString()}".Trim();
        }
    }
}