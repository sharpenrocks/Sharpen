namespace Sharpen.Engine.SharpenSuggestions.CSharp80.IndicesAndRanges.Suggestions
{
    internal sealed class UseIndexFromTheEndHeadNInsteadOfLengthMinusNInMethodCall : ISharpenSuggestion
    {
        private UseIndexFromTheEndHeadNInsteadOfLengthMinusNInMethodCall() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.IndicesAndRanges.Instance;

        public string FriendlyName { get; } = @"Use index from the end ""^n"" instead of ""Length - n"" in method call";

        public static readonly UseIndexFromTheEndHeadNInsteadOfLengthMinusNInMethodCall Instance = new UseIndexFromTheEndHeadNInsteadOfLengthMinusNInMethodCall();
    }
}