// ReSharper disable All

// Expected number of suggestions: 2

using System.Threading;
using static System.Threading.Thread;

namespace CSharp50.AsyncAwait.AwaitTaskDelayInsteadOfCallingThreadSleep
{
    class TaskDelayCanBeAwaitedInsteadOfCallingThreadSleep
    {
        async void CanBeAwaited()
        {
            Thread.Sleep(0);
            Sleep(0);
        }
    }
}