using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70
{
    public class UseExpressionBodyForSetAccessorsInProperties : BaseUseExpressionBodyForSetAccessors<PropertyDeclarationSyntax>
    {
        private UseExpressionBodyForSetAccessorsInProperties() { }

        public override string FriendlyName { get; } = "Use expression body for set accessors in properties";

        public static readonly UseExpressionBodyForSetAccessorsInProperties Instance = new UseExpressionBodyForSetAccessorsInProperties();
    }
}