// ReSharper disable All

namespace CSharp70.UseExpressionBodyForSetAccessors
{
    public class EmptySetAccessors
    {
        public static string StaticStringProperty { get; set; }
        public string StringProperty { get; set; }
    }

    public abstract class BaseClass
    {
    }

    public class EmptySetAccessorsWithBaseClass : BaseClass
    {
        public static string StaticStringProperty { get; set; }
        public string StringProperty { get; set; }
    }
}