// ReSharper disable All

// Expected number of suggestions: 55

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareFieldAsNullable
{
    public class ClassFieldCanBeDeclaredAsNullableDefaultInsteadOfNull
    {
        private string detectedOnlyOnce = default;

        private string intializedToNull = default;
        private string initializedToResultOfAsOperator = string.Empty as string;

        private string a, bAssignedNull, c;
        private string d, e, fInitializedToNull = default;
        private string gInitializedToResultOfAsOperator = string.Empty as string, h, i;

        private string assignedNull;
        private string comparedEqualToNullOnLeft;
        private string comparedEqualToNullOnRight;
        private string comparedNotEqualToNullOnLeft;
        private string comparedNotEqualToNullOnRight;
        private string assignedResultOfAsOperator;
        private string usedInConditionalAccess;
        private string usedInCoalesceExpression;

        private string assignedNullUsingThis;
        private string comparedEqualToNullOnLeftUsingThis;
        private string comparedEqualToNullOnRightUsingThis;
        private string comparedNotEqualToNullOnLeftUsingThis;
        private string comparedNotEqualToNullOnRightUsingThis;
        private string assignedResultOfAsOperatorUsingThis;
        private string usedInConditionalAccessUsingThis;
        private string usedInCoalesceExpressionUsingThis;

        private static string StaticAssignedNull;
        private static string StaticComparedEqualToNullOnLeft;
        private static string StaticComparedEqualToNullOnRight;
        private static string StaticComparedNotEqualToNullOnLeft;
        private static string StaticComparedNotEqualToNullOnRight;
        private static string StaticAssignedResultOfAsOperator;
        private static string StaticUsedInConditionalAccess;
        private static string StaticUsedInCoalesceExpression;

        private static string StaticAssignedNullUsingClassName;
        private static string StaticComparedEqualToNullOnLeftUsingClassName;
        private static string StaticComparedEqualToNullOnRightUsingClassName;
        private static string StaticComparedNotEqualToNullOnLeftUsingClassName;
        private static string StaticComparedNotEqualToNullOnRightUsingClassName;
        private static string StaticAssignedResultOfAsOperatorUsingClassName;
        private static string StaticUsedInConditionalAccessUsingClassName;
        private static string StaticUsedInCoalesceExpressionUsingClassName;

        public void AllFieldsAreNullableForDifferentReasons()
        {
            string dummy;

            assignedNull = default;
            bAssignedNull = default;
            detectedOnlyOnce = default;

            if (comparedEqualToNullOnLeft == default) return;
            if (default == comparedEqualToNullOnRight) return;            
            if (comparedNotEqualToNullOnLeft != default) return;
            if (default != comparedNotEqualToNullOnRight) return;
            if (detectedOnlyOnce == default) return;
            if (default == detectedOnlyOnce) return;

            assignedResultOfAsOperator = assignedNull as string;
            detectedOnlyOnce = assignedNull as string;

            usedInConditionalAccess?.Length.ToString();
            detectedOnlyOnce?.Length.ToString();

            dummy = usedInCoalesceExpression ?? string.Empty;
            dummy = detectedOnlyOnce ?? string.Empty;

            this.assignedNullUsingThis = default;

            if (this.comparedEqualToNullOnLeftUsingThis == default) return;
            if (default == this.comparedEqualToNullOnRightUsingThis) return;
            if (this.comparedNotEqualToNullOnLeftUsingThis != default) return;
            if (default != this.comparedNotEqualToNullOnRightUsingThis) return;

            this.assignedResultOfAsOperatorUsingThis = assignedNull as string;
            this.usedInConditionalAccessUsingThis?.Length.ToString();
            dummy = this.usedInCoalesceExpressionUsingThis ?? string.Empty;

            StaticAssignedNull = default;

            if (StaticComparedEqualToNullOnLeft == default) return;
            if (default == StaticComparedEqualToNullOnRight) return;
            if (StaticComparedNotEqualToNullOnLeft != default) return;
            if (default != StaticComparedNotEqualToNullOnRight) return;

            StaticAssignedResultOfAsOperator = assignedNull as string;
            StaticUsedInConditionalAccess?.Length.ToString();
            dummy = StaticUsedInCoalesceExpression ?? string.Empty;

            ClassFieldCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticAssignedNullUsingClassName = default;

            if (ClassFieldCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticComparedEqualToNullOnLeftUsingClassName == default) return;
            if (default == ClassFieldCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticComparedEqualToNullOnRightUsingClassName) return;
            if (ClassFieldCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticComparedNotEqualToNullOnLeftUsingClassName != default) return;
            if (default != ClassFieldCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticComparedNotEqualToNullOnRightUsingClassName) return;

            ClassFieldCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticAssignedResultOfAsOperatorUsingClassName = assignedNull as string;
            ClassFieldCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticUsedInConditionalAccessUsingClassName?.Length.ToString();
            dummy = ClassFieldCanBeDeclaredAsNullableDefaultInsteadOfNull.StaticUsedInCoalesceExpressionUsingClassName ?? string.Empty;

            var classWithFields = new ClassWithNullableFieldsDefaultInsteaOfNull();

            classWithFields.assignedNull = default;

            if (classWithFields.comparedEqualToNullOnLeft == default) return;
            if (default == classWithFields.comparedEqualToNullOnRight) return;
            if (classWithFields.comparedNotEqualToNullOnLeft != default) return;
            if (default != classWithFields.comparedNotEqualToNullOnRight) return;

            classWithFields.assignedResultOfAsOperator = assignedNull as string;
            classWithFields.usedInConditionalAccess?.Length.ToString();
            dummy = classWithFields.usedInCoalesceExpression ?? string.Empty;

            ClassWithNullableFieldsDefaultInsteaOfNull.StaticAssignedNull = default;

            if (ClassWithNullableFieldsDefaultInsteaOfNull.StaticComparedEqualToNullOnLeft == default) return;
            if (default == ClassWithNullableFieldsDefaultInsteaOfNull.StaticComparedEqualToNullOnRight) return;
            if (ClassWithNullableFieldsDefaultInsteaOfNull.StaticComparedNotEqualToNullOnLeft != default) return;
            if (default != ClassWithNullableFieldsDefaultInsteaOfNull.StaticComparedNotEqualToNullOnRight) return;

            ClassWithNullableFieldsDefaultInsteaOfNull.StaticAssignedResultOfAsOperator = assignedNull as string;
            ClassWithNullableFieldsDefaultInsteaOfNull.StaticUsedInConditionalAccess?.Length.ToString();
            dummy = ClassWithNullableFieldsDefaultInsteaOfNull.StaticUsedInCoalesceExpression ?? string.Empty;
        }
    }

    public class ClassWithNullableFieldsDefaultInsteaOfNull
    {
        public string intializedToNull = default;

        public string assignedNull;
        public string comparedEqualToNullOnLeft;
        public string comparedEqualToNullOnRight;
        public string comparedNotEqualToNullOnLeft;
        public string comparedNotEqualToNullOnRight;
        public string assignedResultOfAsOperator;
        public string usedInConditionalAccess;
        public string usedInCoalesceExpression;

        public static string StaticAssignedNull;
        public static string StaticComparedEqualToNullOnLeft;
        public static string StaticComparedEqualToNullOnRight;
        public static string StaticComparedNotEqualToNullOnLeft;
        public static string StaticComparedNotEqualToNullOnRight;
        public static string StaticAssignedResultOfAsOperator;
        public static string StaticUsedInConditionalAccess;
        public static string StaticUsedInCoalesceExpression;
    }
}