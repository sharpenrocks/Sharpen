// ReSharper disable All

using System;

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareLocalVariableAsNullable
{
    public class LocalVariableCannotBeDeclaredAsNullableGenerated
    {
        public LocalVariableCannotBeDeclaredAsNullableGenerated() // In constructor.
        {
            string detectedOnlyOnce = null;

            string intializedToNull = null;
            string initializedToResultOfAsOperator = string.Empty as string;

            string a, bAssignedNull, c;
            string d, e, fInitializedToNull = null;
            string gInitializedToResultOfAsOperator = string.Empty as string, h, i;

            string assignedNull;
            string comparedEqualToNullOnLeft = string.Empty;
            string comparedEqualToNullOnRight = string.Empty;
            string comparedNotEqualToNullOnLeft = string.Empty;
            string comparedNotEqualToNullOnRight = string.Empty;
            string assignedResultOfAsOperator;
            string usedInConditionalAccess = string.Empty;
            string usedInCoalesceExpression = string.Empty;

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
        }

        public void LocalVariablesInMethod()
        {
            string detectedOnlyOnce = null;

            string intializedToNull = null;
            string initializedToResultOfAsOperator = string.Empty as string;

            string a, bAssignedNull, c;
            string d, e, fInitializedToNull = null;
            string gInitializedToResultOfAsOperator = string.Empty as string, h, i;

            string assignedNull;
            string comparedEqualToNullOnLeft = string.Empty;
            string comparedEqualToNullOnRight = string.Empty;
            string comparedNotEqualToNullOnLeft = string.Empty;
            string comparedNotEqualToNullOnRight = string.Empty;
            string assignedResultOfAsOperator;
            string usedInConditionalAccess = string.Empty;
            string usedInCoalesceExpression = string.Empty;

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
        }

        public string LocalVariablesInProperty
        {
            get
            {
                string detectedOnlyOnce = null;

                string intializedToNull = null;
                string initializedToResultOfAsOperator = string.Empty as string;

                string a, bAssignedNull, c;
                string d, e, fInitializedToNull = null;
                string gInitializedToResultOfAsOperator = string.Empty as string, h, i;

                string assignedNull;
                string comparedEqualToNullOnLeft = string.Empty;
                string comparedEqualToNullOnRight = string.Empty;
                string comparedNotEqualToNullOnLeft = string.Empty;
                string comparedNotEqualToNullOnRight = string.Empty;
                string assignedResultOfAsOperator;
                string usedInConditionalAccess = string.Empty;
                string usedInCoalesceExpression = string.Empty;

                string dummy = string.Empty;

                assignedNull = null;
                bAssignedNull = null;
                detectedOnlyOnce = null;

                if (comparedEqualToNullOnLeft == null) return dummy;
                if (null == comparedEqualToNullOnRight) return dummy;
                if (comparedNotEqualToNullOnLeft != null) return dummy;
                if (null != comparedNotEqualToNullOnRight) return dummy;
                if (detectedOnlyOnce == null) return dummy;
                if (null == detectedOnlyOnce) return dummy;

                assignedResultOfAsOperator = assignedNull as string;
                detectedOnlyOnce = assignedNull as string;

                usedInConditionalAccess?.Length.ToString();
                detectedOnlyOnce?.Length.ToString();

                dummy = usedInCoalesceExpression ?? string.Empty;
                dummy = detectedOnlyOnce ?? string.Empty;

                return dummy;
            }
        }

        public void LocalVariablesInLocalFunction()
        {
            void LocalFunction()
            {
                string detectedOnlyOnce = null;

                string intializedToNull = null;
                string initializedToResultOfAsOperator = string.Empty as string;

                string a, bAssignedNull, c;
                string d, e, fInitializedToNull = null;
                string gInitializedToResultOfAsOperator = string.Empty as string, h, i;

                string assignedNull;
                string comparedEqualToNullOnLeft = string.Empty;
                string comparedEqualToNullOnRight = string.Empty;
                string comparedNotEqualToNullOnLeft = string.Empty;
                string comparedNotEqualToNullOnRight = string.Empty;
                string assignedResultOfAsOperator;
                string usedInConditionalAccess = string.Empty;
                string usedInCoalesceExpression = string.Empty;

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
            }
        }

        public void LocalVariablesInLambda()
        {
            Action action = () =>
            {
                string detectedOnlyOnce = null;

                string intializedToNull = null;
                string initializedToResultOfAsOperator = string.Empty as string;

                string a, bAssignedNull, c;
                string d, e, fInitializedToNull = null;
                string gInitializedToResultOfAsOperator = string.Empty as string, h, i;

                string assignedNull;
                string comparedEqualToNullOnLeft = string.Empty;
                string comparedEqualToNullOnRight = string.Empty;
                string comparedNotEqualToNullOnLeft = string.Empty;
                string comparedNotEqualToNullOnRight = string.Empty;
                string assignedResultOfAsOperator;
                string usedInConditionalAccess = string.Empty;
                string usedInCoalesceExpression = string.Empty;

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
            };
        }

        public void LocalVariablesInDelegate()
        {
            Action action = delegate()
            {
                string detectedOnlyOnce = null;

                string intializedToNull = null;
                string initializedToResultOfAsOperator = string.Empty as string;

                string a, bAssignedNull, c;
                string d, e, fInitializedToNull = null;
                string gInitializedToResultOfAsOperator = string.Empty as string, h, i;

                string assignedNull;
                string comparedEqualToNullOnLeft = string.Empty;
                string comparedEqualToNullOnRight = string.Empty;
                string comparedNotEqualToNullOnLeft = string.Empty;
                string comparedNotEqualToNullOnRight = string.Empty;
                string assignedResultOfAsOperator;
                string usedInConditionalAccess = string.Empty;
                string usedInCoalesceExpression = string.Empty;

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
            };
        }
    }
}