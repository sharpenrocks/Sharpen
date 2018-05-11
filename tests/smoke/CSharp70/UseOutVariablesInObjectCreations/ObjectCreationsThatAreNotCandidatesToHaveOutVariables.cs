// ReSharper disable All

using System;
using System.Linq;
using CSharp70.UseOutVariablesInMethodInvocations;

namespace CSharp70.UseOutVariablesInObjectCreations
{
    public class ObjectCreationsThatAlreadyHaveOutVariables
    {
        void Invocation01()
        {
            int l = 0;
            new OutInConstructorsClass(0, out int j, ref l);
        }

        void Invocation02()
        {
            int l = 0;
            new OutInConstructorsClass(0, out var j, ref l);
        }

        void Invocation03()
        {
            int l = 0;
            if (new OutInConstructorsClass(0, out int j, ref l).Bool)
            {
                // ...
            }
        }

        void Invocation04()
        {
            int l = 0;
            if (new OutInConstructorsClass(0, out var j, ref l).Bool)
            {
                // ...
            }
        }

        void Invocation05()
        {
            int l = 0;
            if (new OutInConstructorsClass(0, out int j, ref l).Bool)
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
            if (new OutInConstructorsClass(0, out var j, ref l).Bool)
            {
                // ...
            }
            else
            {
                j = 1;
            }
        }
    }

    public class OutVariablesThatAreUsedOutOfTheScopeOfTheObjectCreation
    {
        void Invocation01(bool input)
        {
            int j, l = 0;
            if (input)
            {
                new OutInConstructorsClass(0, out j, ref l);
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
                a = () => new OutInConstructorsClass(0, out j, ref l);

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
                    new OutInConstructorsClass(0, out j, ref l);
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
                new OutInConstructorsClass(0, out j, ref l);
            }

            j = 1;
        }

        void Invocation05()
        {
            int j;

            Func<int, bool> a = x => new OutInConstructorsClass(0, out j).Bool;

            j = 1;
        }

        void Invocation06()
        {
            int j;
            Action a = () =>
            {
                { new OutInConstructorsClass(0, out j); }
                j++;
            };
            a();
        }

        void Invocation07()
        {
            int j, l = 0;
            Console.WriteLine(l);
            while (new OutInConstructorsClass(0, out j, ref l).Bool)
            {
                j = 0;
            }
            Console.WriteLine(j);
        }

        void Invocation08()
        {
            int j, l = 0;
            Console.WriteLine(l);
            while (new OutInConstructorsClass(0, out j, ref l).Bool == false)
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
                a = () => new OutInConstructorsClass(0, out j, ref l);
        }

        void Invocation10(bool input)
        {
            int j, l = 0;
            Console.WriteLine(l);
            while (input)
            {
                {
                    new OutInConstructorsClass(0, out j, ref l);
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
            while (new OutInConstructorsClass(0, out j, ref l).Bool);
            Console.WriteLine(j);
        }

        void Invocation12()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (bool b = new OutInConstructorsClass(0, out j, ref l).Bool; b != true;)
            {
                j = 0;
            }
            Console.WriteLine(j);
        }

        void Invocation13()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (; new OutInConstructorsClass(0, out j, ref l).Bool; )
            {
                j = 0;
            }
            Console.WriteLine(j);
        }

        void Invocation14()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (; new OutInConstructorsClass(0, out j, ref l).Bool; j++)
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
                    new OutInConstructorsClass(0, out j, ref l);
                }

                j = 0;
            }
        }

        void Invocation16(bool input)
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (; input; new OutInConstructorsClass(0, out j, ref l))
            {
                j = 0;
            }
        }

        void Invocation17()
        {
            int j, l = 0;
            Console.WriteLine(l);
            foreach (var o in new OutInConstructorsClass(0, out j, ref l).EnumerableMethod<object>(out j))
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
                    new OutInConstructorsClass(0, out j, ref l).EnumerableMethod<object>(out j);
                }

                j = 0;
            }
        }
    }

    public class OutVariablesThatAreNotDeclaredLocally
    {
        void Invocation01(out int j, ref int l)
        {
            new OutInConstructorsClass(0, out j, ref l);
        }

        void Invocation02(int j, ref int l)
        {
            new OutInConstructorsClass(0, out j, ref l);
        }

        void Invocation03()
        {
            Func<int, bool> a = j => new OutInConstructorsClass(0, out j).Bool;
        }
    }

    public class OutVariablesThatAreDeclaredInPatternMatching
    {
        void Invocation01(object o)
        {
            if (o is int j)
            {
                new OutInConstructorsClass(0, out j);
            }
        }

        void Invocation02(object o)
        {
            switch (o)
            {
                case int j:
                    new OutInConstructorsClass(0, out j);
                    break;
            }
        }
    }

    public class OutVariablesThatAreUsedBeforePassingAsOutToTheConstructor
    {
        void Invocation01()
        {
            int j = 0;
            new OutInConstructorsClass(0, out j);
        }

        void Invocation02()
        {
            int j;
            j = 5;
            new OutInConstructorsClass(0, out j);
        }

        void Invocation03()
        {
            int j = 0;
            Console.WriteLine(j);
            new OutInConstructorsClass(0, out j);
        }

        void Invocation04()
        {
            int j;
            new OutInConstructorsClass(0, out j); // This one can be inlined.
            new OutInConstructorsClass(0, out j);
        }

        void Invocation05()
        {
            int j;
            j = 5;
            {
                new OutInConstructorsClass(0, out j);
            }
        }

        void Invocation06()
        {
            int j;
            j = 5;
            {
                {
                    new OutInConstructorsClass(0, out j);
                }
            }
        }

        void Invocation07()
        {
            int j;
            {
                j = 5;
                new OutInConstructorsClass(0, out j);
            }
        }

        void Invocation08()
        {
            int j;
            {
                {
                    j = 5;
                    new OutInConstructorsClass(0, out j);
                }
            }
        }

        void Invocation09()
        {
            int j;
            new OutInConstructorsClass(out j, out j);
        }
    }

    public class OutVariablesThatAreUsedInMethodInvocationsInsideOfConstructorCalls
    {
        void Invocation01()
        {
            int j;
            new OutInConstructorsClass(OutInMethodsClass.MethodInt(0, out j));
        }
    }
}