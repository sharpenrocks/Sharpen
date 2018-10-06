namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class AwaitTaskInsteadOfCallingTaskResult : BaseAwaitKnownAsynchronousEquivalentInsteadOfCallingSynchronousMember
    {
        private AwaitTaskInsteadOfCallingTaskResult() : base(new SynchronousMemberReplacementInfo
            {
                AsyncEquivalentDisplayName = "task",
                SynchronousMemberDisplayName = "Task.Result",
                SynchronousMemberName = "Result",
                SynchronousMemberTypeNamespace = "System.Threading.Tasks",
                SynchronousMemberTypeName = "Task"
            }) { }

        public static readonly AwaitTaskInsteadOfCallingTaskResult Instance = new AwaitTaskInsteadOfCallingTaskResult();
    }
}