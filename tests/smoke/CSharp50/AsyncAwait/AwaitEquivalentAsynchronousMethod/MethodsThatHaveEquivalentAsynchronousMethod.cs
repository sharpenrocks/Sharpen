// ReSharper disable All

// Expected number of suggestions: 66

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp50.AsyncAwait.AwaitEquivalentAsynchronousMethod
{
    public class MethodsThatHaveEquivalentAsynchronousMethodCalledInMethods
    {
        public async void InstanceMethodsHaveAsynchronousEquivalents()
        {
            var @object = new ClassWithAsyncEquivalents();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient();
            @object.AccessFailed();
        }

        public async void InstanceMethodsHaveAsynchronousEquivalentsValueTask()
        {
            var @object = new ClassWithAsyncEquivalentsValueTask();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient();
            @object.AccessFailed();
        }

        public async void InstanceMethodsHaveAsynchronousEquivalentsWithDifferentReturnTypeDefinition()
        {
            var @object = new ClassWithAsyncEquivalentsReturnTypes();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
        }

        public async void InstanceMethodsHaveAsynchronousEquivalentsWithMethodParameters()
        {
            var @object = new ClassWithAsyncEquivalentsMethodParameters();

            @object.SaveChanges(0, "");
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient(0, "");
        }

        public async void InstanceMethodsHaveAsynchronousEquivalentsWithLocalFunctionYielding()
        {
            var @object = new ClassWithAsyncEquivalents();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient();
            @object.AccessFailed();

            YieldSomething();

            IEnumerable<int> YieldSomething()
            {
                for (int i = 0; i < 100; i++)
                {
                    @object.SaveChanges();
                    @object.Abort();
                    @object.AcceptSocket();
                    @object.AcceptTcpClient();
                    @object.AccessFailed();

                    yield return i;
                }

                yield break;
            }
        }
    }

    public class MethodsThatHaveEquivalentAsynchronousMethodCalledInLocalFunctionsInNonAsyncMethods
    {
        public void InstanceMethodsHaveAsynchronousEquivalents()
        {
            LocalFunction();

            async void LocalFunction()
            {
                var @object = new ClassWithAsyncEquivalents();

                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient();
                @object.AccessFailed();
            }
        }

        public void InstanceMethodsHaveAsynchronousEquivalentsValueTask()
        {
            LocalFunction();

            async void LocalFunction()
            {
                var @object = new ClassWithAsyncEquivalentsValueTask();

                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient();
                @object.AccessFailed();
            }
        }

        public void InstanceMethodsHaveAsynchronousEquivalentsWithDifferentReturnTypeDefinition()
        {
            LocalFunction();

            async void LocalFunction()
            {
                var @object = new ClassWithAsyncEquivalentsReturnTypes();

                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();
            }
        }

        public void InstanceMethodsHaveAsynchronousEquivalentsWithMethodParameters()
        {
            LocalFunction();

            async void LocalFunction()
            {
                var @object = new ClassWithAsyncEquivalentsMethodParameters();

                @object.SaveChanges(0, "");
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient(0, "");
            }
        }

        public void InstanceMethodsHaveAsynchronousEquivalentsWithLocalFunctionYielding()
        {
            LocalFunction();

            async void LocalFunction()
            {
                var @object = new ClassWithAsyncEquivalents();

                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient();
                @object.AccessFailed();

                YieldSomething();

                IEnumerable<int> YieldSomething()
                {
                    for (int i = 0; i < 100; i++)
                    {
                        @object.SaveChanges();
                        @object.Abort();
                        @object.AcceptSocket();
                        @object.AcceptTcpClient();
                        @object.AccessFailed();

                        yield return i;
                    }

                    yield break;
                }
            }
        }
    }

    public class MethodsThatHaveEquivalentAsynchronousMethodCalledInLocalFunctionsInAsyncMethods
    {
        public async void InstanceMethodsHaveAsynchronousEquivalents()
        {
            LocalFunction();

            async void LocalFunction()
            {
                var @object = new ClassWithAsyncEquivalents();

                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient();
                @object.AccessFailed();
            }
        }

        public async void InstanceMethodsHaveAsynchronousEquivalentsValueTask()
        {
            LocalFunction();

            async void LocalFunction()
            {
                var @object = new ClassWithAsyncEquivalentsValueTask();

                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient();
                @object.AccessFailed();
            }
        }

        public async void InstanceMethodsHaveAsynchronousEquivalentsWithDifferentReturnTypeDefinition()
        {
            LocalFunction();

            async void LocalFunction()
            {
                var @object = new ClassWithAsyncEquivalentsReturnTypes();

                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();
            }
        }

        public async void InstanceMethodsHaveAsynchronousEquivalentsWithMethodParameters()
        {
            LocalFunction();

            async void LocalFunction()
            {
                var @object = new ClassWithAsyncEquivalentsMethodParameters();

                @object.SaveChanges(0, "");
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient(0, "");
            }
        }

        public async void InstanceMethodsHaveAsynchronousEquivalentsWithLocalFunctionYielding()
        {
            LocalFunction();

            async void LocalFunction()
            {
                var @object = new ClassWithAsyncEquivalents();

                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient();
                @object.AccessFailed();

                YieldSomething();

                IEnumerable<int> YieldSomething()
                {
                    for (int i = 0; i < 100; i++)
                    {
                        @object.SaveChanges();
                        @object.Abort();
                        @object.AcceptSocket();
                        @object.AcceptTcpClient();
                        @object.AccessFailed();

                        yield return i;
                    }

                    yield break;
                }
            }
        }
    }

    public class ClassWithAsyncEquivalents
    {
        public void SaveChanges() { }
        public async Task SaveChangesAsync() { }

        public int Abort() => 0;
        public async Task<int> AbortAsync() => 0;

        public void AcceptSocket() { }
        public Task AcceptSocketAsync() => new Task(() => {});

        public bool AcceptTcpClient() => true;

        public Task<bool> AccessFailedAsync() => Task.FromResult(true);
    }

    public class ClassWithAsyncEquivalentsValueTask
    {
        public void SaveChanges() { }
        public async ValueTask SaveChangesAsync() { }

        public int Abort() => 0;
        public async ValueTask<int> AbortAsync() => 0;

        public void AcceptSocket() { }
        public ValueTask AcceptSocketAsync() => new ValueTask();

        public bool AcceptTcpClient() => true;

        public ValueTask<bool> AccessFailedAsync() => new ValueTask<bool>(true);
    }

    public static class ClassWithAsyncEquivalentsExtensions
    {
        public static Task<bool> AcceptTcpClientAsync(this ClassWithAsyncEquivalents @object) => new Task<bool>(() => true);
        public static ValueTask<bool> AcceptTcpClientAsync(this ClassWithAsyncEquivalentsValueTask @object) => new ValueTask<bool>(true);

        public static bool AccessFailed(this ClassWithAsyncEquivalents @object) => true;
        public static bool AccessFailed(this ClassWithAsyncEquivalentsValueTask @object) => true;
    }

    public class ClassWithAsyncEquivalentsReturnTypes
    {
        public System.String SaveChanges() => "";
        public async Task<string> SaveChangesAsync() => "";

        public int Abort() => 0;
        public async Task<Int32> AbortAsync() => 0;

        public IEnumerable<int> AcceptSocket() => new int[0];
        public Task<System.Collections.Generic.IEnumerable<System.Int32>> AcceptSocketAsync() => Task.FromResult(new int[0].AsEnumerable());
    }

    public class ClassWithAsyncEquivalentsMethodParameters
    {
        public void SaveChanges(int i, string s) { }
        public async Task SaveChangesAsync(int i, System.String s) { }

        public int Abort() => 0;
        public async Task<int> AbortAsync(CancellationToken cancellationToken = default) => 0;

        public void AcceptSocket() { }
        public Task AcceptSocketAsync(CancellationToken cancellationToken) => new Task(() => { });

        public bool AcceptTcpClient(int i, string s) => true;
        public async Task<bool> AcceptTcpClientAsync(Int32 i, String s, CancellationToken cancellationToken = default) => true;
    }
}