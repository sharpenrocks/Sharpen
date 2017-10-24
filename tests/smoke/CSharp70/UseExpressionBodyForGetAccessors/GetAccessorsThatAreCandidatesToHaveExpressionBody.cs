// ReSharper disable All

// Expected number of suggestions: 6

using System;

namespace CSharp70.UseExpressionBodyForGetAccessors
{
    public class GetAccessorsThatAreCandidatesToHaveExpressionBody
    {
        public string S { get; }
        private int i;

        public int IntProperty
        {
            get { return i; }
            set { }
        }
        public string StringProperty
        {
            get { return S ?? throw new ArgumentNullException(nameof(S)); }
            set { }
        }
        public double DoubleProperty
        {
            get { return Convert.ToDouble(S.ToUpper().ToLower()); }
            set { }
        }
    }

    public class GetAccessorsThatAreCandidatesToHaveExpressionBodyWithComments
    {
        public string S { get; }
        private int i;

        public int IntProperty
        {
            get
            {
                // This is some comment.
                return i;
            }
            set { }
        }
        public string StringProperty
        {
            get
            {
                // This is some comment.
                return S ?? throw new ArgumentNullException(nameof(S));
            }
            set { }
        }
        public double DoubleProperty
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