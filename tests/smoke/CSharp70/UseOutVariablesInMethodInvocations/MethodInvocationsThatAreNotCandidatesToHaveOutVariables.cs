// ReSharper disable All

using System;

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
            OutClass.Method(0, out int j, ref l);
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
            if (OutClass.Method(0, out int j, ref l))
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

            {
                OutClass.Method(0, out j, ref l);
            }

            j = 1;
        }

        void Invocation03()
        {
            int j;

            Func<int, bool> a = x => OutClass.Method(0, out j);

            j = 1;
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
    }
}