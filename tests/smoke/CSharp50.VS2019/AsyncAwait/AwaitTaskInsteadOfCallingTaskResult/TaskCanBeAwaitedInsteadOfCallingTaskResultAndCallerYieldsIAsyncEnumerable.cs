// ReSharper disable All

// Expected number of suggestions: 3

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp50.VS2019.AsyncAwait.AwaitTaskInsteadOfCallingTaskResult
{   
    class TaskCanBeAwaitedInsteadOfCallingTaskResultAndCallerYieldsIAsyncEnumerable
    {
        async IAsyncEnumerable<int> CanBeAwaited()
        {
            var task = new Task<int>(() => 0);
            var result = task.Result;
            result = task.Result + 100;
            SomeMethod(task.Result);

            yield return 0;
        }

        void SomeMethod(int i) { }
    }
}