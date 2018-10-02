namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class AwaitTaskDelayInsteadOfCallingThreadSleep : BaseAwaitKnownAsynchronousMethodInsteadOfCallingSynchronousMethod
    {
        private AwaitTaskDelayInsteadOfCallingThreadSleep() : base(new MethodReplacementInfo
            {
                AsyncMethodDisplayName = "Task.Delay()",
                SynchronousMethodDisplayName = "Thread.Sleep()",
                SynchronousMethodName = "Sleep",
                SynchronousMethodTypeNamespace = "System.Threading",
                SynchronousMethodTypeName = "Thread"
            }) { }

        public static readonly AwaitTaskDelayInsteadOfCallingThreadSleep Instance = new AwaitTaskDelayInsteadOfCallingThreadSleep();
    }
}