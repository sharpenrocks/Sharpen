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
                case SyntaxKind.LocalFunctionStatement: return For((LocalFunctionStatementSyntax)syntaxNode);
                case SyntaxKind.UsingStatement: return For((UsingStatementSyntax)syntaxNode);
                case SyntaxKind.SwitchStatement: return For((SwitchStatementSyntax)syntaxNode);
                case SyntaxKind.ReturnStatement:
                case SyntaxKind.Parameter:
                case SyntaxKind.Argument:
                case SyntaxKind.InvocationExpression:
                case SyntaxKind.ObjectCreationExpression:
                case SyntaxKind.SimpleMemberAccessExpression:
                case SyntaxKind.EqualsValueClause: return syntaxNode.ToString();
                default: return syntaxNode.ToString();
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

        private static string For(UsingStatementSyntax usingStatement)
        {
            usingStatement = usingStatement.WithoutLeadingTrivia();
            return $"{usingStatement.UsingKeyword.ToFullString()}{usingStatement.OpenParenToken.ToFullString()}{usingStatement.Declaration.ToFullString()}{usingStatement.CloseParenToken.ToString()}";
        }

        private static string For(SwitchStatementSyntax switchStatement)
        {
            switchStatement = switchStatement.WithoutLeadingTrivia();
            return $"{switchStatement.SwitchKeyword.ToFullString()}{switchStatement.OpenParenToken.ToFullString()}{switchStatement.Expression.ToFullString()}{switchStatement.CloseParenToken.ToString()}";
        }
    }
}