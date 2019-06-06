// ReSharper disable All

using System;
using System.Threading.Tasks;
using static System.Threading.Tasks.Task;

namespace CSharp50.AsyncAwait.AwaitTaskWhenAnyInsteadOfCallingTaskWaitAny
{
    class TaskWhenAnyCannotBeAwaitedInsteadOfCallingTaskWaitAny
    {
        void CannotBeAwaited()
        {
            Task.WaitAny(null);
            WaitAny(null);
        }

        async void CannotBeAwaitedSoFarBecauseOfLambda()
        {
            Action a = () =>
            {
                Task.WaitAny(null);
                WaitAny(null);
            };
        }

        async void CannotBeAwaitedSoFarBecauseOfDelegate()
        {
            Action a = delegate ()
            {
                Task.WaitAny(null);
                WaitAny(null);
            };
        }

        async void CannotBeAwaitedBecauseNotDirectlyWithinTheCaller()
        {
            void LocalMethod()
            {
                Task.WaitAny(null);
                WaitAny(null);
            }
        }
    }
}