// ReSharper disable All

// Expected number of suggestions: 16

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

        async void CanBeAwaitedInMethodAndLocalMethod()
        {
            Thread.Sleep(0);
            Sleep(0);

            async void LocalMethod()
            {
                Thread.Sleep(0);
                Sleep(0);
            }
        }

        async void CanBeAwaitedInMethodAndLocalMethodAndNestedLocalMethod()
        {
            Thread.Sleep(0);
            Sleep(0);

            async void LocalMethod()
            {
                Thread.Sleep(0);
                Sleep(0);

                async void NestedLocalMethod()
                {
                    Thread.Sleep(0);
                    Sleep(0);
                }
            }
        }

        async void CanBeAwaitedWithinLocalMethodWithinAsyncMethod()
        {
            async void LocalMethod()
            {
                Thread.Sleep(0);
                Sleep(0);
            }
        }

        void CanBeAwaitedWithinLocalMethodWithinNonAsyncMethod()
        {
            async void LocalMethod()
            {
                Thread.Sleep(0);
                Sleep(0);
            }
        }
    }
}