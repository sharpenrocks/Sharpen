// ReSharper disable All

// Expected number of suggestions: 84

using System;

namespace CSharp80.NullableReferenceTypes.EnableNullableContextAndDeclareLocalVariableAsNullable
{
    public class LocalVariableCanBeDeclaredAsNullableDefaultInsteadOfNull
    {
        public LocalVariableCanBeDeclaredAsNullableDefaultInsteadOfNull() // In constructor.
        {
            string detectedOnlyOnce = default;

            string intializedToNull = default(string);
            string initializedToResultOfAsOperator = string.Empty as string;

            string a, bAssignedNull, c;
            string d, e, fInitializedToNull = default;
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

            assignedNull = default(string);
            bAssignedNull = default;
            detectedOnlyOnce = default(string);

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

        public void LocalVariablesInMethod()
        {
            string detectedOnlyOnce = default(string);

            string intializedToNull = default;
            string initializedToResultOfAsOperator = string.Empty as string;

            string a, bAssignedNull, c;
            string d, e, fInitializedToNull = default(string);
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

            assignedNull = default;
            bAssignedNull = default(System.String);
            detectedOnlyOnce = default;

            if (comparedEqualToNullOnLeft == default(System.String)) return;
            if (default == comparedEqualToNullOnRight) return;            
            if (comparedNotEqualToNullOnLeft != default(System.String)) return;
            if (default != comparedNotEqualToNullOnRight) return;
            if (detectedOnlyOnce == default(System.String)) return;
            if (default == detectedOnlyOnce) return;

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
                string detectedOnlyOnce = default(System.String);

                string intializedToNull = default;
                string initializedToResultOfAsOperator = string.Empty as string;

                string a, bAssignedNull, c;
                string d, e, fInitializedToNull = default(System.String);
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

                assignedNull = default;
                bAssignedNull = default(System.String);
                detectedOnlyOnce = default;

                if (comparedEqualToNullOnLeft == default(System.String)) return dummy;
                if (default(System.String) == comparedEqualToNullOnRight) return dummy;
                if (comparedNotEqualToNullOnLeft != default(System.String)) return dummy;
                if (default(System.String) != comparedNotEqualToNullOnRight) return dummy;
                if (detectedOnlyOnce == default(System.String)) return dummy;
                if (default(System.String) == detectedOnlyOnce) return dummy;

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
                string detectedOnlyOnce = default;

                string intializedToNull = default(System.String);
                string initializedToResultOfAsOperator = string.Empty as string;

                string a, bAssignedNull, c;
                string d, e, fInitializedToNull = default(System.String);
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

                assignedNull = default(System.String);
                bAssignedNull = default;
                detectedOnlyOnce = default(System.String);

                if (comparedEqualToNullOnLeft == default(System.String)) return;
                if (default == comparedEqualToNullOnRight) return;
                if (comparedNotEqualToNullOnLeft != default(System.String)) return;
                if (default != comparedNotEqualToNullOnRight) return;
                if (detectedOnlyOnce == default(System.String)) return;
                if (default(System.String) == detectedOnlyOnce) return;

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
                string detectedOnlyOnce = default(System.String);

                string intializedToNull = default;
                string initializedToResultOfAsOperator = string.Empty as string;

                string a, bAssignedNull, c;
                string d, e, fInitializedToNull = default(System.String);
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

                assignedNull = default(System.String);
                bAssignedNull = default;
                detectedOnlyOnce = default(System.String);

                if (comparedEqualToNullOnLeft == default) return;
                if (default(System.String) == comparedEqualToNullOnRight) return;
                if (comparedNotEqualToNullOnLeft != default) return;
                if (default(System.String) != comparedNotEqualToNullOnRight) return;
                if (detectedOnlyOnce == default(System.String)) return;
                if (default == detectedOnlyOnce) return;

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
                string detectedOnlyOnce = default(System.String);

                string intializedToNull = default;
                string initializedToResultOfAsOperator = string.Empty as string;

                string a, bAssignedNull, c;
                string d, e, fInitializedToNull = default(System.String);
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

                assignedNull = default(System.String);
                bAssignedNull = default;
                detectedOnlyOnce = default(System.String);

                if (comparedEqualToNullOnLeft == default) return;
                if (default(System.String) == comparedEqualToNullOnRight) return;
                if (comparedNotEqualToNullOnLeft != default) return;
                if (default(System.String) != comparedNotEqualToNullOnRight) return;
                if (detectedOnlyOnce == default) return;
                if (default(System.String) == detectedOnlyOnce) return;

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