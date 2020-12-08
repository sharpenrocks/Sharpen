using Sharpen.Engine.SharpenSuggestions.Common.AsyncAwaitAndAsyncStreams;
using static Sharpen.Engine.SharpenSuggestions.Common.AsyncAwaitAndAsyncStreams.EquivalentAsynchronousMethodFinder;

namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class ConsiderAwaitingEquivalentAsynchronousMethodAndMakingTheCallerAsynchronous : BaseAwaitingEquivalentAsynchronousMethod
    {
        // This is the check for C# 5.0.
        // In C# 5.0 we do not have async streams.
        // It means, if the caller yields it cannot be marked as async.
        // Therefore, for C# 5.0 Async-Await feature, the suggestion should
        // appear only if the caller is not async and does not yield.
        private ConsiderAwaitingEquivalentAsynchronousMethodAndMakingTheCallerAsynchronous() : base(CallerAsyncStatus.CallerMustNotBeAsync, CallerYieldingStatus.CallerMustNotYield) { }

        public override string FriendlyName { get; } = "Consider awaiting equivalent asynchronous method and making the caller asynchronous";

        public override SharpenSuggestionType SuggestionType { get; } = SharpenSuggestionType.Consideration;

        public static readonly ConsiderAwaitingEquivalentAsynchronousMethodAndMakingTheCallerAsynchronous Instance = new ConsiderAwaitingEquivalentAsynchronousMethodAndMakingTheCallerAsynchronous();
    }
}