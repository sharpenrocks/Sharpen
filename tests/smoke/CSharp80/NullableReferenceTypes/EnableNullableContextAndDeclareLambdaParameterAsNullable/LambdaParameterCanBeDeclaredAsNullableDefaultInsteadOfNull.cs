// ReSharper disable All

// Expected number of suggestions: 10

using System;

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareLambdaParameterAsNullable
{
    public class LambdaParameterCanBeDeclaredAsNullableDefaultInsteadOfNull
    {
        public void Method()
        {
            Action<string, string, string, string, string, string, string, string, string, string>
                a = (
                string setToResultOfAsOperator,
                string assignedNull,
                string comparedEqualToNullOnLeft,
                string comparedEqualToNullOnRight,
                string comparedNotEqualToNullOnLeft,
                string comparedNotEqualToNullOnRight,
                string assignedResultOfAsOperator,
                string usedInConditionalAccess,
                string usedInCoalesceExpression,
                string detectedOnlyOnce
            ) =>
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
            };
        }
    }
}