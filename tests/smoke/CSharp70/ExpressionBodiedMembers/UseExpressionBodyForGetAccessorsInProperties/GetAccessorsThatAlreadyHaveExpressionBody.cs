// ReSharper disable All

using System;

namespace CSharp70.ExpressionBodiedMembers.UseExpressionBodyForGetAccessorsInProperties
{
    public class GetAccessorsThatAlreadyHaveExpressionBody
    {
        public string S { get; }
        private int i;

        public int IntProperty
        {
            get => i;
            set { }
        }
        public string StringProperty
        {
            get => S ?? throw new ArgumentNullException(nameof(S));
            set { }
        }
        public double DoubleProperty
        {
            get => Convert.ToDouble(S.ToUpper().ToLower());
            set { }
        }
    }

    public class GetAccessorsThatAlreadyHaveExpressionBodyWithComments
    {
        public string S { get; }
        private int i;

        public int IntProperty
        {
            get =>
                // This is some comment.
                i;
            set { }
        }
        public string StringProperty
        {
            get =>
                // This is some comment.
                S ?? throw new ArgumentNullException(nameof(S));
            set { }
        }
        public double DoubleProperty
        {
            get =>
                // This is some comment.
                Convert.ToDouble(S.ToUpper().ToLower());
            set { }
        }
    }

    public class GetOnlyPropertiesThatAlreadyHaveExpressionBody
    {
        public string S { get; }
        private int i;

        public int IntProperty => i;
        public string StringProperty => S ?? throw new ArgumentNullException(nameof(S));
        public double DoubleProperty => Convert.ToDouble(S.ToUpper().ToLower());
    }
}