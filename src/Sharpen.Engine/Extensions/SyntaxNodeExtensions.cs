using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.Extensions
{
    internal static class SyntaxNodeExtensions
    {
        public static bool IsAnyOfKinds(this SyntaxNode syntaxNode, SyntaxKind firstKind, SyntaxKind secondKind)
        {
            return syntaxNode.IsKind(firstKind) || syntaxNode.IsKind(secondKind);
        }

        public static bool IsAnyOfKinds(this SyntaxNode syntaxNode, SyntaxKind firstKind, SyntaxKind secondKind, SyntaxKind thirdKind)
        {
            return syntaxNode.IsKind(firstKind) || syntaxNode.IsKind(secondKind) || syntaxNode.IsKind(thirdKind);
        }

        public static bool IsAnyOfKinds(this SyntaxNode syntaxNode, SyntaxKind firstKind, SyntaxKind secondKind, SyntaxKind thirdKind, SyntaxKind fourthKind)
        {
            return syntaxNode.IsKind(firstKind) || syntaxNode.IsKind(secondKind) || syntaxNode.IsKind(thirdKind) || syntaxNode.IsKind(fourthKind);
        }

        public static bool IsWithinLambdaOrAnonymousMethod(this SyntaxNode syntaxNode)
        {
            return syntaxNode.FirstAncestorOrSelf<AnonymousFunctionExpressionSyntax>() != null;
        }

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

        public static TNode FirstAncestorOrSelfWithinEnclosingNode<TNode>(this SyntaxNode syntaxNode, SyntaxNode enclosingNode, bool includeEnclosingNode = true) where TNode: SyntaxNode
        {
            // TODO-IG: We should assert here that the syntaxNode is really within the enclosingNode.
            //          Define in general how to do asserting.

            SyntaxNode currentNode = syntaxNode;
            while (currentNode != enclosingNode)
            {
                if (currentNode is TNode) return (TNode) currentNode;
                currentNode = currentNode.Parent;
            }

            if (includeEnclosingNode && enclosingNode is TNode) return (TNode)enclosingNode;

            return null;
        }

        public static SyntaxNode PrecedingSiblingOrSelf(this SyntaxNode syntaxNode)
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

        /// <summary>
        /// Returns true if the  <paramref name="syntaxNode"/> yields.
        ///
        /// We say that a syntax node yields if it contains yield statements
        /// that causes its first yieldable parent or self (e.g. method, local function,
        /// property, etc.) to yield.
        /// </summary>
        public static bool Yields(this SyntaxNode syntaxNode)
        {
            return syntaxNode.DescendantNodes()
                .OfType<YieldStatementSyntax>()
                .Any(yieldStatement => 
                    IsNotWithinLambdaOrAnonymousMethodDifferentThanSyntaxNode(yieldStatement)
                    &&
                    IsNotWithinLocalFunctionDifferentThanSyntaxNode(yieldStatement)
                );

            bool IsNotWithinLambdaOrAnonymousMethodDifferentThanSyntaxNode(YieldStatementSyntax yieldStatement)
            {
                // Check if there is an anonymous function between the yield statement
                // and the syntax node that is different than the syntax node itself.
                var enclosingAnonymousFunction = yieldStatement.FirstAncestorOrSelfWithinEnclosingNode<AnonymousFunctionExpressionSyntax>(syntaxNode, false);
                return enclosingAnonymousFunction == null;
            }

            bool IsNotWithinLocalFunctionDifferentThanSyntaxNode(YieldStatementSyntax yieldStatement)
            {
                // Check if there is a local function between the yield statement
                // and the syntax node that is different than the syntax node itself.
                var localFunction = yieldStatement.FirstAncestorOrSelfWithinEnclosingNode<LocalFunctionStatementSyntax>(syntaxNode, false);
                return localFunction == null;
            }
        }

        // TODO-IG: Use these methods on the places where we now use nodes.Where(node => node.IsKind(...) ...).

        // We have several methods here instead of using "params SyntaxKind syntaxKinds" in
        // order to avoid the hidden allocation of a SyntaxKind array.
        public static IEnumerable<SyntaxNode> OfKind(this IEnumerable<SyntaxNode> syntaxNodes, SyntaxKind kind)
        {
            return syntaxNodes.Where(syntaxNode => syntaxNode.IsKind(kind));
        }

        public static IEnumerable<SyntaxNode> OfAnyOfKinds(this IEnumerable<SyntaxNode> syntaxNodes, SyntaxKind firstKind, SyntaxKind secondKind)
        {
            return syntaxNodes.Where(syntaxNode => syntaxNode.IsKind(firstKind) ||
                                                   syntaxNode.IsKind(secondKind));
        }

        public static IEnumerable<SyntaxNode> OfAnyOfKinds(this IEnumerable<SyntaxNode> syntaxNodes, SyntaxKind firstKind, SyntaxKind secondKind, SyntaxKind thirdKind)
        {
            return syntaxNodes.Where(syntaxNode => syntaxNode.IsKind(firstKind) ||
                                                   syntaxNode.IsKind(secondKind) ||
                                                   syntaxNode.IsKind(thirdKind));
        }

        public static IEnumerable<SyntaxNode> OfAnyOfKinds(this IEnumerable<SyntaxNode> syntaxNodes, SyntaxKind firstKind, SyntaxKind secondKind, SyntaxKind thirdKind, SyntaxKind fourthKind)
        {
            return syntaxNodes.Where(syntaxNode => syntaxNode.IsKind(firstKind) ||
                                                   syntaxNode.IsKind(secondKind) ||
                                                   syntaxNode.IsKind(thirdKind) ||
                                                   syntaxNode.IsKind(fourthKind));
        }

        public static IEnumerable<SyntaxNode> OfAnyOfKinds(this IEnumerable<SyntaxNode> syntaxNodes, SyntaxKind firstKind, SyntaxKind secondKind, SyntaxKind thirdKind, SyntaxKind fourthKind, SyntaxKind fifthKind)
        {
            return syntaxNodes.Where(syntaxNode => syntaxNode.IsKind(firstKind) ||
                                                   syntaxNode.IsKind(secondKind) ||
                                                   syntaxNode.IsKind(thirdKind) ||
                                                   syntaxNode.IsKind(fourthKind) ||
                                                   syntaxNode.IsKind(fifthKind));
        }

        public static IEnumerable<SyntaxNode> OfAnyOfKinds(this IEnumerable<SyntaxNode> syntaxNodes, SyntaxKind firstKind, SyntaxKind secondKind, SyntaxKind thirdKind, SyntaxKind fourthKind, SyntaxKind fifthKind, SyntaxKind sixthKind)
        {
            return syntaxNodes.Where(syntaxNode => syntaxNode.IsKind(firstKind) ||
                                                   syntaxNode.IsKind(secondKind) ||
                                                   syntaxNode.IsKind(thirdKind) ||
                                                   syntaxNode.IsKind(fourthKind) ||
                                                   syntaxNode.IsKind(fifthKind) ||
                                                   syntaxNode.IsKind(sixthKind));
        }

        public static IEnumerable<SyntaxNode> OfAnyOfKinds(this IEnumerable<SyntaxNode> syntaxNodes, SyntaxKind firstKind, SyntaxKind secondKind, SyntaxKind thirdKind, SyntaxKind fourthKind, SyntaxKind fifthKind, SyntaxKind sixthKind, SyntaxKind seventhKind)
        {
            return syntaxNodes.Where(syntaxNode => syntaxNode.IsKind(firstKind) ||
                                                   syntaxNode.IsKind(secondKind) ||
                                                   syntaxNode.IsKind(thirdKind) ||
                                                   syntaxNode.IsKind(fourthKind) ||
                                                   syntaxNode.IsKind(fifthKind) ||
                                                   syntaxNode.IsKind(sixthKind) ||
                                                   syntaxNode.IsKind(seventhKind));
        }
    }
}