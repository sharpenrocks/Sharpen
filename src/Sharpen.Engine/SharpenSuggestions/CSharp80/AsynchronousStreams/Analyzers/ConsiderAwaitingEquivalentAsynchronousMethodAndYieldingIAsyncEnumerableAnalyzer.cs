using Sharpen.Engine.SharpenSuggestions.Common.AsyncAwaitAndAsyncStreams;
using static Sharpen.Engine.SharpenSuggestions.Common.AsyncAwaitAndAsyncStreams.EquivalentAsynchronousMethodFinder;

namespace Sharpen.Engine.SharpenSuggestions.CSharp80.AsynchronousStreams.Analyzers
{
    internal sealed class ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerableAnalyzer : BaseAwaitingEquivalentAsynchronousMethod
    {
        private ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerableAnalyzer() : base(CallerAsyncStatus.CallerMustNotBeAsync, CallerYieldingStatus.CallerMustYield) { }

        public override string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp80;

        public override ICSharpFeature LanguageFeature { get; } = CSharpFeatures.AsynchronousStreams.Instance;

        public override string FriendlyName { get; } = "Consider awaiting equivalent asynchronous method and yielding IAsyncEnumerable";

        public override SharpenSuggestionType SuggestionType { get; } = SharpenSuggestionType.Consideration;

        public static readonly ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerableAnalyzer Instance = new ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerableAnalyzer();
    }
}