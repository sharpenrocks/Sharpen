// ReSharper disable All

// Expected number of suggestions: 6

using System;

namespace CSharp80.SwitchExpressions.ReplaceSwitchStatementContainingOnlyAssignmentsWithSwitchExpression
{
    class SwitchStatementCanBeReplaced
    {
        private int someField;
        private static int SomeStaticField;
        private int SomeProperty { get; set; }
        private static int SomeStaticProperty { get; set; }

        void AssignmentsToInstanceField(int i)
        {
            switch (i)
            {
                case 1: someField = 11; break;
                case 2: this.someField = int.MaxValue; break;
                case 3: someField = someField * 10; break;
                case 4: this.someField = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: someField = 0; break;
            }
        }

        void AssignmentsToStaticField(int i)
        {
            switch (i)
            {
                case 1: SomeStaticField = 11; break;
                case 2: SwitchStatementCanBeReplaced.SomeStaticField = int.MaxValue; break;
                case 3: SomeStaticField = SomeStaticField * 10; break;
                case 4: SwitchStatementCanBeReplaced.SomeStaticField = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: SomeStaticField = 0; break;
            }
        }

        void AssignmentsToInstanceProperty(int i)
        {
            switch (i)
            {
                case 1: SomeProperty = 11; break;
                case 2: this.SomeProperty = int.MaxValue; break;
                case 3: SomeProperty = SomeProperty * 10; break;
                case 4: this.SomeProperty = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: SomeProperty = 0; break;
            }
        }

        void AssignmentsToStaticProperty(int i)
        {
            switch (i)
            {
                case 1: SomeStaticProperty = 11; break;
                case 2: SwitchStatementCanBeReplaced.SomeStaticProperty = int.MaxValue; break;
                case 3: SomeStaticProperty = SomeStaticProperty * 10; break;
                case 4: SwitchStatementCanBeReplaced.SomeStaticProperty = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: SomeStaticProperty = 0; break;
            }
        }

        void AssignmentsToLocalVariable(int i)
        {
            int someVariable = 0;
            switch (i)
            {
                case 1: someVariable = 11; break;
                case 2: someVariable = int.MaxValue; break;
                case 3: someVariable = someVariable * 10; break;
                case 4: someVariable = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: someVariable = 0; break;
            }
        }

        void AssignmentsToParameter(int i, int someParameter)
        {
            switch (i)
            {
                case 1: someParameter = 11; break;
                case 2: someParameter = int.MaxValue; break;
                case 3: someParameter = someParameter * 10; break;
                case 4: someParameter = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: someParameter = 0; break;
            }
        }
    }
}