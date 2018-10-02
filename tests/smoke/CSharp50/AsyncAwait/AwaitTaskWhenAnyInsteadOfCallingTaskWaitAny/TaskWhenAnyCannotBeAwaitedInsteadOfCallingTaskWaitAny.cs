// ReSharper disable All

using System.Threading.Tasks;
using static System.Threading.Tasks.Task;

namespace CSharp50.AsyncAwait.AwaitTaskWhenAnyInsteadOfCallingTaskWaitAny
{
    class TaskWhenAnyCannotBeAwaitedInsteadOfCallingTaskWaitAny
    {
        void CannotBeAwaited()
        {
            Task.WaitAny(null);
            WaitAny(null);
        }
    }
}