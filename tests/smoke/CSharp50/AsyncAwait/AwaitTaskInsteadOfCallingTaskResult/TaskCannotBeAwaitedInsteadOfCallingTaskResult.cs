// ReSharper disable All

using System.Threading.Tasks;

namespace CSharp50.AsyncAwait.AwaitTaskInsteadOfCallingTaskResult
{
    class TaskCannotBeAwaitedInsteadOfCallingTaskResult
    {
        void CanBeAwaited()
        {
            var task = new Task<int>(() => 0);
            var result = task.Result;
            result = task.Result + 100;
            Method(task.Result);
        }

        void Method(int i) { }
    }
}