namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class AwaitTaskInsteadOfCallingTaskWait : BaseAwaitKnownAsynchronousEquivalentInsteadOfCallingSynchronousMember
    {
        private AwaitTaskInsteadOfCallingTaskWait() : base(new SynchronousMemberReplacementInfo
            {
                AsyncEquivalentDisplayName = "task",
                SynchronousMemberDisplayName = "Task.Wait()",
                SynchronousMemberName = "Wait",
                SynchronousMemberTypeNamespace = "System.Threading.Tasks",
                SynchronousMemberTypeName = "Task"
            }) { }

        public static readonly AwaitTaskInsteadOfCallingTaskWait Instance = new AwaitTaskInsteadOfCallingTaskWait();
    }
}