// ReSharper disable All

// Expected number of suggestions: 11

using System.Collections.Generic;

namespace CSharp50.VS2019.AsyncAwait.AwaitEquivalentAsynchronousMethod
{
    public class MethodsThatHaveEquivalentIAsyncEnumerableAsynchronousMethod
    {
        public async IAsyncEnumerable<int> InstanceMethodsHaveAsynchronousEquivalents()
        {
            var @object = new ClassWithIAsyncEnumerableAsyncEquivalents();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient();
            @object.AccessFailed();
            @object.Run();
            @object.AddClaim();
            @object.AddCollectionToCache();

            yield return 0;
        }

        public async IAsyncEnumerable<int> InstanceMethodsHaveAsynchronousEquivalentsWithDifferentReturnTypeDefinition()
        {
            var @object = new ClassWithIAsyncEnumerableAsyncEquivalentsReturnTypes();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();

            yield return 0;
        }
    }

    public class ClassWithIAsyncEnumerableAsyncEquivalents
    {
        public class Whatever<T> { }

        public IEnumerable<object> SaveChanges() => null;
        public async IAsyncEnumerable<object> SaveChangesAsync() => null;

        public List<object> Run() => null;
        public async IAsyncEnumerable<object> RunAsync() => null;

        public ICollection<object> AddClaim() => null;
        public async IAsyncEnumerable<object> AddClaimAsync() => null;

        public Whatever<object> AddCollectionToCache() => null;
        public async IAsyncEnumerable<object> AddCollectionToCacheAsync() => null;


        public IEnumerable<int> Abort() => null;
        public async IAsyncEnumerable<int> AbortAsync() => null;

        public IEnumerable<int> AcceptSocket() => null;
        public IAsyncEnumerable<int> AcceptSocketAsync() => null;

        public IEnumerable<bool> AcceptTcpClient() => null;

        public IAsyncEnumerable<bool> AccessFailedAsync() => null;
    }

    public static class ClassWithIAsyncEnumerableAsyncEquivalentsExtensions
    {
        public static IAsyncEnumerable<bool> AcceptTcpClientAsync(this ClassWithIAsyncEnumerableAsyncEquivalents @object) => null;

        public static IEnumerable<bool> AccessFailed(this ClassWithIAsyncEnumerableAsyncEquivalents @object) => null;
    }

    public class ClassWithIAsyncEnumerableAsyncEquivalentsReturnTypes
    {
        public IEnumerable<object> SaveChanges() => null;
        public async IAsyncEnumerable<System.Object> SaveChangesAsync() => null;

        public IEnumerable<System.Int32> Abort() => null;
        public async IAsyncEnumerable<int> AbortAsync() => null;

        public IEnumerable<int> AcceptSocket() => null;
        public IAsyncEnumerable<System.Int32> AcceptSocketAsync() => null;
    }
}