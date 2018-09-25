// ReSharper disable All

namespace CSharp50.AsyncAwait.ConsiderAwaitingEquivalentAsynchronousMethod
{
    public class MethodsThatDoNotHaveEquivalentAsynchronousMethod
    {
        private ClassWithoutAsyncEquivalents @object = new ClassWithoutAsyncEquivalents();

        public void InstanceMethodsHaveAsynchronousEquivalents()
        {
            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient();
            @object.AccessFailed();
        }

        public void ThisMethodsHaveAsynchronousEquivalents()
        {
            SaveChanges();
            this.SaveChanges();
        }

        public void StaticMethodsHaveAsynchronousEquivalents()
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

    public static class ClassWithouAsyncEquivalentsExtensions
    {
        public static bool AccessFailed(this ClassWithoutAsyncEquivalents @object) => true;
    }
}