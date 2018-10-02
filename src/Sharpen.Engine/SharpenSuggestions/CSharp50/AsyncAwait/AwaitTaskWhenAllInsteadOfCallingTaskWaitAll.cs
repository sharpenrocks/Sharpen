namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class AwaitTaskWhenAllInsteadOfCallingTaskWaitAll : BaseAwaitKnownAsynchronousMethodInsteadOfCallingSynchronousMethod
    {
        private AwaitTaskWhenAllInsteadOfCallingTaskWaitAll() : base(new MethodReplacementInfo
            {
                AsyncMethodDisplayName = "Task.WhenAll()",
                SynchronousMethodDisplayName = "Task.WaitAll()",
                SynchronousMethodName = "WaitAll",
                SynchronousMethodTypeNamespace = "System.Threading.Tasks",
                SynchronousMethodTypeName = "Task"
            }) { }

        public static readonly AwaitTaskWhenAllInsteadOfCallingTaskWaitAll Instance = new AwaitTaskWhenAllInsteadOfCallingTaskWaitAll();
    }
}