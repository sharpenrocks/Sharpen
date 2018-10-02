// ReSharper disable All

using System.Threading;
using static System.Threading.Thread;

namespace CSharp50.AsyncAwait.AwaitTaskDelayInsteadOfCallingThreadSleep
{
    class TaskDelayCannotBeAwaitedInsteadOfCallingThreadSleep
    {
        void CannotBeAwaited()
        {
            Thread.Sleep(0);
            Sleep(0);
        }
    }
}