// ReSharper disable All

// Expected number of suggestions: 24

using System.Threading.Tasks;

namespace CSharp50.AsyncAwait.AwaitTaskInsteadOfCallingTaskResult
{   
    class TaskCanBeAwaitedInsteadOfCallingTaskResult
    {
        async void CanBeAwaited()
        {
            var task = new Task<int>(() => 0);
            var result = task.Result;
            result = task.Result + 100;
            SomeMethod(task.Result);
        }

        async void CanBeAwaitedInMethodAndLocalMethod()
        {
            var task = new Task<int>(() => 0);
            var result = task.Result;
            result = task.Result + 100;
            SomeMethod(task.Result);

            async void LocalMethod()
            {
                task = new Task<int>(() => 0);
                result = task.Result;
                result = task.Result + 100;
                SomeMethod(task.Result);
            }
        }

        async void CanBeAwaitedInMethodAndLocalMethodAndNestedLocalMethod()
        {
            var task = new Task<int>(() => 0);
            var result = task.Result;
            result = task.Result + 100;
            SomeMethod(task.Result);

            async void LocalMethod()
            {
                task = new Task<int>(() => 0);
                result = task.Result;
                result = task.Result + 100;
                SomeMethod(task.Result);

                async void NestedLocalMethod()
                {
                    task = new Task<int>(() => 0);
                    result = task.Result;
                    result = task.Result + 100;
                    SomeMethod(task.Result);
                }
            }
        }

        async void CanBeAwaitedWithinLocalMethodWithinAsyncMethod()
        {
            async void LocalMethod()
            {
                var task = new Task<int>(() => 0);
                var result = task.Result;
                result = task.Result + 100;
                SomeMethod(task.Result);
            }
        }

        void CanBeAwaitedWithinLocalMethodWithinNonAsyncMethod()
        {
            async void LocalMethod()
            {
                var task = new Task<int>(() => 0);
                var result = task.Result;
                result = task.Result + 100;
                SomeMethod(task.Result);
            }
        }

        void SomeMethod(int i) { }
    }
}