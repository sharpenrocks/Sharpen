using static Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait.EquivalentAsynchronousMethodFinder;

namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class AwaitEquivalentAsynchronousMethod : BaseAwaitingEquivalentAsynchronousMethod
    {
        private AwaitEquivalentAsynchronousMethod() :base(CallerAsyncStatus.CallerMustBeAsync) { }

        public override string FriendlyName { get; } = "Await equivalent asynchronous method";

        public static readonly AwaitEquivalentAsynchronousMethod Instance = new AwaitEquivalentAsynchronousMethod();
    }
}