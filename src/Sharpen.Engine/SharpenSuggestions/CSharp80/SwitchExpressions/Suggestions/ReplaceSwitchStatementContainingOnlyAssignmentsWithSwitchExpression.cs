namespace Sharpen.Engine.SharpenSuggestions.CSharp80.SwitchExpressions.Suggestions
{
    internal sealed class ReplaceSwitchStatementContainingOnlyAssignmentsWithSwitchExpression : ISharpenSuggestion
    {
        private ReplaceSwitchStatementContainingOnlyAssignmentsWithSwitchExpression() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.SwitchExpressions.Instance;

        public string FriendlyName { get; } = "Replace switch statement containing only assignments with switch expression";

        public static readonly ReplaceSwitchStatementContainingOnlyAssignmentsWithSwitchExpression Instance = new ReplaceSwitchStatementContainingOnlyAssignmentsWithSwitchExpression();
    }
}