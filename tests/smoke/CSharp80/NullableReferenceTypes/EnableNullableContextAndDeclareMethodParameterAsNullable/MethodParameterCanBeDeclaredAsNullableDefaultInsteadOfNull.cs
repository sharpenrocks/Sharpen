// ReSharper disable All

// Expected number of suggestions: 12

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareMethodParameterAsNullable
{
    public class MethodParameterCanBeDeclaredAsNullableDefaultInsteadOfNull
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
            string detectedOnlyOnce = default,
            string hasNullAsDefaultValue = default(string),
            string hasDefaultAsDefaultValue = default
            )
        {
            detectedOnlyOnce = default(string);
            if (detectedOnlyOnce == default) detectedOnlyOnce = string.Empty;

            setToResultOfAsOperator = string.Empty as string;

            string dummy;

            assignedNull = default(string);
            detectedOnlyOnce = default;

            if (comparedEqualToNullOnLeft == default(string)) return;
            if (default == comparedEqualToNullOnRight) return;
            if (comparedNotEqualToNullOnLeft != default(string)) return;
            if (default != comparedNotEqualToNullOnRight) return;
            if (detectedOnlyOnce == default(string)) return;
            if (default == detectedOnlyOnce) return;

            assignedResultOfAsOperator = assignedNull as string;
            detectedOnlyOnce = assignedNull as string;

            usedInConditionalAccess?.Length.ToString();
            detectedOnlyOnce?.Length.ToString();

            dummy = usedInCoalesceExpression ?? string.Empty;
            dummy = detectedOnlyOnce ?? string.Empty;
        }
    }
}