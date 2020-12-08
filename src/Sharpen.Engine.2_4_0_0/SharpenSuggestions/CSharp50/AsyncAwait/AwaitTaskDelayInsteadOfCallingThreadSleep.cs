namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class AwaitTaskDelayInsteadOfCallingThreadSleep : BaseAwaitKnownAsynchronousEquivalentInsteadOfCallingSynchronousMember
    {
        private AwaitTaskDelayInsteadOfCallingThreadSleep() : base(new SynchronousMemberReplacementInfo
            {
                AsyncEquivalentDisplayName = "Task.Delay()",
                SynchronousMemberDisplayName = "Thread.Sleep()",
                SynchronousMemberName = "Sleep",
                SynchronousMemberTypeNamespace = "System.Threading",
                SynchronousMemberTypeName = "Thread"
            }) { }

        public static readonly AwaitTaskDelayInsteadOfCallingThreadSleep Instance = new AwaitTaskDelayInsteadOfCallingThreadSleep();
    }
}