using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp71
{
    internal sealed class UseDefaultExpressionInOptionalMethodParameters : BaseUseDefaultExpressionInOptionalParameters<MethodDeclarationSyntax>
    {
        private UseDefaultExpressionInOptionalMethodParameters() { }

        public override string FriendlyName { get; } = "Use default expression in optional method parameters";

        public static readonly UseDefaultExpressionInOptionalMethodParameters Instance = new UseDefaultExpressionInOptionalMethodParameters();
    }
}