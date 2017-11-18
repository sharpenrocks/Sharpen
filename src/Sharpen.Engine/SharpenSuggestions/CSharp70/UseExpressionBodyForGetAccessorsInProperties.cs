using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70
{
    internal class UseExpressionBodyForGetAccessorsInProperties : BaseUseExpressionBodyForGetAccessors<PropertyDeclarationSyntax>
    {
        private UseExpressionBodyForGetAccessorsInProperties() { }

        public override string FriendlyName { get; } = "Use expression body for get accessors in properties";

        public static readonly UseExpressionBodyForGetAccessorsInProperties Instance = new UseExpressionBodyForGetAccessorsInProperties();
    }
}