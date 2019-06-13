// ReSharper disable All

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareFieldAsNullable
{
    public class ClassFieldCannotBeDeclaredAsNullableIsNullableStruct
    {
        private int? detectedOnlyOnce = null;

        private int? intializedToNull = null;
        private int? initializedToResultOfAsOperator = 0 as int?;

        private int? a, bAssignedNull, c;
        private int? d, e, fInitializedToNull = null;
        private int? gInitializedToResultOfAsOperator = 0 as int?, h, i;

        private int? assignedNull;
        private int? comparedEqualToNullOnLeft;
        private int? comparedEqualToNullOnRight;
        private int? comparedNotEqualToNullOnLeft;
        private int? comparedNotEqualToNullOnRight;
        private int? assignedResultOfAsOperator;
        private int? usedInConditionalAccess;
        private int? usedInCoalesceExpression;

        private int? assignedNullUsingThis;
        private int? comparedEqualToNullOnLeftUsingThis;
        private int? comparedEqualToNullOnRightUsingThis;
        private int? comparedNotEqualToNullOnLeftUsingThis;
        private int? comparedNotEqualToNullOnRightUsingThis;
        private int? assignedResultOfAsOperatorUsingThis;
        private int? usedInConditionalAccessUsingThis;
        private int? usedInCoalesceExpressionUsingThis;

        private static int? StaticAssignedNull;
        private static int? StaticComparedEqualToNullOnLeft;
        private static int? StaticComparedEqualToNullOnRight;
        private static int? StaticComparedNotEqualToNullOnLeft;
        private static int? StaticComparedNotEqualToNullOnRight;
        private static int? StaticAssignedResultOfAsOperator;
        private static int? StaticUsedInConditionalAccess;
        private static int? StaticUsedInCoalesceExpression;

        private static int? StaticAssignedNullUsingClassName;
        private static int? StaticComparedEqualToNullOnLeftUsingClassName;
        private static int? StaticComparedEqualToNullOnRightUsingClassName;
        private static int? StaticComparedNotEqualToNullOnLeftUsingClassName;
        private static int? StaticComparedNotEqualToNullOnRightUsingClassName;
        private static int? StaticAssignedResultOfAsOperatorUsingClassName;
        private static int? StaticUsedInConditionalAccessUsingClassName;
        private static int? StaticUsedInCoalesceExpressionUsingClassName;

        public void AllFieldsAreNullableForDifferentReasons()
        {
            int? dummy;

            assignedNull = null;
            bAssignedNull = null;
            detectedOnlyOnce = null;

            if (comparedEqualToNullOnLeft == null) return;
            if (null == comparedEqualToNullOnRight) return;            
            if (comparedNotEqualToNullOnLeft != null) return;
            if (null != comparedNotEqualToNullOnRight) return;
            if (detectedOnlyOnce == null) return;
            if (null == detectedOnlyOnce) return;

            assignedResultOfAsOperator = assignedNull as int?;
            detectedOnlyOnce = assignedNull as int?;

            usedInConditionalAccess?.ToString();
            detectedOnlyOnce?.ToString();

            dummy = usedInCoalesceExpression ?? 0;
            dummy = detectedOnlyOnce ?? 0;

            this.assignedNullUsingThis = null;

            if (this.comparedEqualToNullOnLeftUsingThis == null) return;
            if (null == this.comparedEqualToNullOnRightUsingThis) return;
            if (this.comparedNotEqualToNullOnLeftUsingThis != null) return;
            if (null != this.comparedNotEqualToNullOnRightUsingThis) return;

            this.assignedResultOfAsOperatorUsingThis = assignedNull as int?;
            this.usedInConditionalAccessUsingThis?.ToString();
            dummy = this.usedInCoalesceExpressionUsingThis ?? 0;

            StaticAssignedNull = null;

            if (StaticComparedEqualToNullOnLeft == null) return;
            if (null == StaticComparedEqualToNullOnRight) return;
            if (StaticComparedNotEqualToNullOnLeft != null) return;
            if (null != StaticComparedNotEqualToNullOnRight) return;

            StaticAssignedResultOfAsOperator = assignedNull as int?;
            StaticUsedInConditionalAccess?.ToString();
            dummy = StaticUsedInCoalesceExpression ?? 0;

            ClassFieldCannotBeDeclaredAsNullableIsNullableStruct.StaticAssignedNullUsingClassName = null;

            if (ClassFieldCannotBeDeclaredAsNullableIsNullableStruct.StaticComparedEqualToNullOnLeftUsingClassName == null) return;
            if (null == ClassFieldCannotBeDeclaredAsNullableIsNullableStruct.StaticComparedEqualToNullOnRightUsingClassName) return;
            if (ClassFieldCannotBeDeclaredAsNullableIsNullableStruct.StaticComparedNotEqualToNullOnLeftUsingClassName != null) return;
            if (null != ClassFieldCannotBeDeclaredAsNullableIsNullableStruct.StaticComparedNotEqualToNullOnRightUsingClassName) return;

            ClassFieldCannotBeDeclaredAsNullableIsNullableStruct.StaticAssignedResultOfAsOperatorUsingClassName = assignedNull as int?;
            ClassFieldCannotBeDeclaredAsNullableIsNullableStruct.StaticUsedInConditionalAccessUsingClassName?.ToString();
            dummy = ClassFieldCannotBeDeclaredAsNullableIsNullableStruct.StaticUsedInCoalesceExpressionUsingClassName ?? 0;

            var classWithFields = new ClassWithNullableStructFields();

            classWithFields.assignedNull = null;

            if (classWithFields.comparedEqualToNullOnLeft == null) return;
            if (null == classWithFields.comparedEqualToNullOnRight) return;
            if (classWithFields.comparedNotEqualToNullOnLeft != null) return;
            if (null != classWithFields.comparedNotEqualToNullOnRight) return;

            classWithFields.assignedResultOfAsOperator = assignedNull as int?;
            classWithFields.usedInConditionalAccess?.ToString();
            dummy = classWithFields.usedInCoalesceExpression ?? 0;

            ClassWithNullableStructFields.StaticAssignedNull = null;

            if (ClassWithNullableStructFields.StaticComparedEqualToNullOnLeft == null) return;
            if (null == ClassWithNullableStructFields.StaticComparedEqualToNullOnRight) return;
            if (ClassWithNullableStructFields.StaticComparedNotEqualToNullOnLeft != null) return;
            if (null != ClassWithNullableStructFields.StaticComparedNotEqualToNullOnRight) return;

            ClassWithNullableStructFields.StaticAssignedResultOfAsOperator = assignedNull as int?;
            ClassWithNullableStructFields.StaticUsedInConditionalAccess?.ToString();
            dummy = ClassWithNullableStructFields.StaticUsedInCoalesceExpression ?? 0;
        }
    }

    public class ClassWithNullableStructFields
    {
        public int? intializedToNull = null;

        public int? assignedNull;
        public int? comparedEqualToNullOnLeft;
        public int? comparedEqualToNullOnRight;
        public int? comparedNotEqualToNullOnLeft;
        public int? comparedNotEqualToNullOnRight;
        public int? assignedResultOfAsOperator;
        public int? usedInConditionalAccess;
        public int? usedInCoalesceExpression;

        public static int? StaticAssignedNull;
        public static int? StaticComparedEqualToNullOnLeft;
        public static int? StaticComparedEqualToNullOnRight;
        public static int? StaticComparedNotEqualToNullOnLeft;
        public static int? StaticComparedNotEqualToNullOnRight;
        public static int? StaticAssignedResultOfAsOperator;
        public static int? StaticUsedInConditionalAccess;
        public static int? StaticUsedInCoalesceExpression;
    }
}