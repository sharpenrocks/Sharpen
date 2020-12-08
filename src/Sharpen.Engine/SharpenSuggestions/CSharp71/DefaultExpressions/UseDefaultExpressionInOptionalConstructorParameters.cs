using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp71.DefaultExpressions
{
    internal sealed class UseDefaultExpressionInOptionalConstructorParameters : BaseUseDefaultExpressionInOptionalParameters<ConstructorDeclarationSyntax>
    {
        private UseDefaultExpressionInOptionalConstructorParameters() { }

        public override string FriendlyName { get; } = "Use default expression in optional constructor parameters";

        public static readonly UseDefaultExpressionInOptionalConstructorParameters Instance = new UseDefaultExpressionInOptionalConstructorParameters();
    }
}