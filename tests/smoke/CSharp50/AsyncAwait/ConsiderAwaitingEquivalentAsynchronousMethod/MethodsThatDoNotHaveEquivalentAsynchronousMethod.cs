// ReSharper disable All

using System.Threading.Tasks;

namespace CSharp50.AsyncAwait.ConsiderAwaitingEquivalentAsynchronousMethod
{
    public class MethodsThatDoNotHaveEquivalentAsynchronousMethod
    {
        public void InstanceMethodsDoNotHaveAsynchronousEquivalents()
        {
            var @object = new ClassWithoutAsyncEquivalents();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient();
            @object.AccessFailed();
        }

        public void ThisMethodsDoNotHaveAsynchronousEquivalents()
        {
            SaveChanges();
            this.SaveChanges();
        }

        public void StaticMethodsDoNotHaveAsynchronousEquivalents()
        {
            Abort();
            MethodsThatDoNotHaveEquivalentAsynchronousMethod.Abort();
        }

        public void SaveChanges() { }

        public static int Abort() => 0;
    }

    public class MethodsThatDoNotHaveEquivalentReturnType
    {
        public void InstanceMethodsDoNotHaveAsynchronousEquivalents()
        {
            var @object = new ClassWithoutAsyncEquivalents();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient();
            @object.AccessFailed();
        }

        public void InstanceMethodsDoNotHaveAsynchronousEquivalentsWrongReturnType()
        {
            var @object = new ClassWithoutAsyncEquivalentsWrongReturnType();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
        }

        public void ThisMethodsDoNotHaveAsynchronousEquivalents()
        {
            SaveChanges();
            this.SaveChanges();
        }

        public void StaticMethodsDoNotHaveAsynchronousEquivalents()
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
}