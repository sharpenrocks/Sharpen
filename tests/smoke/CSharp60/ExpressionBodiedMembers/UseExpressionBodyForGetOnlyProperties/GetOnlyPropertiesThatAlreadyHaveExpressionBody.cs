// ReSharper disable All

using System;

namespace CSharp60.ExpressionBodiedMembers.UseExpressionBodyForGetOnlyProperties
{
    public class GetOnlyPropertiesThatAlreadyHaveExpressionBody
    {
        public string S { get; }
        private int i;

        public int IntProperty => i;
        public string StringProperty => S ?? throw new ArgumentNullException(nameof(S));
        public double DoubleProperty => Convert.ToDouble(S.ToUpper().ToLower());
    }

    public class GetOnlyPropertiesThatAlreadyHaveExpressionBodyWithComments
    {
        public string S { get; }
        private int i;

        public int IntProperty =>
                // This is some comment.
                i;
        public string StringProperty =>
                // This is some comment.
                S ?? throw new ArgumentNullException(nameof(S));
        public double DoubleProperty =>
                // This is some comment.
                Convert.ToDouble(S.ToUpper().ToLower());
    }
}