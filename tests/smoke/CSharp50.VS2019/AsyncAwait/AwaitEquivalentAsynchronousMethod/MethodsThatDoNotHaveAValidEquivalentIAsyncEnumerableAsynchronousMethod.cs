// ReSharper disable All

using System.Collections.Generic;

namespace CSharp50.VS2019.AsyncAwait.AwaitEquivalentAsynchronousMethod
{
    public class MethodsThatDoNotHaveAValidEquivalentIAsyncEnumerableAsynchronousMethod
    {
        public async IAsyncEnumerable<int> InstanceMethodsDoNotHaveIAsyncEnumerableAsynchronousEquivalentsInvalidReturnType()
        {
            var @object = new ClassWithoutIAsyncEnumerableAsyncEquivalentsInvalidReturnType();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
            @object.Run();
            @object.AddClaim();
            @object.AddCollectionToCache();

            yield return 0;
        }
    }

    public class ClassWithoutIAsyncEnumerableAsyncEquivalentsInvalidReturnType
    {
        public class Whatever<T> { }

        public IEnumerable<object> SaveChanges() => null;
        public async IAsyncEnumerable<int> SaveChangesAsync() => null;

        public List<object> Run() => null;
        public async IAsyncEnumerable<int> RunAsync() => null;

        public ICollection<object> AddClaim() => null;
        public async IAsyncEnumerable<int> AddClaimAsync() => null;

        public Whatever<object> AddCollectionToCache() => null;
        public async IAsyncEnumerable<int> AddCollectionToCacheAsync() => null;


        public IEnumerable<int> Abort() => null;
        public async IAsyncEnumerable<object> AbortAsync() => null;

        public IEnumerable<int> AcceptSocket() => null;
        public IAsyncEnumerable<object> AcceptSocketAsync() => null;
    }
}