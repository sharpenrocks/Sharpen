// ReSharper disable All

using System;

namespace CSharp80.SwitchExpressions.ReplaceSwitchStatementContainingOnlyAssignmentsWithSwitchExpression
{
    class SwitchStatementCannotBeReplacedMissingDefault
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
            }
        }

        void AssignmentsToStaticField(int i)
        {
            switch (i)
            {
                case 1: SomeStaticField = 11; break;
                case 2: SwitchStatementCannotBeReplacedMissingDefault.SomeStaticField = int.MaxValue; break;
                case 3: SomeStaticField = SomeStaticField * 10; break;
                case 4: SwitchStatementCannotBeReplacedMissingDefault.SomeStaticField = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
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
            }
        }

        void AssignmentsToStaticProperty(int i)
        {
            switch (i)
            {
                case 1: SomeStaticProperty = 11; break;
                case 2: SwitchStatementCannotBeReplacedMissingDefault.SomeStaticProperty = int.MaxValue; break;
                case 3: SomeStaticProperty = SomeStaticProperty * 10; break;
                case 4: SwitchStatementCannotBeReplacedMissingDefault.SomeStaticProperty = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
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
            }
        }
    }

    class SwitchStatementCannotBeReplacedNonAssignment
    {
        private int someField;
        private static int SomeStaticField;
        private int SomeProperty { get; set; }
        private static int SomeStaticProperty { get; set; }

        void AssignmentsToInstanceField(int i)
        {
            switch (i)
            {
                case 1: AssignmentsToInstanceProperty(0); break;
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
                case 1: AssignmentsToInstanceProperty(0); break;
                case 2: SwitchStatementCannotBeReplacedNonAssignment.SomeStaticField = int.MaxValue; break;
                case 3: SomeStaticField = SomeStaticField * 10; break;
                case 4: SwitchStatementCannotBeReplacedNonAssignment.SomeStaticField = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: SomeStaticField = 0; break;
            }
        }

        void AssignmentsToInstanceProperty(int i)
        {
            switch (i)
            {
                case 1: AssignmentsToInstanceProperty(0); break;
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
                case 1: AssignmentsToInstanceProperty(0); break;
                case 2: SwitchStatementCannotBeReplacedNonAssignment.SomeStaticProperty = int.MaxValue; break;
                case 3: SomeStaticProperty = SomeStaticProperty * 10; break;
                case 4: SwitchStatementCannotBeReplacedNonAssignment.SomeStaticProperty = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: SomeStaticProperty = 0; break;
            }
        }

        void AssignmentsToLocalVariable(int i)
        {
            int someVariable = 0;
            switch (i)
            {
                case 1: AssignmentsToInstanceProperty(0); break;
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
                case 1: AssignmentsToInstanceProperty(0); break;
                case 2: someParameter = int.MaxValue; break;
                case 3: someParameter = someParameter * 10; break;
                case 4: someParameter = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: someParameter = 0; break;
            }
        }
    }

    class SwitchStatementCannotBeReplacedReturn
    {
        private int someField;
        private static int SomeStaticField;
        private int SomeProperty { get; set; }
        private static int SomeStaticProperty { get; set; }

        void AssignmentsToInstanceField(int i)
        {
            switch (i)
            {
                case 1: return;
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
                case 1: return;
                case 2: SwitchStatementCannotBeReplacedReturn.SomeStaticField = int.MaxValue; break;
                case 3: SomeStaticField = SomeStaticField * 10; break;
                case 4: SwitchStatementCannotBeReplacedReturn.SomeStaticField = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: SomeStaticField = 0; break;
            }
        }

        void AssignmentsToInstanceProperty(int i)
        {
            switch (i)
            {
                case 1: return;
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
                case 1: return;
                case 2: SwitchStatementCannotBeReplacedReturn.SomeStaticProperty = int.MaxValue; break;
                case 3: SomeStaticProperty = SomeStaticProperty * 10; break;
                case 4: SwitchStatementCannotBeReplacedReturn.SomeStaticProperty = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: SomeStaticProperty = 0; break;
            }
        }

        void AssignmentsToLocalVariable(int i)
        {
            int someVariable = 0;
            switch (i)
            {
                case 1: return;
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
                case 1: return;
                case 2: someParameter = int.MaxValue; break;
                case 3: someParameter = someParameter * 10; break;
                case 4: someParameter = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: someParameter = 0; break;
            }
        }
    }

    class SwitchStatementCannotBeReplacedCompoundAssignment
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
                case 3: someField *= 10; break;
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
                case 2: SwitchStatementCannotBeReplacedCompoundAssignment.SomeStaticField = int.MaxValue; break;
                case 3: SomeStaticField *= 10; break;
                case 4: SwitchStatementCannotBeReplacedCompoundAssignment.SomeStaticField = Math.Abs(100) + Math.Min(1, 2); break;
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
                case 3: SomeProperty *= 10; break;
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
                case 2: SwitchStatementCannotBeReplacedCompoundAssignment.SomeStaticProperty = int.MaxValue; break;
                case 3: SomeStaticProperty *= 10; break;
                case 4: SwitchStatementCannotBeReplacedCompoundAssignment.SomeStaticProperty = Math.Abs(100) + Math.Min(1, 2); break;
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
                case 3: someVariable *= 10; break;
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
                case 3: someParameter *= 10; break;
                case 4: someParameter = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: someParameter = 0; break;
            }
        }
    }

    class SwitchStatementCannotBeReplacedOtherAssignment
    {
        private int someField;
        private static int SomeStaticField;
        private int SomeProperty { get; set; }
        private static int SomeStaticProperty { get; set; }

        void AssignmentsToInstanceField(int i)
        {
            switch (i)
            {
                case 1: SomeStaticField = 11; break;
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
                case 1: someField = 11; break;
                case 2: SwitchStatementCannotBeReplacedOtherAssignment.SomeStaticField = int.MaxValue; break;
                case 3: SomeStaticField = SomeStaticField * 10; break;
                case 4: SwitchStatementCannotBeReplacedOtherAssignment.SomeStaticField = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: SomeStaticField = 0; break;
            }
        }

        void AssignmentsToInstanceProperty(int i)
        {
            switch (i)
            {
                case 1: someField = 11; break;
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
                case 1: SomeProperty = 11; break;
                case 2: SwitchStatementCannotBeReplacedOtherAssignment.SomeStaticProperty = int.MaxValue; break;
                case 3: SomeStaticProperty = SomeStaticProperty * 10; break;
                case 4: SwitchStatementCannotBeReplacedOtherAssignment.SomeStaticProperty = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: SomeStaticProperty = 0; break;
            }
        }

        void AssignmentsToLocalVariable(int i)
        {
            int someVariable = 0;
            switch (i)
            {
                case 1: someField = 11; break;
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
                case 1: someField = 11; break;
                case 2: someParameter = int.MaxValue; break;
                case 3: someParameter = someParameter * 10; break;
                case 4: someParameter = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: someParameter = 0; break;
            }
        }
    }

    class SwitchStatementCannotBeReplacedMultipleCases
    {
        private int someField;
        private static int SomeStaticField;
        private int SomeProperty { get; set; }
        private static int SomeStaticProperty { get; set; }

        void AssignmentsToInstanceField(int i)
        {
            switch (i)
            {
                case 1: case 100: someField = 11; break;
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
                case 1: case 100: SomeStaticField = 11; break;
                case 2: SwitchStatementCannotBeReplacedMultipleCases.SomeStaticField = int.MaxValue; break;
                case 3: SomeStaticField = SomeStaticField * 10; break;
                case 4: SwitchStatementCannotBeReplacedMultipleCases.SomeStaticField = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: SomeStaticField = 0; break;
            }
        }

        void AssignmentsToInstanceProperty(int i)
        {
            switch (i)
            {
                case 1: case 100: SomeProperty = 11; break;
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
                case 1: case 100: SomeStaticProperty = 11; break;
                case 2: SwitchStatementCannotBeReplacedMultipleCases.SomeStaticProperty = int.MaxValue; break;
                case 3: SomeStaticProperty = SomeStaticProperty * 10; break;
                case 4: SwitchStatementCannotBeReplacedMultipleCases.SomeStaticProperty = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: SomeStaticProperty = 0; break;
            }
        }

        void AssignmentsToLocalVariable(int i)
        {
            int someVariable = 0;
            switch (i)
            {
                case 1: case 100: someVariable = 11; break;
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
                case 1: case 100: someParameter = 11; break;
                case 2: someParameter = int.MaxValue; break;
                case 3: someParameter = someParameter * 10; break;
                case 4: someParameter = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: someParameter = 0; break;
            }
        }
    }

    class SwitchStatementCannotBeReplacedMultipleStatements
    {
        private int someField;
        private static int SomeStaticField;
        private int SomeProperty { get; set; }
        private static int SomeStaticProperty { get; set; }

        void AssignmentsToInstanceField(int i)
        {
            switch (i)
            {
                case 1: someField = 11; Console.WriteLine(); break;
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
                case 1: SomeStaticField = 11; Console.WriteLine(); break;
                case 2: SwitchStatementCannotBeReplacedMultipleStatements.SomeStaticField = int.MaxValue; break;
                case 3: SomeStaticField = SomeStaticField * 10; break;
                case 4: SwitchStatementCannotBeReplacedMultipleStatements.SomeStaticField = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: SomeStaticField = 0; break;
            }
        }

        void AssignmentsToInstanceProperty(int i)
        {
            switch (i)
            {
                case 1: SomeProperty = 11; Console.WriteLine(); break;
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
                case 1: SomeStaticProperty = 11; Console.WriteLine(); break;
                case 2: SwitchStatementCannotBeReplacedMultipleStatements.SomeStaticProperty = int.MaxValue; break;
                case 3: SomeStaticProperty = SomeStaticProperty * 10; break;
                case 4: SwitchStatementCannotBeReplacedMultipleStatements.SomeStaticProperty = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: SomeStaticProperty = 0; break;
            }
        }

        void AssignmentsToLocalVariable(int i)
        {
            int someVariable = 0;
            switch (i)
            {
                case 1: someVariable = 11; Console.WriteLine(); break;
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
                case 1: someParameter = 11; Console.WriteLine(); break;
                case 2: someParameter = int.MaxValue; break;
                case 3: someParameter = someParameter * 10; break;
                case 4: someParameter = Math.Abs(100) + Math.Min(1, 2); break;
                case 5: throw new Exception();
                default: someParameter = 0; break;
            }
        }
    }
}