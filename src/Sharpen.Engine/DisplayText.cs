#if DEBUG
using System;
#endif
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
                case ParameterSyntax parameter: return For(parameter);
                case ArgumentSyntax argument: return For(argument);
                case InvocationExpressionSyntax invocation: return For(invocation);
                case LocalFunctionStatementSyntax localFunction: return For(localFunction);
                case ObjectCreationExpressionSyntax objectCreation: return For(objectCreation);
                case MemberAccessExpressionSyntax memberAccess: return For(memberAccess);
                // In general, we want to have a nice customized representation for each
                // of the known nodes. Still, since sometimes we do display arbitrary nodes
                // we will need the fallback to SyntaxNode in the release build.
                // During debugging, let it crash so that we can extend the list with additional
                // known cases.
                #if DEBUG
                default:
                    throw new ArgumentOutOfRangeException
                    (
                        nameof(syntaxNode),
                        $"Getting the display text for the syntax node of type {syntaxNode.GetType().Name} is currently not supported."
                    );
                #else
                default: return FallbackFor(syntaxNode);
                #endif
            }
        }

        #if !DEBUG
        private static string FallbackFor(SyntaxNode syntaxNode)
        {
            return syntaxNode.ToString();
        }
        #endif

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

        private static string For(ParameterSyntax parameter)
        {
            parameter = parameter.WithoutLeadingTrivia();
            return $"{parameter.ToFullString()}".Trim();
        }

        private static string For(ArgumentSyntax argument)
        {
            argument = argument.WithoutLeadingTrivia();
            return $"{argument.ToFullString()}".Trim();
        }

        private static string For(InvocationExpressionSyntax invocation)
        {
            invocation = invocation.WithoutLeadingTrivia();
            return $"{invocation.ToFullString()}".Trim();
        }

        private static string For(LocalFunctionStatementSyntax localFunction)
        {
            localFunction = localFunction.WithoutLeadingTrivia();
            return $"{localFunction.Modifiers.ToFullString()}{localFunction.Identifier.ToFullString()}{localFunction.ParameterList.ToFullString()}".Trim();
        }

        private static string For(ObjectCreationExpressionSyntax objectCreation)
        {
            objectCreation = objectCreation.WithoutLeadingTrivia();
            return $"{objectCreation.ToFullString()}".Trim();
        }

        private static string For(MemberAccessExpressionSyntax memberAccess)
        {
            memberAccess = memberAccess.WithoutLeadingTrivia();
            return $"{memberAccess.ToFullString()}".Trim();
        }
    }
}