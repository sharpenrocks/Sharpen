// ReSharper disable All

// Expected number of suggestions: 15

using System.Windows;
using static System.Windows.DependencyProperty;

namespace CSharp60.NameofExpressions.UseNameofExpressionInDependencyPropertyDeclarations
{
    class DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression
    {
        public static readonly DependencyProperty StringProperty =
            DependencyProperty . Register ("String", typeof(string), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression));

        public static readonly DependencyProperty DoubleProperty =
            DependencyProperty. Register("Double", typeof(double), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata());

        public static readonly DependencyProperty FloatProperty =
            DependencyProperty.Register ("Float", typeof(float), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(float)));

        public static readonly DependencyProperty IntProperty =
            DependencyProperty . Register
            ("Int", typeof(int), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static readonly DependencyProperty BooleanProperty =
            DependencyProperty
            .
            Register
            ("Boolean", typeof(bool), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public static readonly DependencyProperty OtherStringProperty =
            Register("OtherString", typeof(string), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression));

        public static readonly DependencyProperty OtherDoubleProperty =
            Register("OtherDouble", typeof(double), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata());

        public static readonly DependencyProperty OtherFloatProperty =
            Register("OtherFloat", typeof(float), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(float)));

        public static readonly DependencyProperty OtherIntProperty =
            Register("OtherInt", typeof(int), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static readonly DependencyProperty OtherBooleanProperty =
            Register("OtherBoolean", typeof(bool), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public static readonly System.Windows.DependencyProperty MoreStringProperty =
            DependencyProperty.Register("MoreString", typeof(string), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression));

        public static readonly System.Windows.DependencyProperty MoreDoubleProperty =
            DependencyProperty.Register("MoreDouble", typeof(double), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata());

        public static readonly System.Windows.DependencyProperty MoreFloatProperty =
            DependencyProperty.Register("MoreFloat", typeof(float), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(float)));

        public static readonly System.Windows.DependencyProperty MoreIntProperty =
            DependencyProperty.Register("MoreInt", typeof(int), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged));

        public static readonly System.Windows.DependencyProperty MoreBooleanProperty =
            DependencyProperty.Register("MoreBoolean", typeof(bool), typeof(DependencyPropertyDeclarationsInFieldsDeclarationsThatAreCandidatesToUseNameofExpression),
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
}