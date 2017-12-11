using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine
{
    internal static class DisplayText
    {
        public static string For(SyntaxNode syntaxNode)
        {
            switch (syntaxNode)
            {
                case DestructorDeclarationSyntax destructor: return For(destructor);
                case ConstructorDeclarationSyntax constructor: return For(constructor);
                case PropertyDeclarationSyntax property: return For(property);
                case IndexerDeclarationSyntax indexer: return For(indexer);
                case ReturnStatementSyntax @return: return For(@return);
                default:
                    throw new ArgumentOutOfRangeException
                    (
                        nameof(syntaxNode),
                        $"Getting the display text for the syntax node of type {syntaxNode.GetType().Name} is currently not supported."
                    );
            }
        }

        private static string For(DestructorDeclarationSyntax destructor)
        {
            destructor = destructor.WithoutLeadingTrivia();
            return $"{destructor.Modifiers.ToFullString()}{destructor.TildeToken.ToFullString()}{destructor.Identifier.ToFullString()}{destructor.ParameterList.ToFullString()}".Trim();
        }

        private static string For(ConstructorDeclarationSyntax constructor)
        {
            constructor = constructor.WithoutLeadingTrivia();
            return $"{constructor.Modifiers.ToFullString()}{constructor.Identifier.ToFullString()}{constructor.ParameterList.ToFullString()}".Trim();
        }

        private static string For(PropertyDeclarationSyntax property)
        {
            property = property.WithoutLeadingTrivia();
            return $"{property.Modifiers.ToFullString()}{property.Type.ToFullString()}{property.Identifier.ToFullString()}".Trim();
        }

        private static string For(IndexerDeclarationSyntax indexer)
        {
            indexer = indexer.WithoutLeadingTrivia();
            return $"{indexer.Modifiers.ToFullString()}{indexer.Type.ToFullString()}{indexer.ThisKeyword.ToFullString()}{indexer.ParameterList.ToFullString()}".Trim();
        }

        private static string For(ReturnStatementSyntax @return)
        {
            @return = @return.WithoutLeadingTrivia();
            return $"{@return.ToFullString()}".Trim();
        }
    }
}