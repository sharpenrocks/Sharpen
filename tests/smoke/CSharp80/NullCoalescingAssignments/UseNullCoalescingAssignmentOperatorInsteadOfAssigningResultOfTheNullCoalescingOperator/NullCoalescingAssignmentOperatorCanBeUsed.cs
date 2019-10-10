// ReSharper disable All

// Expected number of suggestions: 12

using System;

namespace CSharp80.NullCoalescingAssignments.UseNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperator
{
    class NullCoalescingAssignmentOperatorCanBeUsed
    {
        private string _text;
        private int? _number;

        public void Parameters(string text, int? number)
        {
            text = text ?? "";
            text = text ?? 123.ToString();

            number = number ?? 0;
            number = number ?? Convert.ToInt32("123");
        }

        public void LocalVariables()
        {
            string text = null;
            text = text ?? "";
            text = text ?? 123.ToString();

            int? number = null;
            number = number ?? 0;
            number = number ?? Convert.ToInt32("123");
        }

        public void InstanceFields()
        {
            _text = _text ?? "";
            _text = _text ?? 123.ToString();

            _number = _number ?? 0;
            _number = _number ?? Convert.ToInt32("123");
        }
    }
}
