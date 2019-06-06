using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.Extensions
{
    internal static class MethodDeclarationSyntaxExtensions
    {
        public static bool IsAsync(this MethodDeclarationSyntax method)
        {
            return method?.Modifiers.Any(syntaxToken => syntaxToken.IsKind(SyntaxKind.AsyncKeyword)) == true;
        }

        public static bool IsAsync(this LocalFunctionStatementSyntax method)
        {
            return method?.Modifiers.Any(syntaxToken => syntaxToken.IsKind(SyntaxKind.AsyncKeyword)) == true;
        }

        public static bool IsAsync(this SyntaxNode methodOrLocalFunction)
        {
            switch (methodOrLocalFunction)
            {
                case MethodDeclarationSyntax method:
                    return method.Modifiers.Any(syntaxToken => syntaxToken.IsKind(SyntaxKind.AsyncKeyword));
                case LocalFunctionStatementSyntax localFunction:
                    return localFunction.Modifiers.Any(syntaxToken => syntaxToken.IsKind(SyntaxKind.AsyncKeyword));
                default: return false;
            }
        }
    }
}