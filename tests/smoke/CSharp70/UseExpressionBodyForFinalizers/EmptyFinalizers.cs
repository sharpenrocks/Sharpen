// ReSharper disable All

namespace CSharp70.UseExpressionBodyForFinalizers
{
    public class ClassWithEmptyFinalizer
    {
        ~ClassWithEmptyFinalizer()
        {
        }
    }

    public abstract class BaseClass
    {
        ~BaseClass()
        {
        }
    }

    public class ClassWithEmptyFinalizerWithBaseClass : BaseClass
    {
        ~ClassWithEmptyFinalizerWithBaseClass()
        {
        }
    }
}