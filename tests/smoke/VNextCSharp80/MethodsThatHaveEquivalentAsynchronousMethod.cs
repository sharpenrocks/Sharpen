// ReSharper disable All

// Expected number of suggestions: 17

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VNextCSharp80.AsyncAwait.AwaitEquivalentAsynchronousMethod
{
    public class MethodsThatHaveEquivalentAsynchronousMethod
    {
        public async void InstanceMethodsHaveAsynchronousEquivalents()
        {
            string? text = "Nullable reference type";
            Console.WriteLine(text);

            var @object = new ClassWithAsyncEquivalents();

            var area = "".Length switch // Switch expressions.
            {
                0 => 0,
                1 => 1,
                _ => 0
            };
            Console.WriteLine(area);

            @object.SaveChanges();
            @object.Abort();

            int[] ranges = { 1, 2, 3, 4, 5 };
            var slice = ranges[0..^1];
            Console.WriteLine(slice);

            @object.AcceptSocket();
            @object.AcceptTcpClient();
            @object.AccessFailed();
        }

        public async void InstanceMethodsHaveAsynchronousEquivalentsValueTask()
        {
            var @object = new ClassWithAsyncEquivalentsValueTask();

            @object.SaveChanges();

            var area = "".Length switch // Switch expressions.
            {
                0 => 0,
                1 => 1,
                _ => 0
            };
            Console.WriteLine(area);

            @object.Abort();

            string? text = "Nullable reference type";
            Console.WriteLine(text);

            @object.AcceptSocket();
            @object.AcceptTcpClient();

            int[] ranges = { 1, 2, 3, 4, 5 };
            var slice = ranges[0..^1];
            Console.WriteLine(slice);

            @object.AccessFailed();
        }

        public async void InstanceMethodsHaveAsynchronousEquivalentsWithDifferentReturnTypeDefinition()
        {
            var @object = new ClassWithAsyncEquivalentsReturnTypes();

            int[] ranges = { 1, 2, 3, 4, 5 };
            var slice = ranges[0..^1];
            Console.WriteLine(slice);

            @object.SaveChanges();
            @object.Abort();

            string? text = "Nullable reference type";
            Console.WriteLine(text);

            @object.AcceptSocket();

            var area = "".Length switch // Switch expressions.
            {
                0 => 0,
                1 => 1,
                _ => 0
            };
            Console.WriteLine(area);
        }

        public async void InstanceMethodsHaveAsynchronousEquivalentsWithMethodParameters()
        {
            var @object = new ClassWithAsyncEquivalentsMethodParameters();

            var area = "".Length switch // Switch expressions.
            {
                0 => 0,
                1 => 1,
                _ => 0
            };
            Console.WriteLine(area);

            @object.SaveChanges(0, "");
            @object.Abort();

            int[] ranges = { 1, 2, 3, 4, 5 };
            var slice = ranges[0..^1];
            Console.WriteLine(slice);

            @object.AcceptSocket();
            @object.AcceptTcpClient(0, "");
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