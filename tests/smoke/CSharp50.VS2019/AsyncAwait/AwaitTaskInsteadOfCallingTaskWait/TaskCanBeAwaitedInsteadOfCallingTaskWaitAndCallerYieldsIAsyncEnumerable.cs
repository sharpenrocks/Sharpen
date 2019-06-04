// ReSharper disable All

// Expected number of suggestions: 3

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp50.VS2019.AsyncAwait.AwaitTaskInsteadOfCallingTaskWait
{
    class TaskCanBeAwaitedInsteadOfCallingTaskWaitAndCallerYieldsIAsyncEnumerable
    {
        async IAsyncEnumerable<int> CanBeAwaited()
        {
            var task = new Task(() => {});
            task.Wait(0);
            task.Wait(1 + 2 + 2);
            int wait = 100;
            task.Wait(wait);

            yield return 0;
        }
    }
}