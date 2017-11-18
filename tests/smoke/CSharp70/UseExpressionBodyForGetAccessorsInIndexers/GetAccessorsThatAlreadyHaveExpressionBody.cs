// ReSharper disable All

using System;

namespace CSharp70.UseExpressionBodyForGetAccessorsInIndexers
{
    public class GetAccessorsThatAlreadyHaveExpressionBody
    {
        public string S { get; }
        private int i;

        public int this[int index]
        {
            get => i;
            set { }
        }
        public string this[string index]
        {
            get => S ?? throw new ArgumentNullException(nameof(S));
            set { }
        }
        public double this[double index]
        {
            get => Convert.ToDouble(S.ToUpper().ToLower());
            set { }
        }
    }

    public class GetAccessorsThatAlreadyHaveExpressionBodyWithComments
    {
        public string S { get; }
        private int i;

        public int this[int index]
        {
            get =>
                // This is some comment.
                i;
            set { }
        }
        public string this[string index]
        {
            get =>
                // This is some comment.
                S ?? throw new ArgumentNullException(nameof(S));
            set { }
        }
        public double this[double index]
        {
            get =>
                // This is some comment.
                Convert.ToDouble(S.ToUpper().ToLower());
            set { }
        }
    }

    public class GetOnlyIndexersThatAlreadyHaveExpressionBody
    {
        public string S { get; }
        private int i;

        public int this[int index] => i;
        public string this[string index] => S ?? throw new ArgumentNullException(nameof(S));
        public double this[double index] => Convert.ToDouble(S.ToUpper().ToLower());
    }
}