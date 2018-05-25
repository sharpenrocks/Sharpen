// ReSharper disable All

// Expected number of suggestions: 15

using System.Windows;
using static System.Windows.DependencyProperty;

namespace CSharp60.NameofExpressions.UseNameofExpressionInDependencyPropertyDeclarations
{
    class DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression
    {
        public static readonly DependencyProperty StringProperty;

        public static readonly DependencyProperty DoubleProperty;

        public static readonly DependencyProperty FloatProperty;

        public static readonly DependencyProperty IntProperty;

        public static readonly DependencyProperty BooleanProperty;

        public static readonly DependencyProperty OtherStringProperty;

        public static readonly DependencyProperty OtherDoubleProperty;

        public static readonly DependencyProperty OtherFloatProperty;

        public static readonly DependencyProperty OtherIntProperty;

        public static readonly DependencyProperty OtherBooleanProperty;

        public static readonly System.Windows.DependencyProperty MoreStringProperty;

        public static readonly System.Windows.DependencyProperty MoreDoubleProperty;

        public static readonly System.Windows.DependencyProperty MoreFloatProperty;

        public static readonly System.Windows.DependencyProperty MoreIntProperty;

        public static readonly System.Windows.DependencyProperty MoreBooleanProperty;

        static DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression()
        {
            StringProperty =
            DependencyProperty.Register("String", typeof(string), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression));

            DoubleProperty =
                        DependencyProperty.Register("Double", typeof(double), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression),
                            new PropertyMetadata());

            FloatProperty =
                        DependencyProperty.Register("Float", typeof(float), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression),
                            new PropertyMetadata(default(float)));

            IntProperty =
                        DependencyProperty.Register("Int", typeof(int), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression),
                            new PropertyMetadata(default(int), OnDependencyPropertyChanged));

            BooleanProperty =
                        DependencyProperty.Register("Boolean", typeof(bool), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression),
                            new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

            OtherStringProperty =
                        Register("OtherString", typeof(string), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression));

            OtherDoubleProperty =
                        Register("OtherDouble", typeof(double), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression),
                            new PropertyMetadata());

            OtherFloatProperty =
                        Register("OtherFloat", typeof(float), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression),
                            new PropertyMetadata(default(float)));

            OtherIntProperty =
                        Register("OtherInt", typeof(int), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression),
                            new PropertyMetadata(default(int), OnDependencyPropertyChanged));

            OtherBooleanProperty =
                        Register("OtherBoolean", typeof(bool), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression),
                            new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

            MoreStringProperty =
                        DependencyProperty.Register("MoreString", typeof(string), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression));

            MoreDoubleProperty =
                        DependencyProperty.Register("MoreDouble", typeof(double), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression),
                            new PropertyMetadata());

            MoreFloatProperty =
                        DependencyProperty.Register("MoreFloat", typeof(float), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression),
                            new PropertyMetadata(default(float)));

            MoreIntProperty =
                        DependencyProperty.Register("MoreInt", typeof(int), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression),
                            new PropertyMetadata(default(int), OnDependencyPropertyChanged));

            MoreBooleanProperty =
                        DependencyProperty.Register("MoreBoolean", typeof(bool), typeof(DependencyPropertyDeclarationsInConstructorThatAreCandidatesToUseNameofExpression),
                            new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));
        }


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