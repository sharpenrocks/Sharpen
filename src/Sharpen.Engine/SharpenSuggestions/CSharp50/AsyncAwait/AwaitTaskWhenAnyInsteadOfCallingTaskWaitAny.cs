namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class AwaitTaskWhenAnyInsteadOfCallingTaskWaitAny : BaseAwaitKnownAsynchronousEquivalentInsteadOfCallingSynchronousMember
    {
        private AwaitTaskWhenAnyInsteadOfCallingTaskWaitAny() : base(new SynchronousMemberReplacementInfo
            {
                AsyncEquivalentDisplayName = "Task.WhenAny()",
                SynchronousMemberDisplayName = "Task.WaitAny()",
                SynchronousMemberName = "WaitAny",
                SynchronousMemberTypeNamespace = "System.Threading.Tasks",
                SynchronousMemberTypeName = "Task"
            }) { }

        public static readonly AwaitTaskWhenAnyInsteadOfCallingTaskWaitAny Instance = new AwaitTaskWhenAnyInsteadOfCallingTaskWaitAny();
    }
}