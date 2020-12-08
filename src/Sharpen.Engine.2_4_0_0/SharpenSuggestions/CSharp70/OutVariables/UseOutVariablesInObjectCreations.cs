using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70.OutVariables
{
    internal sealed class UseOutVariablesInObjectCreations : BaseUseOutVariables<ObjectCreationExpressionSyntax>
    {
        private UseOutVariablesInObjectCreations() :base(false) { }

        public static readonly UseOutVariablesInObjectCreations Instance = new UseOutVariablesInObjectCreations();
    }
}