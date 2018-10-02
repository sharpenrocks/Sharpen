// ReSharper disable All

// Expected number of suggestions: 1

using System.Threading.Tasks;

namespace CSharp50.AsyncAwait.AwaitTaskInsteadOfCallingTaskWait
{
    class TaskCanBeAwaitedInsteadOfCallingTaskWait
    {
        async void CanBeAwaited()
        {
            var task = new Task(() => {});
            task.Wait(0);
        }
    }
}