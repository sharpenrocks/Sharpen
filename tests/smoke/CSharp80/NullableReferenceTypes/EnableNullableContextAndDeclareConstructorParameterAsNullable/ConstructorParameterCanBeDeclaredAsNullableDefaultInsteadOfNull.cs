// ReSharper disable All

// Expected number of suggestions: 12

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareConstructorParameterAsNullable
{
    public class ConstructorParameterCanBeDeclaredAsNullableDefaultInsteadOfNull
    {
        public ConstructorParameterCanBeDeclaredAsNullableDefaultInsteadOfNull(
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
            string hasNullAsDefaultValue = default,
            string hasDefaultAsDefaultValue = default
            )
        {
            detectedOnlyOnce = default;
            if (detectedOnlyOnce == default) detectedOnlyOnce = string.Empty;

            setToResultOfAsOperator = string.Empty as string;

            string dummy;

            assignedNull = default;
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
        }
    }
}