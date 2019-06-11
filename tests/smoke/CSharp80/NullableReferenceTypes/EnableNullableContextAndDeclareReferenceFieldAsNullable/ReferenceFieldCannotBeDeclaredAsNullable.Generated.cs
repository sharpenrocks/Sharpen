// ReSharper disable All

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareReferenceFieldAsNullable
{
    public class ReferenceFieldCannotBeDeclaredAsNullableGenerated
    {
        private string detectedOnlyOnce = null;

        private string intializedToNull = null;
        private string initializedToResultOfAsOperator = string.Empty as string;

        private string a, bAssignedNull, c;
        private string d, e, fInitializedToNull = null;
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

            assignedNull = null;
            bAssignedNull = null;
            detectedOnlyOnce = null;

            if (comparedEqualToNullOnLeft == null) return;
            if (null == comparedEqualToNullOnRight) return;            
            if (comparedNotEqualToNullOnLeft != null) return;
            if (null != comparedNotEqualToNullOnRight) return;
            if (detectedOnlyOnce == null) return;
            if (null == detectedOnlyOnce) return;

            assignedResultOfAsOperator = assignedNull as string;
            detectedOnlyOnce = assignedNull as string;

            usedInConditionalAccess?.Length.ToString();
            detectedOnlyOnce?.Length.ToString();

            dummy = usedInCoalesceExpression ?? string.Empty;
            dummy = detectedOnlyOnce ?? string.Empty;

            this.assignedNullUsingThis = null;

            if (this.comparedEqualToNullOnLeftUsingThis == null) return;
            if (null == this.comparedEqualToNullOnRightUsingThis) return;
            if (this.comparedNotEqualToNullOnLeftUsingThis != null) return;
            if (null != this.comparedNotEqualToNullOnRightUsingThis) return;

            this.assignedResultOfAsOperatorUsingThis = assignedNull as string;
            this.usedInConditionalAccessUsingThis?.Length.ToString();
            dummy = this.usedInCoalesceExpressionUsingThis ?? string.Empty;

            StaticAssignedNull = null;

            if (StaticComparedEqualToNullOnLeft == null) return;
            if (null == StaticComparedEqualToNullOnRight) return;
            if (StaticComparedNotEqualToNullOnLeft != null) return;
            if (null != StaticComparedNotEqualToNullOnRight) return;

            StaticAssignedResultOfAsOperator = assignedNull as string;
            StaticUsedInConditionalAccess?.Length.ToString();
            dummy = StaticUsedInCoalesceExpression ?? string.Empty;

            ReferenceFieldCannotBeDeclaredAsNullableGenerated.StaticAssignedNullUsingClassName = null;

            if (ReferenceFieldCannotBeDeclaredAsNullableGenerated.StaticComparedEqualToNullOnLeftUsingClassName == null) return;
            if (null == ReferenceFieldCannotBeDeclaredAsNullableGenerated.StaticComparedEqualToNullOnRightUsingClassName) return;
            if (ReferenceFieldCannotBeDeclaredAsNullableGenerated.StaticComparedNotEqualToNullOnLeftUsingClassName != null) return;
            if (null != ReferenceFieldCannotBeDeclaredAsNullableGenerated.StaticComparedNotEqualToNullOnRightUsingClassName) return;

            ReferenceFieldCannotBeDeclaredAsNullableGenerated.StaticAssignedResultOfAsOperatorUsingClassName = assignedNull as string;
            ReferenceFieldCannotBeDeclaredAsNullableGenerated.StaticUsedInConditionalAccessUsingClassName?.Length.ToString();
            dummy = ReferenceFieldCannotBeDeclaredAsNullableGenerated.StaticUsedInCoalesceExpressionUsingClassName ?? string.Empty;

            var classWithFields = new GeneratedClassWithFields();

            classWithFields.assignedNull = null;

            if (classWithFields.comparedEqualToNullOnLeft == null) return;
            if (null == classWithFields.comparedEqualToNullOnRight) return;
            if (classWithFields.comparedNotEqualToNullOnLeft != null) return;
            if (null != classWithFields.comparedNotEqualToNullOnRight) return;

            classWithFields.assignedResultOfAsOperator = assignedNull as string;
            classWithFields.usedInConditionalAccess?.Length.ToString();
            dummy = classWithFields.usedInCoalesceExpression ?? string.Empty;

            GeneratedClassWithFields.StaticAssignedNull = null;

            if (GeneratedClassWithFields.StaticComparedEqualToNullOnLeft == null) return;
            if (null == GeneratedClassWithFields.StaticComparedEqualToNullOnRight) return;
            if (GeneratedClassWithFields.StaticComparedNotEqualToNullOnLeft != null) return;
            if (null != GeneratedClassWithFields.StaticComparedNotEqualToNullOnRight) return;

            GeneratedClassWithFields.StaticAssignedResultOfAsOperator = assignedNull as string;
            GeneratedClassWithFields.StaticUsedInConditionalAccess?.Length.ToString();
            dummy = GeneratedClassWithFields.StaticUsedInCoalesceExpression ?? string.Empty;
        }
    }

    public class GeneratedClassWithFields
    {
        public string intializedToNull = null;

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