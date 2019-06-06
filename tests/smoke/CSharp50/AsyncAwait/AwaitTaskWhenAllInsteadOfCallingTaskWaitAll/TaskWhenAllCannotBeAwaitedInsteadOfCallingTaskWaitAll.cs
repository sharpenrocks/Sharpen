// ReSharper disable All

using System;
using System.Threading.Tasks;
using static System.Threading.Tasks.Task;

namespace CSharp50.AsyncAwait.AwaitTaskWhenAllInsteadOfCallingTaskWaitAll
{
    class TaskWhenAllCannotBeAwaitedInsteadOfCallingTaskWaitAll
    {
        void CannotBeAwaited()
        {
            Task.WaitAll(null);
            WaitAll(null);
        }

        async void CannotBeAwaitedSoFarBecauseOfLambda()
        {
            Action a = () =>
            {
                Task.WaitAll(null);
                WaitAll(null);
            };
        }

        async void CannotBeAwaitedSoFarBecauseOfDelegate()
        {
            Action a = delegate ()
            {
                Task.WaitAll(null);
                WaitAll(null);
            };
        }

        async void CannotBeAwaitedBecauseNotDirectlyWithinTheCaller()
        {
            void LocalMethod()
            {
                Task.WaitAll(null);
                WaitAll(null);
            }
        }
    }
}