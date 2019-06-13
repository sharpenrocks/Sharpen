// ReSharper disable All

using System;

namespace CSharp80.SwitchExpressions.ReplaceSwitchStatementContainingOnlyReturnsWithSwitchExpression
{
    class SwitchStatementCannotBeReplacedMissingDefault
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
            }

            return 0;
        }

        int ReturnStaticField(int i)
        {
            switch (i)
            {
                case 1: return SomeStaticField;
                case 2: return int.MaxValue;
                case 3: return SwitchStatementCannotBeReplacedMissingDefault.SomeStaticField * 10;
                case 4: return Math.Abs(100) + Math.Min(1, 2);
                case 5: throw new Exception();
            }

            return 0;
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
            }

            return 0;
        }

        int ReturnStaticProperty(int i)
        {
            switch (i)
            {
                case 1: return SomeStaticProperty;
                case 2: return int.MaxValue;
                case 3: return SwitchStatementCannotBeReplacedMissingDefault.SomeStaticProperty * 10;
                case 4: return Math.Abs(100) + Math.Min(1, 2);
                case 5: throw new Exception();
            }

            return 0;
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
            }

            return 0;
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
            }

            return 0;
        }
    }

    class SwitchStatementCannotBeReplacedNonReturn
    {
        private int someField;
        private static int SomeStaticField;
        private int SomeProperty { get; set; }
        private static int SomeStaticProperty { get; set; }

        int ReturnInstanceField(int i)
        {
            switch (i)
            {
                case 1: ReturnInstanceProperty(0); return someField;
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
                case 1: ReturnInstanceProperty(0); return SomeStaticField;
                case 2: return int.MaxValue;
                case 3: return SwitchStatementCannotBeReplacedNonReturn.SomeStaticField * 10;
                case 4: return Math.Abs(100) + Math.Min(1, 2);
                case 5: throw new Exception();
                default: return 0;
            }
        }

        int ReturnInstanceProperty(int i)
        {
            switch (i)
            {
                case 1: ReturnInstanceProperty(0); return SomeProperty;
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
                case 1: ReturnInstanceProperty(0); return SomeStaticProperty;
                case 2: return int.MaxValue;
                case 3: return SwitchStatementCannotBeReplacedNonReturn.SomeStaticProperty * 10;
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
                case 1: ReturnInstanceProperty(0); return someVariable;
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
                case 1: ReturnInstanceProperty(0); return someParameter;
                case 2: return int.MaxValue;
                case 3: return someParameter * 10;
                case 4: return Math.Abs(100) + Math.Min(1, 2);
                case 5: throw new Exception();
                default: return 0;
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
}