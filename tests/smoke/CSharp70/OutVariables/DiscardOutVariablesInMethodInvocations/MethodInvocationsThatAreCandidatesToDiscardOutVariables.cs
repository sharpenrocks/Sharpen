// ReSharper disable All

// Expected number of suggestions: 40

using System;
using CSharp70.OutVariables.UseOutVariablesInMethodInvocations;
using CSharp70.OutVariables.UseOutVariablesInObjectCreations;

namespace CSharp70.OutVariables.DiscardOutVariablesInMethodInvocations
{
    public class MethodInvocationsThatAreCandidatesToDiscardOutVariables
    {
        void Invocation01()
        {
            int j;
            int l = 0;
            Console.WriteLine(l);
            OutInMethodsClass.Method(0, out j, ref l);
        }

        void Invocation01A()
        {
            int j;
            int l = 0;
            {
                Console.WriteLine(l);
                OutInMethodsClass.Method(0, out j, ref l);
            }
        }

        void Invocation02()
        {
            int l = 0;
            int j;
            Console.WriteLine(l);
            OutInMethodsClass.Method(0, out j, ref l);
        }

        void Invocation02A()
        {
            int l = 0;
            int j;
            {
                Console.WriteLine(l);
                OutInMethodsClass.Method(0, out j, ref l);
            }
        }

        void Invocation03()
        {
            int j, l = 0;
            Console.WriteLine(l);
            OutInMethodsClass.Method(0, out j, ref l);
        }

        void Invocation03A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                OutInMethodsClass.Method(0, out j, ref l);
            }
        }

        void Invocation04()
        {
            int j, l = 0;
            Console.WriteLine(l);
            if (OutInMethodsClass.Method(0, out j, ref l))
            {
                // ...
            }
        }

        void Invocation04A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                if (OutInMethodsClass.Method(0, out j, ref l))
                {
                    // ...
                }
            }
        }

        void Invocation05()
        {
            int j, l = 0;
            Console.WriteLine(l);
            if (OutInMethodsClass.Method(0, out j, ref l) == false)
            {
                // ...
            }
        }

        void Invocation05A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                if (OutInMethodsClass.Method(0, out j, ref l) == false)
                {
                    // ...
                }
            }
        }

        void Invocation06()
        {
            int j, l = 0;
            Console.WriteLine(l);
            if (OutInMethodsClass.Method(0, out j, ref l))
            {
                // ...
            }
            else
            {
                l = 1;
            }
        }

        void Invocation06A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                if (OutInMethodsClass.Method(0, out j, ref l))
                {
                    // ...
                }
                else
                {
                    l = 1;
                }
            }
        }

        void Invocation07()
        {
            int j, l = 0;
            Console.WriteLine(l);
            if (OutInMethodsClass.Method(0, out j, ref l) == false)
            {
                // ...
            }
            else
            {
                l = 1;
            }
        }

        void Invocation07A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                if (OutInMethodsClass.Method(0, out j, ref l) == false)
                {
                    // ...
                }
                else
                {
                    l = 1;
                }
            }
        }

        void Invocation08()
        {
            int j, l = 0;
            Console.WriteLine(l);
            switch(OutInMethodsClass.Method(0, out j, ref l))
            {
                case true: l = 0;
                    break;
                case false: l = 0;
                    break;
                default: l = 0;
                    break;
            }
        }

        void Invocation08A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                switch (OutInMethodsClass.Method(0, out j, ref l))
                {
                    case true:
                        l = 0;
                        break;
                    case false:
                        l = 0;
                        break;
                    default:
                        l = 0;
                        break;
                }
            }
        }

        void Invocation09()
        {
            int j, l = 0;
            Console.WriteLine(l);
            switch (l)
            {
                case 1:
                    OutInMethodsClass.Method(0, out j, ref l);
                    l = 0;
                    break;
                case 2:
                    l = 0;
                    break;
                default:
                    l = 0;
                    break;
            }
        }

        void Invocation09A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                switch (l)
                {
                    case 1:
                        OutInMethodsClass.Method(0, out j, ref l);
                        l = 0;
                        break;
                    case 2:
                        l = 0;
                        break;
                    default:
                        l = 0;
                        break;
                }
            }
        }

        void Invocation10()
        {
            int j, l = 0;
            Console.WriteLine(l);
            while (OutInMethodsClass.Method(0, out j, ref l))
            {
                l = 0;
            }
        }

        void Invocation10A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                while (OutInMethodsClass.Method(0, out j, ref l))
                {
                    l = 0;
                }
            }
        }

        void Invocation11()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (bool b = OutInMethodsClass.Method(0, out j, ref l); b != true; )
            {
                l = 0;
            }
        }

        void Invocation11A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                for (bool b = OutInMethodsClass.Method(0, out j, ref l); b != true;)
                {
                    l = 0;
                }
            }
        }

        void Invocation12()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for ( ; OutInMethodsClass.Method(0, out j, ref l); )
            {
                l = 0;
            }
        }

        void Invocation12A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                for (; OutInMethodsClass.Method(0, out j, ref l);)
                {
                    l = 0;
                }
            }
        }

        void Invocation13()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (; OutInMethodsClass.Method(0, out j, ref l); l++)
            {
                l = 0;
            }
        }

        void Invocation13A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                for (; OutInMethodsClass.Method(0, out j, ref l); l++)
                {
                    l = 0;
                }
            }
        }

        void Invocation14(bool input)
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (; input; OutInMethodsClass.Method(0, out j, ref l), l++)
            {
                // ...
            }
        }

        void Invocation14A(bool input)
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                for (; input; OutInMethodsClass.Method(0, out j, ref l), l++)
                {
                    // ...
                }
            }
        }

        void Invocation15()
        {
            int j, l = 0;
            Console.WriteLine(l);
            foreach (var o in OutInMethodsClass.EnumerableMethod<object>(out j))
            {
                l = 0;
            }
        }

        void Invocation15A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                foreach (var o in OutInMethodsClass.EnumerableMethod<object>(out j))
                {
                    l = 0;
                }
            }
        }

        void Invocation16()
        {
            int j;

            {
                OutInMethodsClass.Method(0, out j);
            }
        }

        void Invocation16A()
        {
            int j;

            {
                {
                    OutInMethodsClass.Method(0, out j);
                }
            }
        }

        void Invocation17()
        {
            int j;
            OutInMethodsClass.Bool(OutInMethodsClass.Bool(OutInMethodsClass.Method(0, out j)));
        }

        void Invocation17A()
        {
            int j;

            {
                OutInMethodsClass.Bool(OutInMethodsClass.Bool(OutInMethodsClass.Method(0, out j)));
            }
        }

        void Invocation18()
        {
            int j;
            Action a = () =>
            {
                OutInMethodsClass.Method(0, out j);
            };
            a();
        }

        void Invocation18A()
        {
            int j;
            {
                Action a = () =>
                {
                    OutInMethodsClass.Method(0, out j);
                };
                a();
            }            
        }

        void Invocation19()
        {
            int j;
            Action a = delegate()
            {
                OutInMethodsClass.Method(0, out j);
            };
            a();
        }

        void Invocation19A()
        {
            int j;
            {
                Action a = delegate()
                {
                    OutInMethodsClass.Method(0, out j);
                };
                a();
            }
        }

        void Invocation20()
        {
            int j;
            int l = 0;
            Console.WriteLine(l);
            new OutInConstructorsClass(OutInMethodsClass.MethodInt(0, out j, ref l), out var x);
        }

        void Invocation20A()
        {
            int j;
            int l = 0;
            {
                Console.WriteLine(l);
                new OutInConstructorsClass(OutInMethodsClass.MethodInt(0, out j, ref l), out var x);
            }
        }
    }
}