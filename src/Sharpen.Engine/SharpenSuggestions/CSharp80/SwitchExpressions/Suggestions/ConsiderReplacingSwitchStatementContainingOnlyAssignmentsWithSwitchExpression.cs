namespace Sharpen.Engine.SharpenSuggestions.CSharp80.SwitchExpressions.Suggestions
{
    internal sealed class ConsiderReplacingSwitchStatementContainingOnlyAssignmentsWithSwitchExpression : ISharpenSuggestion
    {
        private ConsiderReplacingSwitchStatementContainingOnlyAssignmentsWithSwitchExpression() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.SwitchExpressions.Instance;

        public string FriendlyName { get; } = "Consider replacing switch statement containing only assignments with switch expression";

        public static readonly ConsiderReplacingSwitchStatementContainingOnlyAssignmentsWithSwitchExpression Instance = new ConsiderReplacingSwitchStatementContainingOnlyAssignmentsWithSwitchExpression();
    }
}