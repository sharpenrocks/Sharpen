#if DEBUG
using System;
#endif
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine
{
    internal static class DisplayText
    {
        public static string For(SyntaxNode syntaxNode)
        {
            switch (syntaxNode.Kind())
            {
                case SyntaxKind.DestructorDeclaration: return For((DestructorDeclarationSyntax)syntaxNode);
                case SyntaxKind.ConstructorDeclaration: return For((ConstructorDeclarationSyntax)syntaxNode);
                case SyntaxKind.PropertyDeclaration: return For((PropertyDeclarationSyntax)syntaxNode);
                case SyntaxKind.IndexerDeclaration: return For((IndexerDeclarationSyntax)syntaxNode);
                case SyntaxKind.ReturnStatement: return syntaxNode.ToString();
                case SyntaxKind.Parameter: return syntaxNode.ToString();
                case SyntaxKind.Argument: return syntaxNode.ToString();
                case SyntaxKind.InvocationExpression: return syntaxNode.ToString();
                case SyntaxKind.LocalFunctionStatement: return For((LocalFunctionStatementSyntax)syntaxNode);
                case SyntaxKind.ObjectCreationExpression: return syntaxNode.ToString();
                case SyntaxKind.SimpleMemberAccessExpression: return syntaxNode.ToString();
                // In general, we want to have a proper customized representation for each
                // of the known nodes. Still, since sometimes we do display arbitrary nodes
                // we will need the fallback to generic display in the release build.
                // During debugging, let it crash so that we can extend the list with additional
                // known cases, even if we will choose that they have a generic display.
                #if DEBUG
                default:
                    throw new ArgumentOutOfRangeException
                    (
                        nameof(syntaxNode),
                        $"Getting the display text for the syntax node of type {syntaxNode.GetType().Name} is currently not supported."
                    );
                #else
                default: return syntaxNode.ToString();
                #endif
            }
        }

        private static string For(DestructorDeclarationSyntax destructor)
        {
            destructor = destructor.WithoutLeadingTrivia();
            return $"{destructor.Modifiers.ToFullString()}{destructor.TildeToken.ToFullString()}{destructor.Identifier.ToFullString()}{destructor.ParameterList}";
        }

        private static string For(ConstructorDeclarationSyntax constructor)
        {
            constructor = constructor.WithoutLeadingTrivia();
            return $"{constructor.Modifiers.ToFullString()}{constructor.Identifier.ToFullString()}{constructor.ParameterList}";
        }

        private static string For(PropertyDeclarationSyntax property)
        {
            property = property.WithoutLeadingTrivia();
            return $"{property.Modifiers.ToFullString()}{property.Type.ToFullString()}{property.Identifier}";
        }

        private static string For(IndexerDeclarationSyntax indexer)
        {
            indexer = indexer.WithoutLeadingTrivia();
            return $"{indexer.Modifiers.ToFullString()}{indexer.Type.ToFullString()}{indexer.ThisKeyword.ToFullString()}{indexer.ParameterList}";
        }

        private static string For(LocalFunctionStatementSyntax localFunction)
        {
            localFunction = localFunction.WithoutLeadingTrivia();
            return $"{localFunction.Modifiers.ToFullString()}{localFunction.Identifier.ToFullString()}{localFunction.ParameterList}";
        }
    }
}