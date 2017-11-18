using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp60
{
    public class UseExpressionBodyForGetOnlyProperties : BaseUseExpressionBodyForGetOnlyMembers<PropertyDeclarationSyntax>
    {
        private UseExpressionBodyForGetOnlyProperties() { }

        public override string FriendlyName { get; } = "Use expression body for get-only properties";

        public static readonly UseExpressionBodyForGetOnlyProperties Instance = new UseExpressionBodyForGetOnlyProperties();
    }
}