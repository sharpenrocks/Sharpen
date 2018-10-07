// ReSharper disable All

// Expected number of suggestions: 3

using System.Threading.Tasks;

namespace CSharp50.AsyncAwait.AwaitTaskInsteadOfCallingTaskWait
{
    class TaskCanBeAwaitedInsteadOfCallingTaskWait
    {
        async void CanBeAwaited()
        {
            var task = new Task(() => {});
            task.Wait(0);
            task.Wait(1 + 2 + 2);
            int wait = 100;
            task.Wait(wait);
        }
    }
}