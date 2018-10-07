// ReSharper disable All

// Expected number of suggestions: 3

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

        void SomeMethod(int i) { }
    }
}