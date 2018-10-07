// ReSharper disable All

// Expected number of suggestions: 4

using System.Threading.Tasks;
using static System.Threading.Tasks.Task;

namespace CSharp50.AsyncAwait.AwaitTaskWhenAnyInsteadOfCallingTaskWaitAny
{
    class TaskWhenAnyCanBeAwaitedInsteadOfCallingTaskWaitAny
    {
        async void CanBeAwaited()
        {
            Task.WaitAny(null);
            WaitAny(null);
            System.Threading.Tasks.Task.WaitAny(new Task[0]);
            int value = WaitAny(null, 1000);
        }
    }
}