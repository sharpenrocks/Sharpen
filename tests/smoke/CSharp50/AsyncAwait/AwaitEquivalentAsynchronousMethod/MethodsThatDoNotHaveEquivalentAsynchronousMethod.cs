// ReSharper disable All

using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp50.AsyncAwait.AwaitEquivalentAsynchronousMethod
{
    public class MethodsThatDoNotHaveEquivalentAsynchronousMethod
    {
        public async void InstanceMethodsDoNotHaveAsynchronousEquivalents()
        {
            var @object = new ClassWithoutAsyncEquivalents();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient();
            @object.AccessFailed();
        }

        public async void ThisMethodsDoNotHaveAsynchronousEquivalents()
        {
            SaveChanges();
            this.SaveChanges();
        }

        public async void StaticMethodsDoNotHaveAsynchronousEquivalents()
        {
            Abort();
            MethodsThatDoNotHaveEquivalentAsynchronousMethod.Abort();
        }

        public async void InstanceMethodsDoNotHaveAsynchronousEquivalentsWrongMethodParameters()
        {
            var @object = new ClassWithoutAsyncEquivalentsWrongMethodParameters();

            @object.SaveChanges(0, "");
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient(0, "");
        }

        public async void ThisMethodsHaveAsynchronousEquivalentsButCalledWithinContainingClass()
        {
            AcceptSocket();
            this.AcceptSocket();
        }

        public async void StaticMethodsHaveAsynchronousEquivalentsButCalledWithinContainingClass()
        {
            AcceptTcpClient();
            MethodsThatDoNotHaveEquivalentAsynchronousMethod.AcceptTcpClient();
        }

        public void SaveChanges() { }

        public static int Abort() => 0;

        public void AcceptSocket() { }
        public Task AcceptSocketAsync() => Task.CompletedTask;

        public static bool AcceptTcpClient() => true;
        public static Task<bool> AcceptTcpClientAsync() => Task.FromResult(true);
    }

    public class MethodsThatDoNotHaveEquivalentReturnType
    {
        public async void InstanceMethodsDoNotHaveAsynchronousEquivalents()
        {
            var @object = new ClassWithoutAsyncEquivalents();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient();
            @object.AccessFailed();
        }

        public async void InstanceMethodsDoNotHaveAsynchronousEquivalentsWrongReturnType()
        {
            var @object = new ClassWithoutAsyncEquivalentsWrongReturnType();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
        }

        public async void ThisMethodsDoNotHaveAsynchronousEquivalents()
        {
            SaveChanges();
            this.SaveChanges();
        }

        public async void StaticMethodsDoNotHaveAsynchronousEquivalents()
        {
            Abort();
            MethodsThatDoNotHaveEquivalentAsynchronousMethod.Abort();
        }

        public void SaveChanges() { }

        public static int Abort() => 0;
    }

    public class ClassWithoutAsyncEquivalents
    {
        public void SaveChanges() { }

        public int Abort() => 0;

        public void AcceptSocket() { }

        public bool AcceptTcpClient() => true;
    }

    public class ClassWithoutAsyncEquivalentsWrongReturnType
    {
        public void SaveChanges() { }
        public void SaveChangesAsync() { }

        public int Abort() => 0;
        public Task AbortAsync() => null;

        public int AcceptSocket() => 0;
        public Task<string> AcceptSocketAsync() => null;
    }

    public static class ClassWithouAsyncEquivalentsExtensions
    {
        public static bool AccessFailed(this ClassWithoutAsyncEquivalents @object) => true;
    }

    public class ClassWithoutAsyncEquivalentsWrongMethodParameters
    {
        public void SaveChanges(int i, string s) { }
        public async Task SaveChangesAsync(int i) { }

        public int Abort() => 0;
        public async Task<int> AbortAsync(int i) => 0;

        public void AcceptSocket() { }
        public Task AcceptSocketAsync(int i, CancellationToken cancellationToken) => new Task(() => { });

        public bool AcceptTcpClient(int i, string s) => true;
        public async Task<bool> AcceptTcpClientAsync(int j, string t, CancellationToken cancellationToken = default) => true;
    }
}