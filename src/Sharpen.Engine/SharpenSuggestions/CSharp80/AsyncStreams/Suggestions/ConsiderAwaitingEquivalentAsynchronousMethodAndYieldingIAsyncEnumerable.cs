namespace Sharpen.Engine.SharpenSuggestions.CSharp80.AsyncStreams.Suggestions
{
    // TODO-IG: This class is not used at the moment because the analyzer
    //          is implemented using the "old" approach because we wanted
    //          to reuse the implementation from C# 5.0 Async-await features.
    //          Once we in general refactor all suggestions to the "new" way
    //          this class will be used. Let's leave it here until then.
    internal sealed class ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerable : ISharpenSuggestion
    {
        private ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerable() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.AsyncStreams.Instance;

        public string FriendlyName { get; } = "Consider awaiting equivalent asynchronous method and yielding IAsyncEnumerable";

        public static readonly ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerable Instance = new ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerable();
    }
}