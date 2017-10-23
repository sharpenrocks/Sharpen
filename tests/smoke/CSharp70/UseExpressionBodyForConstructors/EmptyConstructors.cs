// ReSharper disable All

namespace CSharp70.UseExpressionBodyForConstructors
{
    public class ClassWithEmptyConstructors
    {
        static ClassWithEmptyConstructors()
        {
        }
        public ClassWithEmptyConstructors()
        {
        }
        public ClassWithEmptyConstructors(int i)
        {
        }
        public ClassWithEmptyConstructors(int i, string s)
        {
        }
        public ClassWithEmptyConstructors(int i, string s, double d) : this(i, s)
        {
        }
        public ClassWithEmptyConstructors(int i, string s, double d, bool b) : this(i, s, d)
        {
        }
    }

    public abstract class BaseClass
    {
        static BaseClass() { }
        protected BaseClass(int i) { }
    }

    public class ClassWithEmptyConstructorsWithBaseClass : BaseClass
    {
        static ClassWithEmptyConstructorsWithBaseClass()
        {
        }
        public ClassWithEmptyConstructorsWithBaseClass() : base(0)
        {    
        }
        public ClassWithEmptyConstructorsWithBaseClass(int i) : base(i)
        {
        }
        public ClassWithEmptyConstructorsWithBaseClass(int i, string s) : base(i)
        {
        }
        public ClassWithEmptyConstructorsWithBaseClass(int i, string s, double d) : this(i, s)
        {
        }
        public ClassWithEmptyConstructorsWithBaseClass(int i, string s, double d, bool b) : this(i, s, d)
        {
        }
    }
}