namespace Sharpen.Engine.SharpenSuggestions.CSharp80.SwitchExpressions.Suggestions
{
    internal sealed class ConsiderReplacingSwitchStatementContainingOnlyReturnsWithSwitchExpression : ISharpenSuggestion
    {
        private ConsiderReplacingSwitchStatementContainingOnlyReturnsWithSwitchExpression() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.SwitchExpressions.Instance;

        public string FriendlyName { get; } = "Consider replacing switch statement containing only returns with switch expression";

        public static readonly ConsiderReplacingSwitchStatementContainingOnlyReturnsWithSwitchExpression Instance = new ConsiderReplacingSwitchStatementContainingOnlyReturnsWithSwitchExpression();
    }
}