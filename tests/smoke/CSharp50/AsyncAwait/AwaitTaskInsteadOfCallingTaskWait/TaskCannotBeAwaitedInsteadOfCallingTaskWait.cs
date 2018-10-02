// ReSharper disable All

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
    }
}