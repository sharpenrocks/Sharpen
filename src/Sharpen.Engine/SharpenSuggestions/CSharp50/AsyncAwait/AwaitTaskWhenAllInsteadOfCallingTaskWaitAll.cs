namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class AwaitTaskWhenAllInsteadOfCallingTaskWaitAll : BaseAwaitKnownAsynchronousEquivalentInsteadOfCallingSynchronousMember
    {
        private AwaitTaskWhenAllInsteadOfCallingTaskWaitAll() : base(new SynchronousMemberReplacementInfo
            {
                AsyncEquivalentDisplayName = "Task.WhenAll()",
                SynchronousMemberDisplayName = "Task.WaitAll()",
                SynchronousMemberName = "WaitAll",
                SynchronousMemberTypeNamespace = "System.Threading.Tasks",
                SynchronousMemberTypeName = "Task"
            }) { }

        public static readonly AwaitTaskWhenAllInsteadOfCallingTaskWaitAll Instance = new AwaitTaskWhenAllInsteadOfCallingTaskWaitAll();
    }
}