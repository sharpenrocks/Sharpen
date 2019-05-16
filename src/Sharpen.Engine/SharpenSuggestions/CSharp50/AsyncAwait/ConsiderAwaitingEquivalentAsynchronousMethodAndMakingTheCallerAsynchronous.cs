using static Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait.EquivalentAsynchronousMethodFinder;

namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class ConsiderAwaitingEquivalentAsynchronousMethodAndMakingTheCallerAsynchronous : BaseAwaitingEquivalentAsynchronousMethod
    {
        private ConsiderAwaitingEquivalentAsynchronousMethodAndMakingTheCallerAsynchronous() : base(CallerAsyncStatus.CallerMustNotBeAsync) { }

        public override string FriendlyName { get; } = "Consider awaiting equivalent asynchronous method and making the caller asynchronous";

        public static readonly ConsiderAwaitingEquivalentAsynchronousMethodAndMakingTheCallerAsynchronous Instance = new ConsiderAwaitingEquivalentAsynchronousMethodAndMakingTheCallerAsynchronous();
    }
}