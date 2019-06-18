// ReSharper disable All

// Expected number of suggestions: 52 (at the moment 49 until we implement the case with initialization: Property { get; set; } = default)

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclarePropertyAsNullable
{
    public class ClassPropertyCanBeDeclaredAsNullableDefaultInsteadOfNull
    {
        private string DetectedOnlyOnce { get; set; } = default;

        private string IntializedToNull { get; set; } = default(string);
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

            AssignedNull = default;
            DetectedOnlyOnce = default(string);

            if (ComparedEqualToNullOnLeft == default) return;
            if (default(string) == ComparedEqualToNullOnRight) return;            
            if (ComparedNotEqualToNullOnLeft != default) return;
            if (default(string) != ComparedNotEqualToNullOnRight) return;
            if (DetectedOnlyOnce == default) return;
            if (default(string) == DetectedOnlyOnce) return;

            AssignedResultOfAsOperator = AssignedNull as string;
            DetectedOnlyOnce = AssignedNull as string;

            UsedInConditionalAccess?.Length.ToString();
            DetectedOnlyOnce?.Length.ToString();

            dummy = UsedInCoalesceExpression ?? string.Empty;
            dummy = DetectedOnlyOnce ?? string.Empty;

            this.AssignedNullUsingThis = default;

            if (this.ComparedEqualToNullOnLeftUsingThis == default(string)) return;
            if (default == this.ComparedEqualToNullOnRightUsingThis) return;
            if (this.ComparedNotEqualToNullOnLeftUsingThis != default(string)) return;
            if (default != this.ComparedNotEqualToNullOnRightUsingThis) return;

            this.AssignedResultOfAsOperatorUsingThis = AssignedNull as string;
            this.UsedInConditionalAccessUsingThis?.Length.ToString();
            dummy = this.UsedInCoalesceExpressionUsingThis ?? string.Empty;

            StaticAssignedNull = default(string);

            if (StaticComparedEqualToNullOnLeft == default) return;
            if (default(string) == StaticComparedEqualToNullOnRight) return;
            if (StaticComparedNotEqualToNullOnLeft != default) return;
            if (default(string) != StaticComparedNotEqualToNullOnRight) return;

            StaticAssignedResultOfAsOperator = AssignedNull as string;
            StaticUsedInConditionalAccess?.Length.ToString();
            dummy = StaticUsedInCoalesceExpression ?? string.Empty;

            ClassPropertyCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticAssignedNullUsingClassName = default;

            if (ClassPropertyCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticComparedEqualToNullOnLeftUsingClassName == default(string)) return;
            if (default == ClassPropertyCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticComparedEqualToNullOnRightUsingClassName) return;
            if (ClassPropertyCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticComparedNotEqualToNullOnLeftUsingClassName != default(string)) return;
            if (default != ClassPropertyCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticComparedNotEqualToNullOnRightUsingClassName) return;

            ClassPropertyCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticAssignedResultOfAsOperatorUsingClassName = AssignedNull as string;
            ClassPropertyCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticUsedInConditionalAccessUsingClassName?.Length.ToString();
            dummy = ClassPropertyCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticUsedInCoalesceExpressionUsingClassName ?? string.Empty;

            var classWithProperties = new ClassWithNullablePropertiesDefaultInsteadOfNull();

            classWithProperties.AssignedNull = default(string);

            if (classWithProperties.ComparedEqualToNullOnLeft == default) return;
            if (default(string) == classWithProperties.ComparedEqualToNullOnRight) return;
            if (classWithProperties.ComparedNotEqualToNullOnLeft != default) return;
            if (default(string) != classWithProperties.ComparedNotEqualToNullOnRight) return;

            classWithProperties.AssignedResultOfAsOperator = AssignedNull as string;
            classWithProperties.UsedInConditionalAccess?.Length.ToString();
            dummy = classWithProperties.UsedInCoalesceExpression ?? string.Empty;

            ClassWithNullablePropertiesDefaultInsteadOfNull.StaticAssignedNull = default;

            if (ClassWithNullablePropertiesDefaultInsteadOfNull.StaticComparedEqualToNullOnLeft == default(string)) return;
            if (default == ClassWithNullablePropertiesDefaultInsteadOfNull.StaticComparedEqualToNullOnRight) return;
            if (ClassWithNullablePropertiesDefaultInsteadOfNull.StaticComparedNotEqualToNullOnLeft != default(string)) return;
            if (default != ClassWithNullablePropertiesDefaultInsteadOfNull.StaticComparedNotEqualToNullOnRight) return;

            ClassWithNullablePropertiesDefaultInsteadOfNull.StaticAssignedResultOfAsOperator = AssignedNull as string;
            ClassWithNullablePropertiesDefaultInsteadOfNull.StaticUsedInConditionalAccess?.Length.ToString();
            dummy = ClassWithNullablePropertiesDefaultInsteadOfNull.StaticUsedInCoalesceExpression ?? string.Empty;
        }
    }

    public class ClassWithNullablePropertiesDefaultInsteadOfNull
    {
        public string IntializedToNull { get; set; } = default(string);

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