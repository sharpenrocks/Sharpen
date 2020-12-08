namespace Sharpen.Engine.SharpenSuggestions.CSharp80.SwitchExpressions.Suggestions
{
    internal sealed class ReplaceSwitchStatementContainingOnlyReturnsWithSwitchExpression : ISharpenSuggestion
    {
        private ReplaceSwitchStatementContainingOnlyReturnsWithSwitchExpression() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.SwitchExpressions.Instance;

        public string FriendlyName { get; } = "Replace switch statement containing only returns with switch expression";

        public SharpenSuggestionType SuggestionType { get; } = SharpenSuggestionType.Recommendation;

        public static readonly ReplaceSwitchStatementContainingOnlyReturnsWithSwitchExpression Instance = new ReplaceSwitchStatementContainingOnlyReturnsWithSwitchExpression();
    }
}