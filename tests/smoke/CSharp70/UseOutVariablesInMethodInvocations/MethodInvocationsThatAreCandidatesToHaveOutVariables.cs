// ReSharper disable All

// Expected number of suggestions: 7

using System;

namespace CSharp70.UseOutVariablesInMethodInvocations
{
    public class MethodInvocationsThatAreCandidatesToHaveOutVariables
    {
        void Invocation01()
        {
            int j;
            int l = 0;
            Console.WriteLine(l);
            OutClass.Method(0, out j, ref l);
            Console.WriteLine(j);
        }

        void Invocation02()
        {
            int l = 0;
            int j;
            Console.WriteLine(l);
            OutClass.Method(0, out j, ref l);
            Console.WriteLine(j);
        }

        void Invocation03()
        {
            int j, l = 0;
            Console.WriteLine(l);
            OutClass.Method(0, out j, ref l);
            Console.WriteLine(j);
        }

        void Invocation04()
        {
            int j, l = 0;
            Console.WriteLine(l);
            if (OutClass.Method(0, out j, ref l))
            {
                // ...
            }
            Console.WriteLine(j);
        }

        void Invocation05()
        {
            int j, l = 0;
            Console.WriteLine(l);
            if (OutClass.Method(0, out j, ref l))
            {
                // ...
            }
            else
            {
                j = 1;
            }
            Console.WriteLine(j);
        }

        void Invocation06()
        {
            int j;

            {
                OutClass.Method(0, out j);
            }

            Console.WriteLine(j);
        }

        void Invocation07()
        {
            int j;

            {
                {
                    OutClass.Method(0, out j);
                }
            }

            Console.WriteLine(j);
        }
    }
}