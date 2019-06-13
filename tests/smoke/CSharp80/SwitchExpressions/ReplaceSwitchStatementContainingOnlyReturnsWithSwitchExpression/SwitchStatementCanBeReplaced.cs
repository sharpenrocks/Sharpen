// ReSharper disable All

// Expected number of suggestions: 6

using System;

namespace CSharp80.SwitchExpressions.ReplaceSwitchStatementContainingOnlyReturnsWithSwitchExpression
{
    class SwitchStatementCanBeReplaced
    {
        private int someField;
        private static int SomeStaticField;
        private int SomeProperty { get; set; }
        private static int SomeStaticProperty { get; set; }

        int ReturnInstanceField(int i)
        {
            switch (i)
            {
                case 1: return someField;
                case 2: return int.MaxValue;
                case 3: return this.someField * 10;
                case 4: return Math.Abs(100) + Math.Min(1, 2);
                case 5: throw new Exception();
                default: return 0;
            }
        }

        int ReturnStaticField(int i)
        {
            switch (i)
            {
                case 1: return SomeStaticField;
                case 2: return int.MaxValue;
                case 3: return SwitchStatementCanBeReplaced.SomeStaticField * 10;
                case 4: return Math.Abs(100) + Math.Min(1, 2);
                case 5: throw new Exception();
                default: return 0;
            }
        }

        int ReturnInstanceProperty(int i)
        {
            switch (i)
            {
                case 1: return SomeProperty;
                case 2: return int.MaxValue;
                case 3: return this.SomeProperty * 10;
                case 4: return Math.Abs(100) + Math.Min(1, 2);
                case 5: throw new Exception();
                default: return 0;
            }
        }

        int ReturnStaticProperty(int i)
        {
            switch (i)
            {
                case 1: return SomeStaticProperty;
                case 2: return int.MaxValue;
                case 3: return SwitchStatementCanBeReplaced.SomeStaticProperty * 10;
                case 4: return Math.Abs(100) + Math.Min(1, 2);
                case 5: throw new Exception();
                default: return 0;
            }
        }

        int ReturnLocalVariable(int i)
        {
            int someVariable = 0;
            switch (i)
            {
                case 1: return someVariable;
                case 2: return int.MaxValue;
                case 3: return someVariable * 10;
                case 4: return Math.Abs(100) + Math.Min(1, 2);
                case 5: throw new Exception();
                default: return 0;
            }
        }

        int ReturnParameter(int i, int someParameter)
        {
            switch (i)
            {
                case 1: return someParameter;
                case 2: return int.MaxValue;
                case 3: return someParameter * 10;
                case 4: return Math.Abs(100) + Math.Min(1, 2);
                case 5: throw new Exception();
                default: return 0;
            }
        }
    }
}