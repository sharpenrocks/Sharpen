// ReSharper disable All

// Expected number of suggestions: 24

using System.Threading.Tasks;
using static System.Threading.Tasks.Task;

namespace CSharp50.AsyncAwait.AwaitTaskWhenAllInsteadOfCallingTaskWaitAll
{
    class TaskWhenAllCanBeAwaitedInsteadOfCallingTaskWaitAll
    {
        async void CanBeAwaited()
        {
            Task.WaitAll(null);
            WaitAll(null);
            System.Threading.Tasks.Task.WaitAll(new Task[0]);
        }

        async void CanBeAwaitedInMethodAndLocalMethod()
        {
            Task.WaitAll(null);
            WaitAll(null);
            System.Threading.Tasks.Task.WaitAll(new Task[0]);

            async void LocalMethod()
            {
                Task.WaitAll(null);
                WaitAll(null);
                System.Threading.Tasks.Task.WaitAll(new Task[0]);
            }
        }

        async void CanBeAwaitedInMethodAndLocalMethodAndNestedLocalMethod()
        {
            Task.WaitAll(null);
            WaitAll(null);
            System.Threading.Tasks.Task.WaitAll(new Task[0]);

            async void LocalMethod()
            {
                Task.WaitAll(null);
                WaitAll(null);
                System.Threading.Tasks.Task.WaitAll(new Task[0]);

                async void NestedLocalMethod()
                {
                    Task.WaitAll(null);
                    WaitAll(null);
                    System.Threading.Tasks.Task.WaitAll(new Task[0]);
                }
            }
        }

        async void CanBeAwaitedWithinLocalMethodWithinAsyncMethod()
        {
            async void LocalMethod()
            {
                Task.WaitAll(null);
                WaitAll(null);
                System.Threading.Tasks.Task.WaitAll(new Task[0]);
            }
        }

        void CanBeAwaitedWithinLocalMethodWithinNonAsyncMethod()
        {
            async void LocalMethod()
            {
                Task.WaitAll(null);
                WaitAll(null);
                System.Threading.Tasks.Task.WaitAll(new Task[0]);
            }
        }
    }
}