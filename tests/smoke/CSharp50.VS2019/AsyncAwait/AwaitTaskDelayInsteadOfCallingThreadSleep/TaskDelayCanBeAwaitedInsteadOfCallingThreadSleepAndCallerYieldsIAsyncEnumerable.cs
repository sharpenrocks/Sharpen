// ReSharper disable All

// Expected number of suggestions: 2

using System.Collections.Generic;
using System.Threading;
using static System.Threading.Thread;

namespace CSharp50.VS2019.AsyncAwait.AwaitTaskDelayInsteadOfCallingThreadSleep
{
    class TaskDelayCanBeAwaitedInsteadOfCallingThreadSleepAndCallerYieldsIAsyncEnumerable
    {
        async IAsyncEnumerable<int> CanBeAwaited()
        {
            Thread.Sleep(0);
            Sleep(0);

            yield return 0;
        }
    }
}