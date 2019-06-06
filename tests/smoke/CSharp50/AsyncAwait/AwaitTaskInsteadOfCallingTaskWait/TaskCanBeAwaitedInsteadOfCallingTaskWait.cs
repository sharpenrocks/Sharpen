// ReSharper disable All

// Expected number of suggestions: 24

using System.Threading.Tasks;

namespace CSharp50.AsyncAwait.AwaitTaskInsteadOfCallingTaskWait
{
    class TaskCanBeAwaitedInsteadOfCallingTaskWait
    {
        async void CanBeAwaited()
        {
            var task = new Task(() => {});
            task.Wait(0);
            task.Wait(1 + 2 + 2);
            int wait = 100;
            task.Wait(wait);
        }

        async void CanBeAwaitedInMethodAndLocalMethod()
        {
            var task = new Task(() => { });
            task.Wait(0);
            task.Wait(1 + 2 + 2);
            int wait = 100;
            task.Wait(wait);

            async void LocalMethod()
            {
                task = new Task(() => { });
                task.Wait(0);
                task.Wait(1 + 2 + 2);
                wait = 100;
                task.Wait(wait);
            }
        }

        async void CanBeAwaitedInMethodAndLocalMethodAndNestedLocalMethod()
        {
            var task = new Task(() => { });
            task.Wait(0);
            task.Wait(1 + 2 + 2);
            int wait = 100;
            task.Wait(wait);

            async void LocalMethod()
            {
                task = new Task(() => { });
                task.Wait(0);
                task.Wait(1 + 2 + 2);
                wait = 100;
                task.Wait(wait);

                async void NestedLocalMethod()
                {
                    task = new Task(() => { });
                    task.Wait(0);
                    task.Wait(1 + 2 + 2);
                    wait = 100;
                    task.Wait(wait);
                }
            }
        }

        async void CanBeAwaitedWithinLocalMethodWithinAsyncMethod()
        {
            async void LocalMethod()
            {
                var task = new Task(() => { });
                task.Wait(0);
                task.Wait(1 + 2 + 2);
                int wait = 100;
                task.Wait(wait);
            }
        }

        void CanBeAwaitedWithinLocalMethodWithinNonAsyncMethod()
        {
            async void LocalMethod()
            {
                var task = new Task(() => { });
                task.Wait(0);
                task.Wait(1 + 2 + 2);
                int wait = 100;
                task.Wait(wait);
            }
        }
    }
}