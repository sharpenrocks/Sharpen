// ReSharper disable All

// Expected number of suggestions: 4

using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Threading.Tasks.Task;

namespace CSharp50.VS2019.AsyncAwait.AwaitTaskWhenAnyInsteadOfCallingTaskWaitAny
{
    class TaskWhenAnyCanBeAwaitedInsteadOfCallingTaskWaitAnyAndCallerYieldsIAsyncEnumerable
    {
        async IAsyncEnumerable<int> CanBeAwaited()
        {
            Task.WaitAny(null);
            WaitAny(null);
            System.Threading.Tasks.Task.WaitAny(new Task[0]);
            int value = WaitAny(null, 1000);

            yield return 0;
        }
    }
}