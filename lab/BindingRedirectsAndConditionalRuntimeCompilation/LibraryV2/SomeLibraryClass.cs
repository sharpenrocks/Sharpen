using System;
using System.Runtime.CompilerServices;

namespace Library
{
    public class SomeLibraryClass
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void FirstMethod(int n)
        {
            Console.WriteLine($"Library: {typeof(SomeLibraryClass).AssemblyQualifiedName}");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("This is some dummy code that does something.");
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SecondMethodThatDoesNotExistInTheFirstVersion(int n)
        {
            Console.WriteLine($"Calling {nameof(SecondMethodThatDoesNotExistInTheFirstVersion)}");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("This is some dummy code that does something.");
            }
        }
    }
}
