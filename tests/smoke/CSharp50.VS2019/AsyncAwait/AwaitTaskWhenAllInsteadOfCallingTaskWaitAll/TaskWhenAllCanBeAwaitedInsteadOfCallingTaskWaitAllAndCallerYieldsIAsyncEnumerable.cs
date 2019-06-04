// ReSharper disable All

// Expected number of suggestions: 3

using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Threading.Tasks.Task;

namespace CSharp50.VS2019.AsyncAwait.AwaitTaskWhenAllInsteadOfCallingTaskWaitAll
{
    class TaskWhenAllCanBeAwaitedInsteadOfCallingTaskWaitAllAndCallerYieldsIAsyncEnumerable
    {
        async IAsyncEnumerable<int> CanBeAwaited()
        {
            Task.WaitAll(null);
            WaitAll(null);
            System.Threading.Tasks.Task.WaitAll(new Task[0]);

            yield return 0;
        }
    }
}