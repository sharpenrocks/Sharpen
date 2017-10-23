// ReSharper disable All

namespace CSharp70.UseExpressionBodyForDestructors
{
    public class ClassWithEmptyDestructor
    {
        ~ClassWithEmptyDestructor()
        {
        }
    }

    public abstract class BaseClass
    {
        ~BaseClass()
        {
        }
    }

    public class ClassWithEmptyDestructorWithBaseClass : BaseClass
    {
        ~ClassWithEmptyDestructorWithBaseClass()
        {
        }
    }
}