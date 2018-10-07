// ReSharper disable All

// Expected number of suggestions: 3

using System.Threading.Tasks;
using static System.Threading.Tasks.Task;

namespace CSharp50.AsyncAwait.AwaitTaskWhenAllInsteadOfCallingTaskWaitAll
{
    class TaskWhenAllCanBeAwaitedInsteadOfCallingTaskWaitAll
    {
        async void CanBeAwaited()
        {
            Task.WaitAll(null);
            WaitAll(null);
            System.Threading.Tasks.Task.WaitAll(new Task[0]);
        }
    }
}