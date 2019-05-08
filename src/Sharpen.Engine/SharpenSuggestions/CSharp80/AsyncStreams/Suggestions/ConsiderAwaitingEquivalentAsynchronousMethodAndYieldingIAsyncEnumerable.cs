namespace Sharpen.Engine.SharpenSuggestions.CSharp80.AsyncStreams.Suggestions
{
    internal sealed class ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerable : ISharpenSuggestion
    {
        private ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerable() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.AsyncStreams.Instance;

        public string FriendlyName { get; } = "Consider awaiting equivalent asynchronous method and yielding IAsyncEnumerable";

        public static readonly ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerable Instance = new ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerable();
    }
}