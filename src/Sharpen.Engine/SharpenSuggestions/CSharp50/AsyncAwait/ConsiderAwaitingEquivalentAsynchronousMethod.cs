using static Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait.EquivalentAsynchronousMethodFinder;

namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class ConsiderAwaitingEquivalentAsynchronousMethod : BaseAwaitingEquivalentAsynchronousMethod
    {
        private ConsiderAwaitingEquivalentAsynchronousMethod() : base(EnclosingMethodAsyncStatus.EnclosingMethodMustNotBeAsync) { }

        public override string FriendlyName { get; } = "Consider awaiting equivalent asynchronous method";

        public static readonly ConsiderAwaitingEquivalentAsynchronousMethod Instance = new ConsiderAwaitingEquivalentAsynchronousMethod();
    }
}