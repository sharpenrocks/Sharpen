using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Sharpen.Engine.Extensions
{
    internal static class SyntaxTokenExtensions
    {
        public static bool IsAnyOfKinds(this SyntaxToken syntaxToken, SyntaxKind firstKind, SyntaxKind secondKind)
        {
            return syntaxToken.IsKind(firstKind) || syntaxToken.IsKind(secondKind);
        }

        public static bool IsAnyOfKinds(this SyntaxToken syntaxToken, SyntaxKind firstKind, SyntaxKind secondKind, SyntaxKind thirdKind)
        {
            return syntaxToken.IsKind(firstKind) || syntaxToken.IsKind(secondKind) || syntaxToken.IsKind(thirdKind);
        }
    }
}
