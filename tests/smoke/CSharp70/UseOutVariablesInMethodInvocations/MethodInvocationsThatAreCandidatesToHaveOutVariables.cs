// ReSharper disable All

// Expected number of suggestions: 13

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
            int j, l = 0;
            Console.WriteLine(l);
            switch(OutClass.Method(0, out j, ref l))
            {
                case true: j = 0;
                    break;
                case false: j = 0;
                    break;
                default: j = 0;
                    break;
            }
            Console.WriteLine(j);
        }

        void Invocation07()
        {
            int j, l = 0;
            Console.WriteLine(l);
            while (OutClass.Method(0, out j, ref l))
            {
                j = 0;
            }
        }

        void Invocation08()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (bool b = OutClass.Method(0, out j, ref l); b != true; )
            {
                j = 0;
            }
        }

        void Invocation09()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for ( ; OutClass.Method(0, out j, ref l); )
            {
                j = 0;
            }
        }

        void Invocation10()
        {
            int j, l = 0;
            Console.WriteLine(l);
            foreach (var o in OutClass.EnumerableMethod<object>(out j))
            {
                j = 0;
            }
        }

        void Invocation11()
        {
            int j;

            {
                OutClass.Method(0, out j);
                Console.WriteLine(j);
            }
        }

        void Invocation12()
        {
            int j;

            {
                {
                    OutClass.Method(0, out j);
                    Console.WriteLine(j);
                }
            }
        }

        void Invocation13()
        {
            int j;
            OutClass.Bool(OutClass.Bool(OutClass.Method(0, out j)));
            Console.WriteLine(j);
        }
    }
}