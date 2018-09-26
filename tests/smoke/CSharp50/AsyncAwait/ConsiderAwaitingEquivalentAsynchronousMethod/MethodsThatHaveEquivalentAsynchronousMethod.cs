// ReSharper disable All

// Expected number of suggestions: 12

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp50.AsyncAwait.ConsiderAwaitingEquivalentAsynchronousMethod
{
    public class MethodsThatHaveEquivalentAsynchronousMethod
    {
        public void InstanceMethodsHaveAsynchronousEquivalents()
        {
            var @object = new ClassWithAsyncEquivalents();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient();
            @object.AccessFailed();
        }

        public void InstanceMethodsHaveAsynchronousEquivalentsWithDifferentReturnTypeDefinition()
        {
            var @object = new ClassWithAsyncEquivalentsReturnTypes();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
        }

        public void ThisMethodsHaveAsynchronousEquivalents()
        {
            SaveChanges();
            this.SaveChanges();
        }

        public void StaticMethodsHaveAsynchronousEquivalents()
        {
            Abort();
            MethodsThatHaveEquivalentAsynchronousMethod.Abort();
        }

        public void SaveChanges() { }
        public async Task SaveChangesAsync() { }

        public static int Abort() => 0;
        public static async Task<int> AbortAsync() => 0;
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

    public static class ClassWithAsyncEquivalentsExtensions
    {
        public static Task<bool> AcceptTcpClientAsync(this ClassWithAsyncEquivalents @object) => new Task<bool>(() => true);

        public static bool AccessFailed(this ClassWithAsyncEquivalents @object) => true;
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
}