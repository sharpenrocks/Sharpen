// ReSharper disable All

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclarePropertyAsNullable
{
    public class ClassPropertyCannotBeDeclaredAsNullableIsNullableStruct
    {
        private int? DetectedOnlyOnce { get; set; } = null;

        private int? IntializedToNull { get; set; } = null;
        private int? InitializedToResultOfAsOperator { get; set; } = 0 as int?;

        private int? AssignedNull { get; set; }
        private int? ComparedEqualToNullOnLeft { get; set; }
        private int? ComparedEqualToNullOnRight { get; set; }
        private int? ComparedNotEqualToNullOnLeft { get; set; }
        private int? ComparedNotEqualToNullOnRight { get; set; }
        private int? AssignedResultOfAsOperator { get; set; }
        private int? UsedInConditionalAccess { get; set; }
        private int? UsedInCoalesceExpression { get; set; }

        private int? AssignedNullUsingThis { get; set; }
        private int? ComparedEqualToNullOnLeftUsingThis { get; set; }
        private int? ComparedEqualToNullOnRightUsingThis { get; set; }
        private int? ComparedNotEqualToNullOnLeftUsingThis { get; set; }
        private int? ComparedNotEqualToNullOnRightUsingThis { get; set; }
        private int? AssignedResultOfAsOperatorUsingThis { get; set; }
        private int? UsedInConditionalAccessUsingThis { get; set; }
        private int? UsedInCoalesceExpressionUsingThis { get; set; }

        private static int? StaticAssignedNull { get; set; }
        private static int? StaticComparedEqualToNullOnLeft { get; set; }
        private static int? StaticComparedEqualToNullOnRight { get; set; }
        private static int? StaticComparedNotEqualToNullOnLeft { get; set; }
        private static int? StaticComparedNotEqualToNullOnRight { get; set; }
        private static int? StaticAssignedResultOfAsOperator { get; set; }
        private static int? StaticUsedInConditionalAccess { get; set; }
        private static int? StaticUsedInCoalesceExpression { get; set; }

        private static int? StaticAssignedNullUsingClassName { get; set; }
        private static int? StaticComparedEqualToNullOnLeftUsingClassName { get; set; }
        private static int? StaticComparedEqualToNullOnRightUsingClassName { get; set; }
        private static int? StaticComparedNotEqualToNullOnLeftUsingClassName { get; set; }
        private static int? StaticComparedNotEqualToNullOnRightUsingClassName { get; set; }
        private static int? StaticAssignedResultOfAsOperatorUsingClassName { get; set; }
        private static int? StaticUsedInConditionalAccessUsingClassName { get; set; }
        private static int? StaticUsedInCoalesceExpressionUsingClassName { get; set; }

        public void AllFieldsAreNullableForDifferentReasons()
        {
            int? dummy;

            AssignedNull = null;
            DetectedOnlyOnce = null;

            if (ComparedEqualToNullOnLeft == null) return;
            if (null == ComparedEqualToNullOnRight) return;            
            if (ComparedNotEqualToNullOnLeft != null) return;
            if (null != ComparedNotEqualToNullOnRight) return;
            if (DetectedOnlyOnce == null) return;
            if (null == DetectedOnlyOnce) return;

            AssignedResultOfAsOperator = AssignedNull as int?;
            DetectedOnlyOnce = AssignedNull as int?;

            UsedInConditionalAccess?.ToString();
            DetectedOnlyOnce?.ToString();

            dummy = UsedInCoalesceExpression ?? 0;
            dummy = DetectedOnlyOnce ?? 0;

            this.AssignedNullUsingThis = null;

            if (this.ComparedEqualToNullOnLeftUsingThis == null) return;
            if (null == this.ComparedEqualToNullOnRightUsingThis) return;
            if (this.ComparedNotEqualToNullOnLeftUsingThis != null) return;
            if (null != this.ComparedNotEqualToNullOnRightUsingThis) return;

            this.AssignedResultOfAsOperatorUsingThis = AssignedNull as int?;
            this.UsedInConditionalAccessUsingThis?.ToString();
            dummy = this.UsedInCoalesceExpressionUsingThis ?? 0;

            StaticAssignedNull = null;

            if (StaticComparedEqualToNullOnLeft == null) return;
            if (null == StaticComparedEqualToNullOnRight) return;
            if (StaticComparedNotEqualToNullOnLeft != null) return;
            if (null != StaticComparedNotEqualToNullOnRight) return;

            StaticAssignedResultOfAsOperator = AssignedNull as int?;
            StaticUsedInConditionalAccess?.ToString();
            dummy = StaticUsedInCoalesceExpression ?? 0;

            ClassPropertyCannotBeDeclaredAsNullableIsNullableStruct.StaticAssignedNullUsingClassName = null;

            if (ClassPropertyCannotBeDeclaredAsNullableIsNullableStruct.StaticComparedEqualToNullOnLeftUsingClassName == null) return;
            if (null == ClassPropertyCannotBeDeclaredAsNullableIsNullableStruct.StaticComparedEqualToNullOnRightUsingClassName) return;
            if (ClassPropertyCannotBeDeclaredAsNullableIsNullableStruct.StaticComparedNotEqualToNullOnLeftUsingClassName != null) return;
            if (null != ClassPropertyCannotBeDeclaredAsNullableIsNullableStruct.StaticComparedNotEqualToNullOnRightUsingClassName) return;

            ClassPropertyCannotBeDeclaredAsNullableIsNullableStruct.StaticAssignedResultOfAsOperatorUsingClassName = AssignedNull as int?;
            ClassPropertyCannotBeDeclaredAsNullableIsNullableStruct.StaticUsedInConditionalAccessUsingClassName?.ToString();
            dummy = ClassPropertyCannotBeDeclaredAsNullableIsNullableStruct.StaticUsedInCoalesceExpressionUsingClassName ?? 0;

            var classWithFields = new ClassWithNullableStructProperties();

            classWithFields.AssignedNull = null;

            if (classWithFields.ComparedEqualToNullOnLeft == null) return;
            if (null == classWithFields.ComparedEqualToNullOnRight) return;
            if (classWithFields.ComparedNotEqualToNullOnLeft != null) return;
            if (null != classWithFields.ComparedNotEqualToNullOnRight) return;

            classWithFields.AssignedResultOfAsOperator = AssignedNull as int?;
            classWithFields.UsedInConditionalAccess?.ToString();
            dummy = classWithFields.UsedInCoalesceExpression ?? 0;

            ClassWithNullableStructProperties.StaticAssignedNull = null;

            if (ClassWithNullableStructProperties.StaticComparedEqualToNullOnLeft == null) return;
            if (null == ClassWithNullableStructProperties.StaticComparedEqualToNullOnRight) return;
            if (ClassWithNullableStructProperties.StaticComparedNotEqualToNullOnLeft != null) return;
            if (null != ClassWithNullableStructProperties.StaticComparedNotEqualToNullOnRight) return;

            ClassWithNullableStructProperties.StaticAssignedResultOfAsOperator = AssignedNull as int?;
            ClassWithNullableStructProperties.StaticUsedInConditionalAccess?.ToString();
            dummy = ClassWithNullableStructProperties.StaticUsedInCoalesceExpression ?? 0;
        }
    }

    public class ClassWithNullableStructProperties
    {
        public int? IntializedToNull { get; set; } = null;

        public int? AssignedNull { get; set; }
        public int? ComparedEqualToNullOnLeft { get; set; }
        public int? ComparedEqualToNullOnRight { get; set; }
        public int? ComparedNotEqualToNullOnLeft { get; set; }
        public int? ComparedNotEqualToNullOnRight { get; set; }
        public int? AssignedResultOfAsOperator { get; set; }
        public int? UsedInConditionalAccess { get; set; }
        public int? UsedInCoalesceExpression { get; set; }

        public static int? StaticAssignedNull { get; set; }
        public static int? StaticComparedEqualToNullOnLeft { get; set; }
        public static int? StaticComparedEqualToNullOnRight { get; set; }
        public static int? StaticComparedNotEqualToNullOnLeft { get; set; }
        public static int? StaticComparedNotEqualToNullOnRight { get; set; }
        public static int? StaticAssignedResultOfAsOperator { get; set; }
        public static int? StaticUsedInConditionalAccess { get; set; }
        public static int? StaticUsedInCoalesceExpression { get; set; }
    }
}