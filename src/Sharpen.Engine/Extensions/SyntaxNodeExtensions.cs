using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.Extensions
{
    internal static class SyntaxNodeExtensions
    {
        // Returning lists... mutable to be worse... I don't like it. Still, in this case, the best tradeoff
        // until we introduce some good both semantically correct and performant collection handling.
        public static List<string> GetParameterNamesVisibleInScope(this SyntaxNode syntaxNode)
        {
            var result = new List<string>();

            CollectParameterNames();

            return result;

            void CollectParameterNames()
            {
                var currentSyntaxNode = syntaxNode;
                while (currentSyntaxNode != null)
                {
                    // Some of the nodes cannot be nested e.g. methods or constructors.
                    // If the current node is any of these nodes, after adding its parameters
                    // we can set it to null and avoid unnecessary traversal up the parents line.
                    // Otherwise, in the case of nested nodes e.g. local functions, we continue
                    // traversing up.
                    switch (currentSyntaxNode)
                    {
                        // Methods and constructors.
                        case BaseMethodDeclarationSyntax baseMethod:
                            result.AddRange(baseMethod.ParameterList.Parameters.Select(parameter => parameter.Identifier.ValueText));
                            currentSyntaxNode = null;
                            break;

                        // Property setters, event adders, and event removers.
                        case AccessorDeclarationSyntax accessor when !accessor.Keyword.IsKind(SyntaxKind.GetKeyword):
                            result.Add("value");
                            // Accessors are not nested so normally we would return null and stop the traversing.
                            // But if an accessor is within an indexer (that means indexer's setter), we have to
                            // reach to the indexer declaration to collect the indexer parameters that are also
                            // visible within its setter.
                            currentSyntaxNode = accessor.FirstAncestorOrSelf<IndexerDeclarationSyntax>() != null
                                                    ? currentSyntaxNode.Parent
                                                    : null;
                            break;

                        // Indexers.
                        case IndexerDeclarationSyntax indexer:
                            result.AddRange(indexer.ParameterList.Parameters.Select(parameter => parameter.Identifier.ValueText));
                            currentSyntaxNode = null;
                            break;

                        case SimpleLambdaExpressionSyntax simpleLambda:
                            result.Add(simpleLambda.Parameter.Identifier.ValueText);
                            currentSyntaxNode = currentSyntaxNode.Parent;
                            break;

                        case ParenthesizedLambdaExpressionSyntax parenthesizedLambda:
                            result.AddRange(parenthesizedLambda.ParameterList.Parameters.Select(parameter => parameter.Identifier.ValueText));
                            currentSyntaxNode = currentSyntaxNode.Parent;
                            break;

                        // Anonymous delegates.
                        case AnonymousMethodExpressionSyntax anonymousMethod:
                            result.AddRange(anonymousMethod.ParameterList.Parameters.Select(parameter => parameter.Identifier.ValueText));
                            currentSyntaxNode = currentSyntaxNode.Parent;
                            break;

                        case LocalFunctionStatementSyntax localFunction:
                            result.AddRange(localFunction.ParameterList.Parameters.Select(parameter => parameter.Identifier.ValueText));
                            currentSyntaxNode = currentSyntaxNode.Parent;
                            break;

                        default:
                            currentSyntaxNode = currentSyntaxNode.Parent;
                            break;
                    }                    
                }
            }
        }

        public static bool IsAnyAncestorOfOrSelf<T>(this IEnumerable<T> syntaxNodes, SyntaxNode potentialDescendantNodeOrSelf, SyntaxNode searchUpToNode = null) where T : SyntaxNode
        {
            return syntaxNodes.Any(node => node.IsAncestorOfOrSelf(potentialDescendantNodeOrSelf, searchUpToNode));
        }

        public static bool IsAncestorOfOrSelf(this SyntaxNode syntaxNode, SyntaxNode potentialDescendantNodeOrSelf, SyntaxNode searchUpToNode = null)
        {
            if (syntaxNode == potentialDescendantNodeOrSelf) return true;

            SyntaxNode currentNode = potentialDescendantNodeOrSelf.Parent;
            while (currentNode != searchUpToNode)
            {
                if (currentNode == syntaxNode) return true;
                currentNode = currentNode.Parent;
            }

            return false;
        }

        public static TNode LastAncestorOrSelf<TNode>(this SyntaxNode syntaxNode) where TNode : SyntaxNode
        {
            TNode result = null;
            SyntaxNode currentNode = syntaxNode;
            while(currentNode != null)
            {
                if (currentNode is TNode node) result = node;
                currentNode = currentNode.Parent;
            }

            return result;
        }

        public static SyntaxNode PrecedingSyblingOrSelf(this SyntaxNode syntaxNode)
        {
            if (syntaxNode.Parent == null) return syntaxNode;

            SyntaxNode previous = syntaxNode;
            foreach (var node in syntaxNode.Parent.ChildNodes())
            {
                if (node == syntaxNode) return previous;
                previous = node;
            }

            // This will never happen since the syntaxNode is in the list of its parent child nodes.
            // Still, we have to satisfy the compiler.
            return syntaxNode;
        }
    }
}