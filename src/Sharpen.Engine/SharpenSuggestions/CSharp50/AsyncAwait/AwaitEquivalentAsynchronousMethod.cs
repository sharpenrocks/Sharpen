using static Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait.EquivalentAsynchronousMethodFinder;

namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class AwaitEquivalentAsynchronousMethod : BaseAwaitingEquivalentAsynchronousMethod
    {
        // This is the check for C# 5.0.
        // In C# 5.0 we do not have async streams.
        // But that doesn't matter. If we run the analysis
        // on C# 8.0 and above code where we have async streams
        // and we have an async method that returns IAsyncEnumerable
        // and we see a method that have async equivalent, we will still
        // give the suggestion under the Async-Await feature.
        // It's a bit of a gray area. We could also have it under async
        // streams, means C# 8.0 but this looks more fitting to me.
        // Therefore, the suggestion should appear if the caller
        // is async and if it yields or not is irrelevant.
        private AwaitEquivalentAsynchronousMethod() :base(CallerAsyncStatus.CallerMustBeAsync, CallerYieldingStatus.Irrelevant) { }

        public override string FriendlyName { get; } = "Await equivalent asynchronous method";

        public static readonly AwaitEquivalentAsynchronousMethod Instance = new AwaitEquivalentAsynchronousMethod();
    }
}