// ReSharper disable All

namespace CSharp70.UseExpressionBodyForGetAccessors
{
    public class EmptyGetAccessors
    {
        public static int StaticIntProperty { get; }
        public static string StaticStringProperty { get; set; }
        public int IntProperty { get; }
        public string StringProperty { get; set; }
    }

    public abstract class BaseClass
    {
    }

    public class EmptyGetAccessorsWithBaseClass : BaseClass
    {
        public static int StaticIntProperty { get; }
        public static string StaticStringProperty { get; set; }
        public int IntProperty { get; }
        public string StringProperty { get; set; }
    }
}