// ReSharper disable All

using System;

namespace CSharp60.UseExpressionBodyForGetOnlyIndexers
{
    public class GetOnlyIndexersThatAlreadyHaveExpressionBody
    {
        public string S { get; }
        private int i;

        public int this[int index] => i;
        public string this[string index] => S ?? throw new ArgumentNullException(nameof(S));
        public double this[double index] => Convert.ToDouble(S.ToUpper().ToLower());
    }

    public class GetOnlyIndexersThatAlreadyHaveExpressionBodyWithComments
    {
        public string S { get; }
        private int i;

        public int this[int index] =>
                // This is some comment.
                i;
        public string this[string index] =>
                // This is some comment.
                S ?? throw new ArgumentNullException(nameof(S));
        public double this[double index] =>
                // This is some comment.
                Convert.ToDouble(S.ToUpper().ToLower());
    }
}