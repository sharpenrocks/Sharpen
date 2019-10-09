using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Sharpen.Engine.Facts
{
    internal static class SyntaxNodeFacts
    {
        public static bool AreEquivalent(SyntaxNode firstNode, SyntaxNode secondNode)
            => SyntaxFactory.AreEquivalent(firstNode, secondNode);
    }
}
