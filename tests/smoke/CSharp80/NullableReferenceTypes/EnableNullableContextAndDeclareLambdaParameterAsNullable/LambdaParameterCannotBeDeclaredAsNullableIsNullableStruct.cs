// ReSharper disable All

using System;

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareLambdaParameterAsNullable
{
    public class LambdaParameterCannotBeDeclaredAsNullableIsNullableStruct
    {
        public void Method()
        {
            Action<int?, int?, int?, int?, int?, int?, int?, int?, int?, int?>
                a = (
                    int? setToResultOfAsOperator,
                    int? assignedNull,
                    int? comparedEqualToNullOnLeft,
                    int? comparedEqualToNullOnRight,
                    int? comparedNotEqualToNullOnLeft,
                    int? comparedNotEqualToNullOnRight,
                    int? assignedResultOfAsOperator,
                    int? usedInConditionalAccess,
                    int? usedInCoalesceExpression,
                    int? detectedOnlyOnce
                ) =>
                {
                    detectedOnlyOnce = null;
                    if (detectedOnlyOnce == null) detectedOnlyOnce = 0;

                    setToResultOfAsOperator = 0 as int?;

                    int? dummy;

                    assignedNull = null;
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
                };
        }
    }
}