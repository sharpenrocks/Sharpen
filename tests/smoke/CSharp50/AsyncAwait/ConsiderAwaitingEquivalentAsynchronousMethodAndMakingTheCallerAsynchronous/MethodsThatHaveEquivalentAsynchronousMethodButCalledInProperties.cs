// ReSharper disable All

using System.Collections.Generic;

namespace CSharp50.AsyncAwait.ConsiderAwaitingEquivalentAsynchronousMethodAndMakingTheCallerAsynchronous
{
    public class MethodsThatHaveEquivalentAsynchronousMethodCalledInProperties
    {
        public int InstanceMethodsHaveAsynchronousEquivalents
        {
            get
            {
                var @object = new ClassWithAsyncEquivalents();

                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient();
                @object.AccessFailed();

                return 0;
            }
        }

        public int InstanceMethodsHaveAsynchronousEquivalentsValueTask
        {
            get
            {
                var @object = new ClassWithAsyncEquivalentsValueTask();

                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient();
                @object.AccessFailed();

                return 0;
            }
        }

        public int InstanceMethodsHaveAsynchronousEquivalentsWithDifferentReturnTypeDefinition
        {
            get
            {
                var @object = new ClassWithAsyncEquivalentsReturnTypes();

                @object.SaveChanges();
                @object.Abort();
                @object.AcceptSocket();

                return 0;
            }
        }

        public int InstanceMethodsHaveAsynchronousEquivalentsWithMethodParameters
        {
            get
            {
                var @object = new ClassWithAsyncEquivalentsMethodParameters();

                @object.SaveChanges(0, "");
                @object.Abort();
                @object.AcceptSocket();
                @object.AcceptTcpClient(0, "");

                return 0;
            }
        }

        public IEnumerable<int> InstanceMethodsHaveAsynchronousEquivalentsWithLocalFunctionYielding
        {
            get
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

                yield break;
            }
        }
    }

    public class MethodsThatHaveEquivalentAsynchronousMethodCalledInLocalFunctionsInProperties
    {
        public int InstanceMethodsHaveAsynchronousEquivalents
        {
            get
            {
                return LocalFunction();

                int LocalFunction()
                {
                    var @object = new ClassWithAsyncEquivalents();

                    @object.SaveChanges();
                    @object.Abort();
                    @object.AcceptSocket();
                    @object.AcceptTcpClient();
                    @object.AccessFailed();

                    return 0;
                }
            }
        }

        public int InstanceMethodsHaveAsynchronousEquivalentsValueTask
        {
            get
            {
                return LocalFunction();

                int LocalFunction()
                {
                    var @object = new ClassWithAsyncEquivalentsValueTask();

                    @object.SaveChanges();
                    @object.Abort();
                    @object.AcceptSocket();
                    @object.AcceptTcpClient();
                    @object.AccessFailed();

                    return 0;
                }
            }
        }

        public int InstanceMethodsHaveAsynchronousEquivalentsWithDifferentReturnTypeDefinition
        {
            get
            {
                return LocalFunction();

                int LocalFunction()
                {
                    var @object = new ClassWithAsyncEquivalentsReturnTypes();

                    @object.SaveChanges();
                    @object.Abort();
                    @object.AcceptSocket();

                    return 0;
                }
            }
        }

        public int InstanceMethodsHaveAsynchronousEquivalentsWithMethodParameters
        {
            get
            {
                return LocalFunction();

                int LocalFunction()
                {
                    var @object = new ClassWithAsyncEquivalentsMethodParameters();

                    @object.SaveChanges(0, "");
                    @object.Abort();
                    @object.AcceptSocket();
                    @object.AcceptTcpClient(0, "");

                    return 0;
                }
            }
        }

        public int InstanceMethodsHaveAsynchronousEquivalentsWithLocalFunctionYielding
        {
            get
            {
                return LocalFunction();

                int LocalFunction()
                {
                    var @object = new ClassWithAsyncEquivalents();

                    @object.SaveChanges();
                    @object.Abort();
                    @object.AcceptSocket();
                    @object.AcceptTcpClient();
                    @object.AccessFailed();

                    YieldSomething();

                    return 0;

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
}