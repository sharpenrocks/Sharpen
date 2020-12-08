namespace Sharpen.Engine.SharpenSuggestions.CSharp80.IndicesAndRanges.Suggestions
{
    internal sealed class UseIndexFromTheEndHeadNInsteadOfLengthMinusNInIndexerCall : ISharpenSuggestion
    {
        private UseIndexFromTheEndHeadNInsteadOfLengthMinusNInIndexerCall() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.IndicesAndRanges.Instance;

        public string FriendlyName { get; } = @"Use index from the end ""^n"" instead of ""Length - n"" in indexer call";

        public SharpenSuggestionType SuggestionType { get; } = SharpenSuggestionType.Recommendation;

        public static readonly UseIndexFromTheEndHeadNInsteadOfLengthMinusNInIndexerCall Instance = new UseIndexFromTheEndHeadNInsteadOfLengthMinusNInIndexerCall();
    }
}