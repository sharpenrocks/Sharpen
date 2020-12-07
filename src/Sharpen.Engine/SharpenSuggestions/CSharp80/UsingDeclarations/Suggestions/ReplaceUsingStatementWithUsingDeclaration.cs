namespace Sharpen.Engine.SharpenSuggestions.CSharp80.UsingDeclarations.Suggestions
{
    internal sealed class ReplaceUsingStatementWithUsingDeclaration : ISharpenSuggestion
    {
        private ReplaceUsingStatementWithUsingDeclaration() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.UsingDeclarations.Instance;

        public string FriendlyName { get; } = "Replace using statement with using declaration";

        public SharpenSuggestionType SuggestionType { get; } = SharpenSuggestionType.Recommendation;

        public static readonly ReplaceUsingStatementWithUsingDeclaration Instance = new ReplaceUsingStatementWithUsingDeclaration();
    }
}