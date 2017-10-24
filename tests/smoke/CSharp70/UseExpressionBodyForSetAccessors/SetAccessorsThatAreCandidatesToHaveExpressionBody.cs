// ReSharper disable All

using System;

namespace CSharp70.UseExpressionBodyForSetAccessors
{
    public class SetAccessorsThatAreCandidatesToHaveExpressionBody
    {
        public string S { get; set; }
        private int i;

        public int IntProperty
        {
            get => i;
            set { i = 0; }
        }
        public string StringProperty
        {
            get => S ?? throw new ArgumentNullException(nameof(S));
            set { S = string.Empty ?? throw new ArgumentNullException(nameof(S)); }
        }
        public double DoubleProperty
        {
            get => Convert.ToDouble(S.ToUpper().ToLower());
            set { Convert.ToDouble(S.ToUpper().ToLower()); }
        }
    }

    public class SetAccessorsWithoutGettersThatAreCandidatesToHaveExpressionBody
    {
        public string S { get; set; }
        private int i;

        public int IntProperty
        {
            set { i = 0; }
        }
        public string StringProperty
        {
            set { S = string.Empty ?? throw new ArgumentNullException(nameof(S)); }
        }
        public double DoubleProperty
        {
            set { Convert.ToDouble(S.ToUpper().ToLower()); }
        }
    }

    public class SetAccessorsThatAreCandidatesToHaveExpressionBodyWithComments
    {
        public string S { get; set; }
        private int i;

        public int IntProperty
        {
            get => i;
            set
            {
                // This is some comment.
                i = 0;
            }
        }
        public string StringProperty
        {
            get => S ?? throw new ArgumentNullException(nameof(S));
            set
            {
                // This is some comment.
                S = string.Empty ?? throw new ArgumentNullException(nameof(S));
            }
        }
        public double DoubleProperty
        {
            get => Convert.ToDouble(S.ToUpper().ToLower());
            set
            {
                // This is some comment.
                Convert.ToDouble(S.ToUpper().ToLower());
            }
        }
    }

    public class SetAccessorsWithoutGettersThatAreCandidatesToHaveExpressionBodyWithComments
    {
        public string S { get; set; }
        private int i;

        public int IntProperty
        {
            set
            {
                // This is some comment.
                i = 0;
            }
        }
        public string StringProperty
        {
            set
            {
                // This is some comment.
                S = string.Empty ?? throw new ArgumentNullException(nameof(S));
            }
        }
        public double DoubleProperty
        {
            set
            {
                // This is some comment.
                Convert.ToDouble(S.ToUpper().ToLower());
            }
        }
    }
}