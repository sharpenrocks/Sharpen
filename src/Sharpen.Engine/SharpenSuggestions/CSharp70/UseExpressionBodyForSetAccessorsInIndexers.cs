using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70
{
    internal sealed class UseExpressionBodyForSetAccessorsInIndexers : BaseUseExpressionBodyForSetAccessors<IndexerDeclarationSyntax>
    {
        private UseExpressionBodyForSetAccessorsInIndexers() { }

        public override string FriendlyName { get; } = "Use expression body for set accessors in indexers";

        public static readonly UseExpressionBodyForSetAccessorsInIndexers Instance = new UseExpressionBodyForSetAccessorsInIndexers();
    }
}