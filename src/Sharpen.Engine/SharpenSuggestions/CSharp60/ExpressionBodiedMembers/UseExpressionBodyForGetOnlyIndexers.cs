using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp60.ExpressionBodiedMembers
{
    internal sealed class UseExpressionBodyForGetOnlyIndexers : BaseUseExpressionBodyForGetOnlyMembers<IndexerDeclarationSyntax>
    {
        private UseExpressionBodyForGetOnlyIndexers() { }

        public override string FriendlyName { get; } = "Use expression body for get-only indexers";

        public static readonly UseExpressionBodyForGetOnlyIndexers Instance = new UseExpressionBodyForGetOnlyIndexers();
    }
}