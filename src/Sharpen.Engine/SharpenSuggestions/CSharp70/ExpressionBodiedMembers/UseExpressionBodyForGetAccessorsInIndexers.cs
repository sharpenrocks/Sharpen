using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70.ExpressionBodiedMembers
{
    internal sealed class UseExpressionBodyForGetAccessorsInIndexers : BaseUseExpressionBodyForGetAccessors<IndexerDeclarationSyntax>
    {
        private UseExpressionBodyForGetAccessorsInIndexers() { }

        public override string FriendlyName { get; } = "Use expression body for get accessors in indexers";

        public static readonly UseExpressionBodyForGetAccessorsInIndexers Instance = new UseExpressionBodyForGetAccessorsInIndexers();
    }
}