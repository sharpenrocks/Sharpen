using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Extensions
{
    internal static class SyntaxNodeExtensions
    {
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