// ReSharper disable All

// Expected number of suggestions: 6

using System;

namespace CSharp70.UseExpressionBodyForGetAccessorsInIndexers
{
    public class GetAccessorsThatAreCandidatesToHaveExpressionBody
    {
        public string S { get; }
        private int i;

        public int this[int index]
        {
            get { return i; }
            set { }
        }
        public string this[string index]
        {
            get { return S ?? throw new ArgumentNullException(nameof(S)); }
            set { }
        }
        public double this[double index]
        {
            get { return Convert.ToDouble(S.ToUpper().ToLower()); }
            set { }
        }
    }

    public class GetAccessorsThatAreCandidatesToHaveExpressionBodyWithComments
    {
        public string S { get; }
        private int i;

        public int this[int index]
        {
            get
            {
                // This is some comment.
                return i;
            }
            set { }
        }
        public string this[string index]
        {
            get
            {
                // This is some comment.
                return S ?? throw new ArgumentNullException(nameof(S));
            }
            set { }
        }
        public double this[double index]
        {
            get
            {
                // This is some comment.
                return Convert.ToDouble(S.ToUpper().ToLower());
            }
            set { }
        }
    }
}