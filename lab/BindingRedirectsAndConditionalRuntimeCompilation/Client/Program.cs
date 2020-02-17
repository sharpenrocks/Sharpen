using 
using System;
using System.Runtime.CompilerServices;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Dispatcher.DoSomething(0);
        }
    }

    static class Dispatcher
    {
        private static readonly Version version1_0_0_0 = new Version(1, 0, 0, 0);
        private static readonly Version version2_0_0_0 = new Version(2, 0, 0, 0);

        public static void DoSomething(int n)
        {
            var version = typeof(SomeLibraryClass).Assembly.GetName().Version;

            if (version >= version2_0_0_0)
            {
                DoSomething2_0_0_0(n);
            }
            else
            {
                DoSomething1_0_0_0(n);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void DoSomething1_0_0_0(int n)
        {
            SomeLibraryClass someLibraryObject = new SomeLibraryClass();

            someLibraryObject.FirstMethod(n);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void DoSomething2_0_0_0(int n)
        {
            SomeLibraryClass someLibraryObject = new SomeLibraryClass();

            someLibraryObject.FirstMethod(n);
            someLibraryObject.SecondMethodThatDoesNotExistInTheFirstVersion(n);
        }
    }
}
