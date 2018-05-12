using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70.OutVariables
{
    internal sealed class DiscardOutVariablesInObjectCreations : BaseUseOutVariables<ObjectCreationExpressionSyntax>
    {
        private DiscardOutVariablesInObjectCreations() :base(true) { }

        public static readonly DiscardOutVariablesInObjectCreations Instance = new DiscardOutVariablesInObjectCreations();
    }
}