// ReSharper disable All

using System;

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareLocalVariableAsNullable
{
    public class LocalVariableCannotBeDeclaredAsNullableIsNullableStruct
    {
        public LocalVariableCannotBeDeclaredAsNullableIsNullableStruct() // In constructor.
        {
            int? detectedOnlyOnce = null;

            int? intializedToNull = null;
            int? initializedToResultOfAsOperator = 0 as int?;

            int? a, bAssignedNull, c;
            int? d, e, fInitializedToNull = null;
            int? gInitializedToResultOfAsOperator = 0 as int?, h, i;

            int? assignedNull;
            int? comparedEqualToNullOnLeft = 0;
            int? comparedEqualToNullOnRight = 0;
            int? comparedNotEqualToNullOnLeft = 0;
            int? comparedNotEqualToNullOnRight = 0;
            int? assignedResultOfAsOperator;
            int? usedInConditionalAccess = 0;
            int? usedInCoalesceExpression = 0;

            int? dummy;

            assignedNull = null;
            bAssignedNull = null;
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
        }

        public void LocalVariablesInMethod()
        {
            int? detectedOnlyOnce = null;

            int? intializedToNull = null;
            int? initializedToResultOfAsOperator = 0 as int?;

            int? a, bAssignedNull, c;
            int? d, e, fInitializedToNull = null;
            int? gInitializedToResultOfAsOperator = 0 as int?, h, i;

            int? assignedNull;
            int? comparedEqualToNullOnLeft = 0;
            int? comparedEqualToNullOnRight = 0;
            int? comparedNotEqualToNullOnLeft = 0;
            int? comparedNotEqualToNullOnRight = 0;
            int? assignedResultOfAsOperator;
            int? usedInConditionalAccess = 0;
            int? usedInCoalesceExpression = 0;

            int? dummy;

            assignedNull = null;
            bAssignedNull = null;
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
        }

        public int? LocalVariablesInProperty
        {
            get
            {
                int? detectedOnlyOnce = null;

                int? intializedToNull = null;
                int? initializedToResultOfAsOperator = 0 as int?;

                int? a, bAssignedNull, c;
                int? d, e, fInitializedToNull = null;
                int? gInitializedToResultOfAsOperator = 0 as int?, h, i;

                int? assignedNull;
                int? comparedEqualToNullOnLeft = 0;
                int? comparedEqualToNullOnRight = 0;
                int? comparedNotEqualToNullOnLeft = 0;
                int? comparedNotEqualToNullOnRight = 0;
                int? assignedResultOfAsOperator;
                int? usedInConditionalAccess = 0;
                int? usedInCoalesceExpression = 0;

                int? dummy = 0;

                assignedNull = null;
                bAssignedNull = null;
                detectedOnlyOnce = null;

                if (comparedEqualToNullOnLeft == null) return dummy;
                if (null == comparedEqualToNullOnRight) return dummy;
                if (comparedNotEqualToNullOnLeft != null) return dummy;
                if (null != comparedNotEqualToNullOnRight) return dummy;
                if (detectedOnlyOnce == null) return dummy;
                if (null == detectedOnlyOnce) return dummy;

                assignedResultOfAsOperator = assignedNull as int?;
                detectedOnlyOnce = assignedNull as int?;

                usedInConditionalAccess?.ToString();
                detectedOnlyOnce?.ToString();

                dummy = usedInCoalesceExpression ?? 0;
                dummy = detectedOnlyOnce ?? 0;

                return dummy;
            }
        }

        public void LocalVariablesInLocalFunction()
        {
            void LocalFunction()
            {
                int? detectedOnlyOnce = null;

                int? intializedToNull = null;
                int? initializedToResultOfAsOperator = 0 as int?;

                int? a, bAssignedNull, c;
                int? d, e, fInitializedToNull = null;
                int? gInitializedToResultOfAsOperator = 0 as int?, h, i;

                int? assignedNull;
                int? comparedEqualToNullOnLeft = 0;
                int? comparedEqualToNullOnRight = 0;
                int? comparedNotEqualToNullOnLeft = 0;
                int? comparedNotEqualToNullOnRight = 0;
                int? assignedResultOfAsOperator;
                int? usedInConditionalAccess = 0;
                int? usedInCoalesceExpression = 0;

                int? dummy;

                assignedNull = null;
                bAssignedNull = null;
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
            }
        }

        public void LocalVariablesInLambda()
        {
            Action action = () =>
            {
                int? detectedOnlyOnce = null;

                int? intializedToNull = null;
                int? initializedToResultOfAsOperator = 0 as int?;

                int? a, bAssignedNull, c;
                int? d, e, fInitializedToNull = null;
                int? gInitializedToResultOfAsOperator = 0 as int?, h, i;

                int? assignedNull;
                int? comparedEqualToNullOnLeft = 0;
                int? comparedEqualToNullOnRight = 0;
                int? comparedNotEqualToNullOnLeft = 0;
                int? comparedNotEqualToNullOnRight = 0;
                int? assignedResultOfAsOperator;
                int? usedInConditionalAccess = 0;
                int? usedInCoalesceExpression = 0;

                int? dummy;

                assignedNull = null;
                bAssignedNull = null;
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

        public void LocalVariablesInDelegate()
        {
            Action action = delegate()
            {
                int? detectedOnlyOnce = null;

                int? intializedToNull = null;
                int? initializedToResultOfAsOperator = 0 as int?;

                int? a, bAssignedNull, c;
                int? d, e, fInitializedToNull = null;
                int? gInitializedToResultOfAsOperator = 0 as int?, h, i;

                int? assignedNull;
                int? comparedEqualToNullOnLeft = 0;
                int? comparedEqualToNullOnRight = 0;
                int? comparedNotEqualToNullOnLeft = 0;
                int? comparedNotEqualToNullOnRight = 0;
                int? assignedResultOfAsOperator;
                int? usedInConditionalAccess = 0;
                int? usedInCoalesceExpression = 0;

                int? dummy;

                assignedNull = null;
                bAssignedNull = null;
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