// ReSharper disable All

namespace CSharp70.ExpressionBodiedMembers.UseExpressionBodyForLocalFunctions
{
    public class ClassWithEmptyLocalFunctions
    {
        public void Method()
        {
            void EmptyLocalFunction01()
            {
            }

            void EmptyLocalFunction02(int i)
            {
            }

            void EmptyLocalFunction03(string s)
            {
            }
        }
    }
}