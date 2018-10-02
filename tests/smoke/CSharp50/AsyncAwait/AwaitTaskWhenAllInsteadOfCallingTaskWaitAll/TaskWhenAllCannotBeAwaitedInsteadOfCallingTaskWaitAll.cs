// ReSharper disable All

using System.Threading.Tasks;
using static System.Threading.Tasks.Task;

namespace CSharp50.AsyncAwait.AwaitTaskWhenAllInsteadOfCallingTaskWaitAll
{
    class TaskWhenAllCannotBeAwaitedInsteadOfCallingTaskWaitAll
    {
        void CannotBeAwaited()
        {
            Task.WaitAll(null);
            WaitAll(null);
        }
    }
}