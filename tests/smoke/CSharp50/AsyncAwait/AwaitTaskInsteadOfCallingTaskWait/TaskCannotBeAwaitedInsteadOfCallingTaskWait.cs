// ReSharper disable All

using System;
using System.Threading.Tasks;

namespace CSharp50.AsyncAwait.AwaitTaskInsteadOfCallingTaskWait
{
    class TaskCannotBeAwaitedInsteadOfCallingTaskWait
    {
        void CannotBeAwaited()
        {
            var task = new Task(() => { });
            task.Wait(0);
        }

        async void CannotBeAwaitedSoFarBecauseOfLambda()
        {
            Action a = () =>
            {
                var task = new Task(() => { });
                task.Wait(0);
            };
        }

        async void CannotBeAwaitedSoFarBecauseOfDelegate()
        {
            Action a = delegate ()
            {
                var task = new Task(() => { });
                task.Wait(0);
            };
        }

        async void CannotBeAwaitedBecauseNotDirectlyWithinTheCaller()
        {
            void LocalMethod()
            {
                var task = new Task(() => { });
                task.Wait(0);
            }
        }
    }
}