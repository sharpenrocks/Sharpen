// ReSharper disable All

using System;
using System.Windows;
using static System.Windows.DependencyProperty;

namespace CSharp60.NameofExpressions.UseNameofExpressionInDependencyPropertyDeclarations
{
    class DependencyPropertyFieldNameDoesNotMachPropertyName
    {
        public static readonly DependencyProperty StringXProperty =
            DependencyProperty . Register ("String", typeof(string), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName));

        public static readonly DependencyProperty DoubleXProperty =
            DependencyProperty. Register("Double", typeof(double), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName),
                new PropertyMetadata());

        public static readonly DependencyProperty FloatXProperty =
            DependencyProperty.Register ("Float", typeof(float), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName),
                new PropertyMetadata(default(float)));

        public static readonly DependencyProperty IntXProperty =
            DependencyProperty . Register
            ("Int", typeof(int), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static readonly DependencyProperty BooleanXProperty =
            DependencyProperty
            .
            Register
            ("Boolean", typeof(bool), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public static readonly DependencyProperty OtherStringXProperty =
            Register("OtherString", typeof(string), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName));

        public static readonly DependencyProperty OtherDoubleXProperty =
            Register("OtherDouble", typeof(double), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName),
                new PropertyMetadata());

        public static readonly DependencyProperty OtherFloatXProperty =
            Register("OtherFloat", typeof(float), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName),
                new PropertyMetadata(default(float)));

        public static readonly DependencyProperty OtherIntXProperty =
            Register("OtherInt", typeof(int), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static readonly DependencyProperty OtherBooleanXProperty =
            Register("OtherBoolean", typeof(bool), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public static readonly System.Windows.DependencyProperty MoreStringXProperty =
            DependencyProperty.Register("MoreString", typeof(string), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName));

        public static readonly System.Windows.DependencyProperty MoreDoubleXProperty =
            DependencyProperty.Register("MoreDouble", typeof(double), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName),
                new PropertyMetadata());

        public static readonly System.Windows.DependencyProperty MoreFloatXProperty =
            DependencyProperty.Register("MoreFloat", typeof(float), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName),
                new PropertyMetadata(default(float)));

        public static readonly System.Windows.DependencyProperty MoreIntXProperty =
            DependencyProperty.Register("MoreInt", typeof(int), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static readonly System.Windows.DependencyProperty MoreBooleanXProperty =
            DependencyProperty.Register("MoreBoolean", typeof(bool), typeof(DependencyPropertyFieldNameDoesNotMachPropertyName),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public string String { get; set; }
        public double Double { get; set; }
        public float Float { get; set; }
        public int Int { get; set; }
        public float Boolean { get; set; }
        public string OtherString { get; set; }
        public double OtherDouble { get; set; }
        public float OtherFloat { get; set; }
        public int OtherInt { get; set; }
        public float OtherBoolean { get; set; }
        public string MoreString { get; set; }
        public double MoreDouble { get; set; }
        public float MoreFloat { get; set; }
        public int MoreInt { get; set; }
        public float MoreBoolean { get; set; }

        public static void OnDependencyPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
        }

        private static object CoerceValueCallback(DependencyObject dependencyObject, object baseValue)
        {
            return null;
        }
    }

    class DependencyPropertyFieldsAreNotStaticAndReadonly
    {
        public static DependencyProperty StringProperty =
            DependencyProperty.Register("String", typeof(string), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly));

        public static DependencyProperty DoubleProperty =
            DependencyProperty.Register("Double", typeof(double), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly),
                new PropertyMetadata());

        public static DependencyProperty FloatProperty =
            DependencyProperty.Register("Float", typeof(float), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly),
                new PropertyMetadata(default(float)));

        public static DependencyProperty IntProperty =
            DependencyProperty.Register
            ("Int", typeof(int), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static DependencyProperty BooleanProperty =
            DependencyProperty
            .
            Register
            ("Boolean", typeof(bool), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public readonly DependencyProperty OtherStringProperty =
            Register("OtherString", typeof(string), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly));

        public readonly DependencyProperty OtherDoubleProperty =
            Register("OtherDouble", typeof(double), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly),
                new PropertyMetadata());

        public readonly DependencyProperty OtherFloatProperty =
            Register("OtherFloat", typeof(float), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly),
                new PropertyMetadata(default(float)));

        public readonly DependencyProperty OtherIntProperty =
            Register("OtherInt", typeof(int), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public readonly DependencyProperty OtherBooleanProperty =
            Register("OtherBoolean", typeof(bool), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public System.Windows.DependencyProperty MoreStringProperty =
            DependencyProperty.Register("MoreString", typeof(string), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly));

        public System.Windows.DependencyProperty MoreDoubleProperty =
            DependencyProperty.Register("MoreDouble", typeof(double), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly),
                new PropertyMetadata());

        public System.Windows.DependencyProperty MoreFloatProperty =
            DependencyProperty.Register("MoreFloat", typeof(float), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly),
                new PropertyMetadata(default(float)));

        public System.Windows.DependencyProperty MoreIntProperty =
            DependencyProperty.Register("MoreInt", typeof(int), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public System.Windows.DependencyProperty MoreBooleanProperty =
            DependencyProperty.Register("MoreBoolean", typeof(bool), typeof(DependencyPropertyFieldsAreNotStaticAndReadonly),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public string String { get; set; }
        public double Double { get; set; }
        public float Float { get; set; }
        public int Int { get; set; }
        public float Boolean { get; set; }
        public string OtherString { get; set; }
        public double OtherDouble { get; set; }
        public float OtherFloat { get; set; }
        public int OtherInt { get; set; }
        public float OtherBoolean { get; set; }
        public string MoreString { get; set; }
        public double MoreDouble { get; set; }
        public float MoreFloat { get; set; }
        public int MoreInt { get; set; }
        public float MoreBoolean { get; set; }

        public static void OnDependencyPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
        }

        private static object CoerceValueCallback(DependencyObject dependencyObject, object baseValue)
        {
            return null;
        }
    }

    class InstancePropertyWithPropertyNameDoesNotExist
    {
        public static readonly DependencyProperty StringProperty =
            DependencyProperty.Register("String", typeof(string), typeof(InstancePropertyWithPropertyNameDoesNotExist));

        public static readonly DependencyProperty DoubleProperty =
            DependencyProperty.Register("Double", typeof(double), typeof(InstancePropertyWithPropertyNameDoesNotExist),
                new PropertyMetadata());

        public static readonly DependencyProperty FloatProperty =
            DependencyProperty.Register("Float", typeof(float), typeof(InstancePropertyWithPropertyNameDoesNotExist),
                new PropertyMetadata(default(float)));

        public static readonly DependencyProperty IntProperty =
            DependencyProperty.Register
            ("Int", typeof(int), typeof(InstancePropertyWithPropertyNameDoesNotExist),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static readonly DependencyProperty BooleanProperty =
            DependencyProperty
            .
            Register
            ("Boolean", typeof(bool), typeof(InstancePropertyWithPropertyNameDoesNotExist),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public static readonly DependencyProperty OtherStringProperty =
            Register("OtherString", typeof(string), typeof(InstancePropertyWithPropertyNameDoesNotExist));

        public static readonly DependencyProperty OtherDoubleProperty =
            Register("OtherDouble", typeof(double), typeof(InstancePropertyWithPropertyNameDoesNotExist),
                new PropertyMetadata());

        public static readonly DependencyProperty OtherFloatProperty =
            Register("OtherFloat", typeof(float), typeof(InstancePropertyWithPropertyNameDoesNotExist),
                new PropertyMetadata(default(float)));

        public static readonly DependencyProperty OtherIntProperty =
            Register("OtherInt", typeof(int), typeof(InstancePropertyWithPropertyNameDoesNotExist),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static readonly DependencyProperty OtherBooleanProperty =
            Register("OtherBoolean", typeof(bool), typeof(InstancePropertyWithPropertyNameDoesNotExist),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public static readonly System.Windows.DependencyProperty MoreStringProperty =
            DependencyProperty.Register("MoreString", typeof(string), typeof(InstancePropertyWithPropertyNameDoesNotExist));

        public static readonly System.Windows.DependencyProperty MoreDoubleProperty =
            DependencyProperty.Register("MoreDouble", typeof(double), typeof(InstancePropertyWithPropertyNameDoesNotExist),
                new PropertyMetadata());

        public static readonly System.Windows.DependencyProperty MoreFloatProperty =
            DependencyProperty.Register("MoreFloat", typeof(float), typeof(InstancePropertyWithPropertyNameDoesNotExist),
                new PropertyMetadata(default(float)));

        public static readonly System.Windows.DependencyProperty MoreIntProperty =
            DependencyProperty.Register("MoreInt", typeof(int), typeof(InstancePropertyWithPropertyNameDoesNotExist),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static readonly System.Windows.DependencyProperty MoreBooleanProperty =
            DependencyProperty.Register("MoreBoolean", typeof(bool), typeof(InstancePropertyWithPropertyNameDoesNotExist),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public string StringX { get; set; }
        public double DoubleX { get; set; }
        public float FloatX { get; set; }
        public int IntX { get; set; }
        public float BooleanX { get; set; }
        public string OtherStringX { get; set; }
        public double OtherDoubleX { get; set; }
        public float OtherFloatX { get; set; }
        public int OtherIntX { get; set; }
        public float OtherBooleanX { get; set; }
        public static string MoreString { get; set; }
        public static double MoreDouble { get; set; }
        public static float MoreFloat { get; set; }
        public static int MoreInt { get; set; }
        public static float MoreBoolean { get; set; }

        public static void OnDependencyPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
        }

        private static object CoerceValueCallback(DependencyObject dependencyObject, object baseValue)
        {
            return null;
        }
    }

    class StaticPropertyFieldIsNotOfTypeDependencyProperty
    {
        public static readonly object StringProperty =
            DependencyProperty.Register("String", typeof(string), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty));

        public static readonly object DoubleProperty =
            DependencyProperty.Register("Double", typeof(double), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty),
                new PropertyMetadata());

        public static readonly object FloatProperty =
            DependencyProperty.Register("Float", typeof(float), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty),
                new PropertyMetadata(default(float)));

        public static readonly object IntProperty =
            DependencyProperty.Register
            ("Int", typeof(int), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static readonly object BooleanProperty =
            DependencyProperty
            .
            Register
            ("Boolean", typeof(bool), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public static readonly object OtherStringProperty =
            Register("OtherString", typeof(string), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty));

        public static readonly object OtherDoubleProperty =
            Register("OtherDouble", typeof(double), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty),
                new PropertyMetadata());

        public static readonly object OtherFloatProperty =
            Register("OtherFloat", typeof(float), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty),
                new PropertyMetadata(default(float)));

        public static readonly object OtherIntProperty =
            Register("OtherInt", typeof(int), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static readonly object OtherBooleanProperty =
            Register("OtherBoolean", typeof(bool), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public static readonly System.Object MoreStringProperty =
            DependencyProperty.Register("MoreString", typeof(string), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty));

        public static readonly System.Object MoreDoubleProperty =
            DependencyProperty.Register("MoreDouble", typeof(double), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty),
                new PropertyMetadata());

        public static readonly System.Object MoreFloatProperty =
            DependencyProperty.Register("MoreFloat", typeof(float), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty),
                new PropertyMetadata(default(float)));

        public static readonly System.Object MoreIntProperty =
            DependencyProperty.Register("MoreInt", typeof(int), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static readonly System.Object MoreBooleanProperty =
            DependencyProperty.Register("MoreBoolean", typeof(bool), typeof(StaticPropertyFieldIsNotOfTypeDependencyProperty),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public string String { get; set; }
        public double Double { get; set; }
        public float Float { get; set; }
        public int Int { get; set; }
        public float Boolean { get; set; }
        public string OtherString { get; set; }
        public double OtherDouble { get; set; }
        public float OtherFloat { get; set; }
        public int OtherInt { get; set; }
        public float OtherBoolean { get; set; }
        public string MoreString { get; set; }
        public double MoreDouble { get; set; }
        public float MoreFloat { get; set; }
        public int MoreInt { get; set; }
        public float MoreBoolean { get; set; }

        public static void OnDependencyPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
        }

        private static object CoerceValueCallback(DependencyObject dependencyObject, object baseValue)
        {
            return null;
        }
    }

    class RegisterMethodIsNotTheRealRegisterMethod
    {
        public class DependencyProperty
        {
            public static System.Windows.DependencyProperty Register(string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata = null)
            {
                return null;
            }
        }

        public static readonly System.Windows.DependencyProperty StringProperty =
            DependencyProperty.Register("String", typeof(string), typeof(RegisterMethodIsNotTheRealRegisterMethod));

        public static readonly System.Windows.DependencyProperty DoubleProperty =
            DependencyProperty.Register("Double", typeof(double), typeof(RegisterMethodIsNotTheRealRegisterMethod),
                new PropertyMetadata());

        public static readonly System.Windows.DependencyProperty FloatProperty =
            DependencyProperty.Register("Float", typeof(float), typeof(RegisterMethodIsNotTheRealRegisterMethod),
                new PropertyMetadata(default(float)));

        public static readonly System.Windows.DependencyProperty IntProperty =
            DependencyProperty.Register
            ("Int", typeof(int), typeof(RegisterMethodIsNotTheRealRegisterMethod),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static readonly System.Windows.DependencyProperty BooleanProperty =
            DependencyProperty
            .
            Register
            ("Boolean", typeof(bool), typeof(RegisterMethodIsNotTheRealRegisterMethod),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public string String { get; set; }
        public double Double { get; set; }
        public float Float { get; set; }
        public int Int { get; set; }
        public float Boolean { get; set; }

        public static void OnDependencyPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
        }

        private static object CoerceValueCallback(DependencyObject dependencyObject, object baseValue)
        {
            return null;
        }
    }

    // This class will have 5 false positives.
    // This is fine. We do not want to cover this case.
    // See the explanantion given in the UseNameofExpressionInDependencyPropertyDeclarations.
    class DependecyPropertyTypeIsNotTheRealDependencyPropertyType
    {
        public class DependencyProperty
        {
            public static implicit operator DependencyProperty(System.Windows.DependencyProperty dependencyProperty)
            {
                return null;
            }
        }

        public static readonly DependencyProperty StringProperty =
            System.Windows.DependencyProperty.Register("String", typeof(string), typeof(RegisterMethodIsNotTheRealRegisterMethod));

        public static readonly DependencyProperty DoubleProperty =
            System.Windows.DependencyProperty.Register("Double", typeof(double), typeof(RegisterMethodIsNotTheRealRegisterMethod),
                new PropertyMetadata());

        public static readonly DependencyProperty FloatProperty =
            System.Windows.DependencyProperty.Register("Float", typeof(float), typeof(RegisterMethodIsNotTheRealRegisterMethod),
                new PropertyMetadata(default(float)));

        public static readonly DependencyProperty IntProperty =
            System.Windows.DependencyProperty.Register
            ("Int", typeof(int), typeof(RegisterMethodIsNotTheRealRegisterMethod),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static readonly DependencyProperty BooleanProperty =
            System.Windows.DependencyProperty
            .
            Register
            ("Boolean", typeof(bool), typeof(RegisterMethodIsNotTheRealRegisterMethod),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public string String { get; set; }
        public double Double { get; set; }
        public float Float { get; set; }
        public int Int { get; set; }
        public float Boolean { get; set; }

        public static void OnDependencyPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
        }

        private static object CoerceValueCallback(DependencyObject dependencyObject, object baseValue)
        {
            return null;
        }
    }
}