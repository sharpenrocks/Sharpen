// ReSharper disable All

// Expected number of suggestions: 2

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
        }
    }
}