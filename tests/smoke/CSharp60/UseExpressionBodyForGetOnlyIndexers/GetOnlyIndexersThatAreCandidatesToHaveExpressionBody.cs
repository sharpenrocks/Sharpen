// ReSharper disable All

// Expected number of suggestions: 12

using System;

namespace CSharp60.UseExpressionBodyForGetOnlyIndexers
{
    public class GetOnlyIndexersThatAreCandidatesToHaveExpressionBody
    {
        public string S { get; }
        private int i;

        public int this[int index]
        {
            get { return i; }
        }
        public string this[string index]
        {
            get { return S ?? throw new ArgumentNullException(nameof(S)); }
        }
        public double this[double index]
        {
            get { return Convert.ToDouble(S.ToUpper().ToLower()); }
        }
    }

    public class GetOnlyIndexersWithBodiedGetAccessorsThatAreCandidatesToHaveExpressionBody
    {
        public string S { get; }
        private int i;

        public int this[int index]
        {
            get => i;
        }
        public string this[string index]
        {
            get => S ?? throw new ArgumentNullException(nameof(S));
        }
        public double this[double index]
        {
            get => Convert.ToDouble(S.ToUpper().ToLower());
        }
    }

    public class GetOnlyIndexersThatAreCandidatesToHaveExpressionBodyWithComments
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
        }
        public string this[string index]
        {
            get
            {
                // This is some comment.
                return S ?? throw new ArgumentNullException(nameof(S));
            }
        }
        public double this[double index]
        {
            get
            {
                // This is some comment.
                return Convert.ToDouble(S.ToUpper().ToLower());
            }
        }
    }

    public class GetOnlyIndexersWithBodiedGetAccessorsThatAreCandidatesToHaveExpressionBodyWithComments
    {
        public string S { get; }
        private int i;

        public int this[int index]
        {
            // This is some comment.
            get =>
                // This is some comment.
                i;
        }
        public string this[string index]
        {
            // This is some comment.
            get =>
                // This is some comment.
                S ?? throw new ArgumentNullException(nameof(S));
        }
        public double this[double index]
        {
            // This is some comment.
            get =>
                // This is some comment.
                Convert.ToDouble(S.ToUpper().ToLower());
        }
    }
}