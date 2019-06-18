// ReSharper disable All

// Expected number of suggestions: 12

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareMethodParameterAsNullable
{
    public class MethodParameterCanBeDeclaredAsNullable
    {
        public void Method(
            string setToResultOfAsOperator,
            string assignedNull,
            string comparedEqualToNullOnLeft,
            string comparedEqualToNullOnRight,
            string comparedNotEqualToNullOnLeft,
            string comparedNotEqualToNullOnRight,
            string assignedResultOfAsOperator,
            string usedInConditionalAccess,
            string usedInCoalesceExpression,
            string detectedOnlyOnce = null,
            string hasNullAsDefaultValue = null,
            string hasDefaultAsDefaultValue = default
            )
        {
            detectedOnlyOnce = null;
            if (detectedOnlyOnce == null) detectedOnlyOnce = string.Empty;

            setToResultOfAsOperator = string.Empty as string;

            string dummy;

            assignedNull = null;
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
        }
    }
}