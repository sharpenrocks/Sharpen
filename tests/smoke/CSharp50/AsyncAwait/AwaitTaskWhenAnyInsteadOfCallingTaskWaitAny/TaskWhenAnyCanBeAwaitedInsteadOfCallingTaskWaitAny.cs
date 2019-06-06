// ReSharper disable All

// Expected number of suggestions: 32

using System.Threading.Tasks;
using static System.Threading.Tasks.Task;

namespace CSharp50.AsyncAwait.AwaitTaskWhenAnyInsteadOfCallingTaskWaitAny
{
    class TaskWhenAnyCanBeAwaitedInsteadOfCallingTaskWaitAny
    {
        async void CanBeAwaited()
        {
            Task.WaitAny(null);
            WaitAny(null);
            System.Threading.Tasks.Task.WaitAny(new Task[0]);
            int value = WaitAny(null, 1000);
        }

        async void CanBeAwaitedInMethodAndLocalMethod()
        {
            Task.WaitAny(null);
            WaitAny(null);
            System.Threading.Tasks.Task.WaitAny(new Task[0]);
            int value = WaitAny(null, 1000);

            async void LocalMethod()
            {
                Task.WaitAny(null);
                WaitAny(null);
                System.Threading.Tasks.Task.WaitAny(new Task[0]);
                value = WaitAny(null, 1000);
            }
        }

        async void CanBeAwaitedInMethodAndLocalMethodAndNestedLocalMethod()
        {
            Task.WaitAny(null);
            WaitAny(null);
            System.Threading.Tasks.Task.WaitAny(new Task[0]);
            int value = WaitAny(null, 1000);

            async void LocalMethod()
            {
                Task.WaitAny(null);
                WaitAny(null);
                System.Threading.Tasks.Task.WaitAny(new Task[0]);
                value = WaitAny(null, 1000);

                async void NestedLocalMethod()
                {
                    Task.WaitAny(null);
                    WaitAny(null);
                    System.Threading.Tasks.Task.WaitAny(new Task[0]);
                    value = WaitAny(null, 1000);
                }
            }
        }

        async void CanBeAwaitedWithinLocalMethodWithinAsyncMethod()
        {
            async void LocalMethod()
            {
                Task.WaitAny(null);
                WaitAny(null);
                System.Threading.Tasks.Task.WaitAny(new Task[0]);
                int value = WaitAny(null, 1000);
            }
        }

        void CanBeAwaitedWithinLocalMethodWithinNonAsyncMethod()
        {
            async void LocalMethod()
            {
                Task.WaitAny(null);
                WaitAny(null);
                System.Threading.Tasks.Task.WaitAny(new Task[0]);
                int value = WaitAny(null, 1000);
            }
        }
    }
}