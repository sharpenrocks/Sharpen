// ReSharper disable All

using System.Collections.Generic;

namespace CSharp50.AsyncAwait.ConsiderAwaitingEquivalentAsynchronousMethod
{
    public class MethodsThatHaveEquivalentAsynchronousMethodButYieldEnumerable
    {
        public IEnumerable<int> InstanceMethodsHaveAsynchronousEquivalents()
        {
            var @object = new ClassWithAsyncEquivalents();

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

        public IEnumerable<int> InstanceMethodsHaveAsynchronousEquivalentsValueTask()
        {
            var @object = new ClassWithAsyncEquivalentsValueTask();

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

        public IEnumerable<int> InstanceMethodsHaveAsynchronousEquivalentsWithDifferentReturnTypeDefinition()
        {
            var @object = new ClassWithAsyncEquivalentsReturnTypes();

            for (int i = 0; i < 100; i++)
            {
                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();

                yield return i;
            }

            yield break;
        }

        public IEnumerable<int> InstanceMethodsHaveAsynchronousEquivalentsWithMethodParameters()
        {
            var @object = new ClassWithAsyncEquivalentsMethodParameters();

            for (int i = 0; i < 100; i++)
            {
                @object.SaveChanges(0, "");
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient(0, "");

                yield return i;
            }

            yield break;
        }
    }
}