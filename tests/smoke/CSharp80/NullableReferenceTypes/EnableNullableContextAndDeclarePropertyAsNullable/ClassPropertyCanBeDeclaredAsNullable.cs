// ReSharper disable All

// Expected number of suggestions: 52 (at the moment 49 until we implement the case with initialization: Property { get; set; } = null)

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclarePropertyAsNullable
{
    public class ClassPropertyCanBeDeclaredAsNullable
    {
        private string DetectedOnlyOnce { get; set; } = null;

        private string IntializedToNull { get; set; } = null;
        private string InitializedToResultOfAsOperator { get; set; } = string.Empty as string;

        private string AssignedNull { get; set; }
        private string ComparedEqualToNullOnLeft { get; set; }
        private string ComparedEqualToNullOnRight { get; set; }
        private string ComparedNotEqualToNullOnLeft { get; set; }
        private string ComparedNotEqualToNullOnRight { get; set; }
        private string AssignedResultOfAsOperator { get; set; }
        private string UsedInConditionalAccess { get; set; }
        private string UsedInCoalesceExpression { get; set; }

        private string AssignedNullUsingThis { get; set; }
        private string ComparedEqualToNullOnLeftUsingThis { get; set; }
        private string ComparedEqualToNullOnRightUsingThis { get; set; }
        private string ComparedNotEqualToNullOnLeftUsingThis { get; set; }
        private string ComparedNotEqualToNullOnRightUsingThis { get; set; }
        private string AssignedResultOfAsOperatorUsingThis { get; set; }
        private string UsedInConditionalAccessUsingThis { get; set; }
        private string UsedInCoalesceExpressionUsingThis { get; set; }

        private static string StaticAssignedNull { get; set; }
        private static string StaticComparedEqualToNullOnLeft { get; set; }
        private static string StaticComparedEqualToNullOnRight { get; set; }
        private static string StaticComparedNotEqualToNullOnLeft { get; set; }
        private static string StaticComparedNotEqualToNullOnRight { get; set; }
        private static string StaticAssignedResultOfAsOperator { get; set; }
        private static string StaticUsedInConditionalAccess { get; set; }
        private static string StaticUsedInCoalesceExpression { get; set; }

        private static string StaticAssignedNullUsingClassName { get; set; }
        private static string StaticComparedEqualToNullOnLeftUsingClassName { get; set; }
        private static string StaticComparedEqualToNullOnRightUsingClassName { get; set; }
        private static string StaticComparedNotEqualToNullOnLeftUsingClassName { get; set; }
        private static string StaticComparedNotEqualToNullOnRightUsingClassName { get; set; }
        private static string StaticAssignedResultOfAsOperatorUsingClassName { get; set; }
        private static string StaticUsedInConditionalAccessUsingClassName { get; set; }
        private static string StaticUsedInCoalesceExpressionUsingClassName { get; set; }

        public void AllFieldsAreNullableForDifferentReasons()
        {
            string dummy;

            AssignedNull = null;
            DetectedOnlyOnce = null;

            if (ComparedEqualToNullOnLeft == null) return;
            if (null == ComparedEqualToNullOnRight) return;            
            if (ComparedNotEqualToNullOnLeft != null) return;
            if (null != ComparedNotEqualToNullOnRight) return;
            if (DetectedOnlyOnce == null) return;
            if (null == DetectedOnlyOnce) return;

            AssignedResultOfAsOperator = AssignedNull as string;
            DetectedOnlyOnce = AssignedNull as string;

            UsedInConditionalAccess?.Length.ToString();
            DetectedOnlyOnce?.Length.ToString();

            dummy = UsedInCoalesceExpression ?? string.Empty;
            dummy = DetectedOnlyOnce ?? string.Empty;

            this.AssignedNullUsingThis = null;

            if (this.ComparedEqualToNullOnLeftUsingThis == null) return;
            if (null == this.ComparedEqualToNullOnRightUsingThis) return;
            if (this.ComparedNotEqualToNullOnLeftUsingThis != null) return;
            if (null != this.ComparedNotEqualToNullOnRightUsingThis) return;

            this.AssignedResultOfAsOperatorUsingThis = AssignedNull as string;
            this.UsedInConditionalAccessUsingThis?.Length.ToString();
            dummy = this.UsedInCoalesceExpressionUsingThis ?? string.Empty;

            StaticAssignedNull = null;

            if (StaticComparedEqualToNullOnLeft == null) return;
            if (null == StaticComparedEqualToNullOnRight) return;
            if (StaticComparedNotEqualToNullOnLeft != null) return;
            if (null != StaticComparedNotEqualToNullOnRight) return;

            StaticAssignedResultOfAsOperator = AssignedNull as string;
            StaticUsedInConditionalAccess?.Length.ToString();
            dummy = StaticUsedInCoalesceExpression ?? string.Empty;

            ClassPropertyCanBeDeclaredAsNullable.StaticAssignedNullUsingClassName = null;

            if (ClassPropertyCanBeDeclaredAsNullable.StaticComparedEqualToNullOnLeftUsingClassName == null) return;
            if (null == ClassPropertyCanBeDeclaredAsNullable.StaticComparedEqualToNullOnRightUsingClassName) return;
            if (ClassPropertyCanBeDeclaredAsNullable.StaticComparedNotEqualToNullOnLeftUsingClassName != null) return;
            if (null != ClassPropertyCanBeDeclaredAsNullable.StaticComparedNotEqualToNullOnRightUsingClassName) return;

            ClassPropertyCanBeDeclaredAsNullable.StaticAssignedResultOfAsOperatorUsingClassName = AssignedNull as string;
            ClassPropertyCanBeDeclaredAsNullable.StaticUsedInConditionalAccessUsingClassName?.Length.ToString();
            dummy = ClassPropertyCanBeDeclaredAsNullable.StaticUsedInCoalesceExpressionUsingClassName ?? string.Empty;

            var classWithFields = new ClassWithNullableProperties();

            classWithFields.AssignedNull = null;

            if (classWithFields.ComparedEqualToNullOnLeft == null) return;
            if (null == classWithFields.ComparedEqualToNullOnRight) return;
            if (classWithFields.ComparedNotEqualToNullOnLeft != null) return;
            if (null != classWithFields.ComparedNotEqualToNullOnRight) return;

            classWithFields.AssignedResultOfAsOperator = AssignedNull as string;
            classWithFields.UsedInConditionalAccess?.Length.ToString();
            dummy = classWithFields.UsedInCoalesceExpression ?? string.Empty;

            ClassWithNullableProperties.StaticAssignedNull = null;

            if (ClassWithNullableProperties.StaticComparedEqualToNullOnLeft == null) return;
            if (null == ClassWithNullableProperties.StaticComparedEqualToNullOnRight) return;
            if (ClassWithNullableProperties.StaticComparedNotEqualToNullOnLeft != null) return;
            if (null != ClassWithNullableProperties.StaticComparedNotEqualToNullOnRight) return;

            ClassWithNullableProperties.StaticAssignedResultOfAsOperator = AssignedNull as string;
            ClassWithNullableProperties.StaticUsedInConditionalAccess?.Length.ToString();
            dummy = ClassWithNullableProperties.StaticUsedInCoalesceExpression ?? string.Empty;
        }
    }

    public class ClassWithNullableProperties
    {
        public string IntializedToNull { get; set; } = null;

        public string AssignedNull { get; set; }
        public string ComparedEqualToNullOnLeft { get; set; }
        public string ComparedEqualToNullOnRight { get; set; }
        public string ComparedNotEqualToNullOnLeft { get; set; }
        public string ComparedNotEqualToNullOnRight { get; set; }
        public string AssignedResultOfAsOperator { get; set; }
        public string UsedInConditionalAccess { get; set; }
        public string UsedInCoalesceExpression { get; set; }

        public static string StaticAssignedNull { get; set; }
        public static string StaticComparedEqualToNullOnLeft { get; set; }
        public static string StaticComparedEqualToNullOnRight { get; set; }
        public static string StaticComparedNotEqualToNullOnLeft { get; set; }
        public static string StaticComparedNotEqualToNullOnRight { get; set; }
        public static string StaticAssignedResultOfAsOperator { get; set; }
        public static string StaticUsedInConditionalAccess { get; set; }
        public static string StaticUsedInCoalesceExpression { get; set; }
    }
}