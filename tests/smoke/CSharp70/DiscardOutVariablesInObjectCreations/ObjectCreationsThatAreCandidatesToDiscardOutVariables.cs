// ReSharper disable All

// Expected number of suggestions: 40

using System;
using CSharp70.UseOutVariablesInMethodInvocations;
using CSharp70.UseOutVariablesInObjectCreations;

namespace CSharp70.DiscardOutVariablesInObjectCreations
{
    public class ObjectCreations
    {
        void Invocation01()
        {
            int j;
            int l = 0;
            Console.WriteLine(l);
            new OutInConstructorsClass(0, out j, ref l);
        }

        void Invocation01A()
        {
            int j;
            int l = 0;
            {
                Console.WriteLine(l);
                new OutInConstructorsClass(0, out j, ref l);
            }
        }

        void Invocation02()
        {
            int l = 0;
            int j;
            Console.WriteLine(l);
            new OutInConstructorsClass(0, out j, ref l);
        }

        void Invocation02A()
        {
            int l = 0;
            int j;
            {
                Console.WriteLine(l);
                new OutInConstructorsClass(0, out j, ref l);
            }
        }

        void Invocation03()
        {
            int j, l = 0;
            Console.WriteLine(l);
            new OutInConstructorsClass(0, out j, ref l);
        }

        void Invocation03A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                new OutInConstructorsClass(0, out j, ref l);
            }
        }

        void Invocation04()
        {
            int j, l = 0;
            Console.WriteLine(l);
            if (new OutInConstructorsClass(0, out j, ref l).Bool)
            {
                // ...
            }
        }

        void Invocation04A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                if (new OutInConstructorsClass(0, out j, ref l).Bool)
                {
                    // ...
                }
            }
        }

        void Invocation05()
        {
            int j, l = 0;
            Console.WriteLine(l);
            if (new OutInConstructorsClass(0, out j, ref l).Bool == false)
            {
                // ...
            }
        }

        void Invocation05A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                if (new OutInConstructorsClass(0, out j, ref l).Bool == false)
                {
                    // ...
                }
            }
        }

        void Invocation06()
        {
            int j, l = 0;
            Console.WriteLine(l);
            if (new OutInConstructorsClass(0, out j, ref l).Bool)
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
                if (new OutInConstructorsClass(0, out j, ref l).Bool)
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
            if (new OutInConstructorsClass(0, out j, ref l).Bool == false)
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
                if (new OutInConstructorsClass(0, out j, ref l).Bool == false)
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
            switch(new OutInConstructorsClass(0, out j, ref l).Bool)
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
                switch (new OutInConstructorsClass(0, out j, ref l).Bool)
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
                    new OutInConstructorsClass(0, out j, ref l);
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
                        new OutInConstructorsClass(0, out j, ref l);
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
            while (new OutInConstructorsClass(0, out j, ref l).Bool)
            {
                l = 0;
            }
        }

        void Invocation10A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                while (new OutInConstructorsClass(0, out j, ref l).Bool)
                {
                    l = 0;
                }
            }
        }

        void Invocation11()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (bool b = new OutInConstructorsClass(0, out j, ref l).Bool; b != true; )
            {
                l = 0;
            }
        }

        void Invocation11A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                for (bool b = new OutInConstructorsClass(0, out j, ref l).Bool; b != true;)
                {
                    l = 0;
                }
            }
        }

        void Invocation12()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for ( ; new OutInConstructorsClass(0, out j, ref l).Bool; )
            {
                l = 0;
            }
        }

        void Invocation12A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                for (; new OutInConstructorsClass(0, out j, ref l).Bool;)
                {
                    l = 0;
                }
            }
        }

        void Invocation13()
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (; new OutInConstructorsClass(0, out j, ref l).Bool; l++)
            {
                l = 0;
            }
        }

        void Invocation13A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                for (; new OutInConstructorsClass(0, out j, ref l).Bool; l++)
                {
                    l = 0;
                }
            }
        }

        void Invocation14(bool input)
        {
            int j, l = 0;
            Console.WriteLine(l);
            for (; input; new OutInConstructorsClass(0, out j, ref l), l++)
            {
                // ...
            }
        }

        void Invocation14A(bool input)
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                for (; input; new OutInConstructorsClass(0, out j, ref l), l++)
                {
                    // ...
                }
            }
        }

        void Invocation15()
        {
            int j, l = 0;
            Console.WriteLine(l);
            foreach (var o in new OutInConstructorsClass(0, out j, ref l).EnumerableMethod<object>(out l))
            {
                l = 0;
            }
        }

        void Invocation15A()
        {
            int j, l = 0;
            {
                Console.WriteLine(l);
                foreach (var o in new OutInConstructorsClass(0, out j, ref l).EnumerableMethod<object>(out l))
                {
                    l = 0;
                }
            }
        }

        void Invocation16()
        {
            int j;

            {
                new OutInConstructorsClass(0, out j);
            }
        }

        void Invocation16A()
        {
            int j;

            {
                {
                    new OutInConstructorsClass(0, out j);
                }
            }
        }

        void Invocation17()
        {
            int j;
            OutInMethodsClass.Bool(OutInMethodsClass.Bool(new OutInConstructorsClass(0, out j).Bool));
        }

        void Invocation17A()
        {
            int j;

            {
                OutInMethodsClass.Bool(OutInMethodsClass.Bool(new OutInConstructorsClass(0, out j).Bool));
            }
        }

        void Invocation18()
        {
            int j;
            Action a = () =>
            {
                new OutInConstructorsClass(0, out j);
            };
            a();
        }

        void Invocation18A()
        {
            int j;
            {
                Action a = () =>
                {
                    new OutInConstructorsClass(0, out j);
                };
                a();
            }            
        }

        void Invocation19()
        {
            int j;
            Action a = delegate()
            {
                new OutInConstructorsClass(0, out j);
            };
            a();
        }

        void Invocation19A()
        {
            int j;
            {
                Action a = delegate()
                {
                    new OutInConstructorsClass(0, out j);
                };
                a();
            }
        }

        void Invocation20()
        {
            int j;
            int l = 0;
            Console.WriteLine(l);
            new OutInConstructorsClass(new OutInConstructorsClass(0, out j, ref l).Int, out var x);
        }

        void Invocation20A()
        {
            int j;
            int l = 0;
            {
                Console.WriteLine(l);
                new OutInConstructorsClass(new OutInConstructorsClass(0, out j, ref l).Int, out var x);
            }
        }
    }
}