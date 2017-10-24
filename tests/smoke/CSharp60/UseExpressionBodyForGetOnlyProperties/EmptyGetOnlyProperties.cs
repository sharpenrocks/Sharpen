// ReSharper disable All

namespace CSharp60.UseExpressionBodyForGetOnlyProperties
{
    public class EmptyGetOnlyProperties
    {
        public static int StaticIntProperty { get; }
        public int IntProperty { get; }
    }

    public abstract class BaseClass
    {
    }

    public class EmptyGetOnlyPropertiesWithBaseClass : BaseClass
    {
        public static int StaticIntProperty { get; }
        public int IntProperty { get; }
    }
}