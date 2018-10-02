namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class AwaitTaskWhenAnyInsteadOfCallingTaskWaitAny : BaseAwaitKnownAsynchronousMethodInsteadOfCallingSynchronousMethod
    {
        private AwaitTaskWhenAnyInsteadOfCallingTaskWaitAny() : base(new MethodReplacementInfo
            {
                AsyncMethodDisplayName = "Task.WhenAny()",
                SynchronousMethodDisplayName = "Task.WaitAny()",
                SynchronousMethodName = "WaitAny",
                SynchronousMethodTypeNamespace = "System.Threading.Tasks",
                SynchronousMethodTypeName = "Task"
            }) { }

        public static readonly AwaitTaskWhenAnyInsteadOfCallingTaskWaitAny Instance = new AwaitTaskWhenAnyInsteadOfCallingTaskWaitAny();
    }
}