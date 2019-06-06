// ReSharper disable All

using System;
using System.Threading.Tasks;

namespace CSharp50.AsyncAwait.AwaitTaskInsteadOfCallingTaskResult
{
    class TaskCannotBeAwaitedInsteadOfCallingTaskResult
    {
        void CannotBeAwaited()
        {
            var task = new Task<int>(() => 0);
            var result = task.Result;
            result = task.Result + 100;
            Method(task.Result);
        }

        async void CannotBeAwaitedSoFarBecauseOfLambda()
        {
            Action a = () =>
            {
                var task = new Task<int>(() => 0);
                var result = task.Result;
                result = task.Result + 100;
                Method(task.Result);
            };
        }

        async void CannotBeAwaitedSoFarBecauseOfDelegate()
        {
            Action a = delegate ()
            {
                var task = new Task<int>(() => 0);
                var result = task.Result;
                result = task.Result + 100;
                Method(task.Result);
            };
        }

        async void CannotBeAwaitedBecauseNotDirectlyWithinTheCaller()
        {
            void LocalMethod()
            {
                var task = new Task<int>(() => 0);
                var result = task.Result;
                result = task.Result + 100;
                Method(task.Result);
            }
        }

        void Method(int i) { }
    }
}