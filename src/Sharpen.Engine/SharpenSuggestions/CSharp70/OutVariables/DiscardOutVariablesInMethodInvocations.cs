using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70.OutVariables
{
    internal sealed class DiscardOutVariablesInMethodInvocations : BaseUseOutVariables<InvocationExpressionSyntax>
    {
        private DiscardOutVariablesInMethodInvocations() :base(true) { }

        public static readonly DiscardOutVariablesInMethodInvocations Instance = new DiscardOutVariablesInMethodInvocations();
    }
}