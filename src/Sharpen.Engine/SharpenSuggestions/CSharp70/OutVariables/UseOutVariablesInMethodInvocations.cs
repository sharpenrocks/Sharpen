using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70.OutVariables
{
    internal sealed class UseOutVariablesInMethodInvocations : BaseUseOutVariables<InvocationExpressionSyntax>
    {
        private UseOutVariablesInMethodInvocations() :base(false) { }

        public static readonly UseOutVariablesInMethodInvocations Instance = new UseOutVariablesInMethodInvocations();
    }
}