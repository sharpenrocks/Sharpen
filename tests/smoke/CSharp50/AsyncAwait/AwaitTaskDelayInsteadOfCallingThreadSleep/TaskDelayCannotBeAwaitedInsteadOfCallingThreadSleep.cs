// ReSharper disable All

using System;
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

        async void CannotBeAwaitedSoFarBecauseOfLambda()
        {
            Action a = () =>
            {
                Thread.Sleep(0);
                Sleep(0);
            };
        }

        async void CannotBeAwaitedSoFarBecauseOfDelegate()
        {
            Action a = delegate()
            {
                Thread.Sleep(0);
                Sleep(0);
            };
        }

        async void CannotBeAwaitedBecauseNotDirectlyWithinTheCaller()
        {
            void LocalMethod()
            {
                Thread.Sleep(0);
                Sleep(0);
            }
        }
    }
}