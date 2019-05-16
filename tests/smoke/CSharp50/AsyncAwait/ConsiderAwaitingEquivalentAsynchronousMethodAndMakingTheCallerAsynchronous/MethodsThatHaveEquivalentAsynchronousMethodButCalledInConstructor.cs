// ReSharper disable All

using System.Collections.Generic;

namespace CSharp50.AsyncAwait.ConsiderAwaitingEquivalentAsynchronousMethodAndMakingTheCallerAsynchronous
{
    public class MethodsThatHaveEquivalentAsynchronousMethodCalledInConstructors
    {
        public MethodsThatHaveEquivalentAsynchronousMethodCalledInConstructors()
        {
            var @object = new ClassWithAsyncEquivalents();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient();
            @object.AccessFailed();
        }

        public MethodsThatHaveEquivalentAsynchronousMethodCalledInConstructors(int i)
        {
            var @object = new ClassWithAsyncEquivalentsValueTask();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient();
            @object.AccessFailed();
        }

        public MethodsThatHaveEquivalentAsynchronousMethodCalledInConstructors(double d)
        {
            var @object = new ClassWithAsyncEquivalentsReturnTypes();

            @object.SaveChanges();
            @object.Abort();
            @object.AcceptSocket();
        }

        public MethodsThatHaveEquivalentAsynchronousMethodCalledInConstructors(string s)
        {
            var @object = new ClassWithAsyncEquivalentsMethodParameters();

            @object.SaveChanges(0, "");
            @object.Abort();
            @object.AcceptSocket();
            @object.AcceptTcpClient(0, "");
        }

        public MethodsThatHaveEquivalentAsynchronousMethodCalledInConstructors(decimal d)
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

    public class MethodsThatHaveEquivalentAsynchronousMethodCalledInLocalFunctionsInConstructors
    {
        public MethodsThatHaveEquivalentAsynchronousMethodCalledInLocalFunctionsInConstructors()
        {
            LocalFunction();

            void LocalFunction()
            {
                var @object = new ClassWithAsyncEquivalents();

                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient();
                @object.AccessFailed();
            }
        }

        public MethodsThatHaveEquivalentAsynchronousMethodCalledInLocalFunctionsInConstructors(int i)
        {
            LocalFunction();

            void LocalFunction()
            {
                var @object = new ClassWithAsyncEquivalentsValueTask();

                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient();
                @object.AccessFailed();
            }
        }

        public MethodsThatHaveEquivalentAsynchronousMethodCalledInLocalFunctionsInConstructors(double d)
        {
            LocalFunction();

            void LocalFunction()
            {
                var @object = new ClassWithAsyncEquivalentsReturnTypes();

                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();
            }
        }

        public MethodsThatHaveEquivalentAsynchronousMethodCalledInLocalFunctionsInConstructors(string s)
        {
            LocalFunction();

            void LocalFunction()
            {
                var @object = new ClassWithAsyncEquivalentsMethodParameters();

                @object.SaveChanges(0, "");
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient(0, "");
            }
        }

        public MethodsThatHaveEquivalentAsynchronousMethodCalledInLocalFunctionsInConstructors(decimal d)
        {
            LocalFunction();

            void LocalFunction()
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
}