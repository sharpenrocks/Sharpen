namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class AwaitTaskInsteadOfCallingTaskWait : BaseAwaitKnownAsynchronousMethodInsteadOfCallingSynchronousMethod
    {
        private AwaitTaskInsteadOfCallingTaskWait() : base(new MethodReplacementInfo
            {
                AsyncMethodDisplayName = "task",
                SynchronousMethodDisplayName = "Task.Wait()",
                SynchronousMethodName = "Wait",
                SynchronousMethodTypeNamespace = "System.Threading.Tasks",
                SynchronousMethodTypeName = "Task"
            }) { }

        public static readonly AwaitTaskInsteadOfCallingTaskWait Instance = new AwaitTaskInsteadOfCallingTaskWait();
    }
}