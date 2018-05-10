// ReSharper disable All

using System;
using System.Linq;

namespace CSharp70.UseOutVariablesInMethodInvocations
{
    public class MethodInvocationsThatAlreadyHaveOutVariables
    {
        void Invocation01()
        {
            int l = 0;
            OutClass.Method(0, out int j, ref l);
        }

        void Invocation02()
        {
            int l = 0;
            OutClass.Method(0, out var j, ref l);
        }

        void Invocation03()
        {
            int l = 0;
            if (OutClass.Method(0, out int j, ref l))
            {
                // ...
            }
        }

        void Invocation04()
        {
            int l = 0;
            if (OutClass.Method(0, out var j, ref l))
            {
                // ...
            }
        }

        void Invocation05()
        {
            int l = 0;
            if (OutClass.Method(0, out int j, ref l))
            {
                // ...
            }
            else
            {
                j = 1;
            }
        }

        void Invocation06()
        {
            int l = 0;
            if (OutClass.Method(0, out var j, ref l))
            {
                // ...
            }
            else
            {
                j = 1;
            }
        }
    }

    public class OutVariablesThatAreUsedOutOfTheScopeOfTheMethodCall
    {
        void Invocation01(bool input)
        {
            int j, l = 0;
            if (input)
            {
                OutClass.Method(0, out j, ref l);
            }
            else
            {
                j = 1;
            }
        }

        void Invocation02(bool input)
        {
            int j, l = 0;
            Action a;
            if (input)
                a = () => OutClass.Method(0, out j, ref l);

            j = 1;
        }

        void Invocation03()
        {
            int j, l = 0;
            Console.WriteLine(l);
            switch (l)
            {
                case 1:
                {
                    OutClass.Method(0, out j, ref l);
                    j = 0;
                    break;
                }
                case 2:
                    j = 0;
                    break;
                default:
                    j = 0;
                    break;
            }
        }

        void Invocation04(bool input)
        {
            int j, l = 0;

            {
                OutClass.Method(0, out j, ref l);
            }

            j = 1;
        }

        void Invocation05()
        {
            int j;

            Func<int, bool> a = x => OutClass.Method(0, out j);

            j = 1;
        }

        void Invocation06()
        {
            int j;
            Action a = () =>
            {
                { OutClass.Method(0, out j); }
                j++;
            };
            a();
        }

        void Invocation07()
        {
            int j, l = 0;
            Console.WriteLine(l);
            while (OutClass.Method(0, out j, ref l))
            {
                j = 0;
            }
            Console.WriteLine(j);
        }

        void Invocation08()
        {
            int j, l = 0;
            Console.WriteLine(l);
            while (OutClass.Method(0, out j, ref l) == false)
            {
                j = 0;
            }
            Console.WriteLine(j);
        }

        void Invocation09(bool input)
        {
            int j, l = 0;
            Console.WriteLine(l);
            Action a;
            while (input)
                a = () => OutClass.Method(0, out j, ref l);
        }

        void Invocation10(bool input)
        {
            int j, l = 0;
            Console.WriteLine(l);
            while (input)
            {
                {
                    OutClass.Method(0, out j, ref l);
                }

                j = 0;
            }
        }

        void Invocation11()
        {
            int j, l = 0;
            Console.WriteLine(l);
            do
            {
                l = 0;
            }
            while (OutClass.Method(0, out j, ref l));
            Console.WriteLine(j);
        }

        void Invocation12()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (bool b = OutClass.Method(0, out j, ref l); b != true;)
            {
                j = 0;
            }
            Console.WriteLine(j);
        }

        void Invocation13()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (; OutClass.Method(0, out j, ref l); )
            {
                j = 0;
            }
            Console.WriteLine(j);
        }

        void Invocation14()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (; OutClass.Method(0, out j, ref l); j++)
            {
                j = 0;
            }
            Console.WriteLine(j);
        }

        void Invocation15()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (bool b = false; b != true;)
            {
                {
                    OutClass.Method(0, out j, ref l);
                }

                j = 0;
            }
        }

        void Invocation16(bool input)
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (; input; OutClass.Method(0, out j, ref l))
            {
                j = 0;
            }
        }

        void Invocation17()
        {
            int j, l = 0;
            Console.WriteLine(l);
            foreach (var o in OutClass.EnumerableMethod<object>(out j))
            {
                j = 0;
            }
            Console.WriteLine(j);
        }

        void Invocation18()
        {
            int j, l = 0;
            Console.WriteLine(l);
            foreach (var o in Enumerable.Empty<object>())
            {
                {
                    OutClass.EnumerableMethod<object>(out j);
                }

                j = 0;
            }
        }
    }

    public class OutVariablesThatAreNotDeclaredLocally
    {
        void Invocation01(out int j, ref int l)
        {
            OutClass.Method(0, out j, ref l);
        }

        void Invocation02(int j, ref int l)
        {
            OutClass.Method(0, out j, ref l);
        }

        void Invocation03()
        {
            Func<int, bool> a = j => OutClass.Method(0, out j);
        }
    }

    public class OutVariablesThatAreDeclaredInPatternMatching
    {
        void Invocation01(object o)
        {
            if (o is int j)
            {
                OutClass.Method(0, out j);
            }
        }

        void Invocation02(object o)
        {
            switch (o)
            {
                case int j:
                    OutClass.Method(0, out j);
                    break;
            }
        }
    }

    public class OutVariablesThatAreUsedBeforePassingAsOutToTheMethod
    {
        void Invocation01()
        {
            int j = 0;
            OutClass.Method(0, out j);
        }

        void Invocation02()
        {
            int j;
            j = 5;
            OutClass.Method(0, out j);
        }

        void Invocation03()
        {
            int j = 0;
            Console.WriteLine(j);
            OutClass.Method(0, out j);
        }

        void Invocation04()
        {
            int j;
            OutClass.Method(0, out j); // This one can be inlined.
            OutClass.Method(0, out j);
        }

        void Invocation05()
        {
            int j;
            j = 5;
            {
                OutClass.Method(0, out j);
            }
        }

        void Invocation06()
        {
            int j;
            j = 5;
            {
                {
                    OutClass.Method(0, out j);
                }
            }
        }

        void Invocation07()
        {
            int j;
            {
                j = 5;
                OutClass.Method(0, out j);
            }
        }

        void Invocation08()
        {
            int j;
            {
                {
                    j = 5;
                    OutClass.Method(0, out j);
                }
            }
        }

        void Invocation09()
        {
            int j;
            OutClass.Method(out j, out j);
        }
    }
}