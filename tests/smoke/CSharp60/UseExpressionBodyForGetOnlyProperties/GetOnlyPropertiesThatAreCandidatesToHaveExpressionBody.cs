// ReSharper disable All

// Expected number of suggestions: 12

using System;

namespace CSharp60.UseExpressionBodyForGetOnlyProperties
{
    public class GetOnlyPropertiesThatAreCandidatesToHaveExpressionBody
    {
        public string S { get; }
        private int i;

        public int IntProperty
        {
            get { return i; }
        }
        public string StringProperty
        {
            get { return S ?? throw new ArgumentNullException(nameof(S)); }
        }
        public double DoubleProperty
        {
            get { return Convert.ToDouble(S.ToUpper().ToLower()); }
        }
    }

    public class GetOnlyPropertiesWithBodiedGetAccessorsThatAreCandidatesToHaveExpressionBody
    {
        public string S { get; }
        private int i;

        public int IntProperty
        {
            get => i;
        }
        public string StringProperty
        {
            get => S ?? throw new ArgumentNullException(nameof(S));
        }
        public double DoubleProperty
        {
            get => Convert.ToDouble(S.ToUpper().ToLower());
        }
    }

    public class GetOnlyPropertiesThatAreCandidatesToHaveExpressionBodyWithComments
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
        }
        public string StringProperty
        {
            get
            {
                // This is some comment.
                return S ?? throw new ArgumentNullException(nameof(S));
            }
        }
        public double DoubleProperty
        {
            get
            {
                // This is some comment.
                return Convert.ToDouble(S.ToUpper().ToLower());
            }
        }
    }

    public class GetOnlyPropertiesWithBodiedGetAccessorsThatAreCandidatesToHaveExpressionBodyWithComments
    {
        public string S { get; }
        private int i;

        public int IntProperty
        {
            // This is some comment.
            get =>
                // This is some comment.
                i;
        }
        public string StringProperty
        {
            // This is some comment.
            get =>
                // This is some comment.
                S ?? throw new ArgumentNullException(nameof(S));
        }
        public double DoubleProperty
        {
            // This is some comment.
            get =>
                // This is some comment.
                Convert.ToDouble(S.ToUpper().ToLower());
        }
    }
}