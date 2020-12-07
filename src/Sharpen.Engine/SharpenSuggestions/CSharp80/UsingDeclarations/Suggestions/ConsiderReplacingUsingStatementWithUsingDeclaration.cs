namespace Sharpen.Engine.SharpenSuggestions.CSharp80.UsingDeclarations.Suggestions
{
    internal sealed class ConsiderReplacingUsingStatementWithUsingDeclaration : ISharpenSuggestion
    {
        private ConsiderReplacingUsingStatementWithUsingDeclaration() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.UsingDeclarations.Instance;

        public string FriendlyName { get; } = "Consider replacing using statement with using declaration";

        public SharpenSuggestionType SuggestionType { get; } = SharpenSuggestionType.Consideration;

        public static readonly ConsiderReplacingUsingStatementWithUsingDeclaration Instance = new ConsiderReplacingUsingStatementWithUsingDeclaration();
    }
}