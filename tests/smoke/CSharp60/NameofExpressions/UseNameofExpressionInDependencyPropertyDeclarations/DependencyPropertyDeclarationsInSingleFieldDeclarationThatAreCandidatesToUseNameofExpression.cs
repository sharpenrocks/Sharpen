// ReSharper disable All

// Expected number of suggestions: 15

using System.Windows;
using static System.Windows.DependencyProperty;

namespace CSharp60.NameofExpressions.UseNameofExpressionInDependencyPropertyDeclarations
{
    class DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression
    {
        public static readonly DependencyProperty
        StringProperty =
            DependencyProperty . Register ("String", typeof(string), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression)),

        DoubleProperty =
            DependencyProperty.Register ("Double", typeof(double), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata()),

        FloatProperty =
            DependencyProperty. Register("Float", typeof(float), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(float))),

        IntProperty =
            DependencyProperty . Register
            ("Int", typeof(int), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged)),

        BooleanProperty =
            DependencyProperty
            .
            Register            
            ("Boolean", typeof(bool), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));


        public static readonly DependencyProperty
        OtherStringProperty =
            Register("OtherString", typeof(string), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression)),
            
        OtherDoubleProperty =
            Register("OtherDouble", typeof(double), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata()),
        
        OtherFloatProperty =
            Register("OtherFloat", typeof(float), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(float))),
            
        OtherIntProperty =
            Register("OtherInt", typeof(int), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged)),
            
        OtherBooleanProperty =
            Register("OtherBoolean", typeof(bool), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(bool), OnDependencyPropertyChanged, CoerceValueCallback));

        public static readonly System.Windows.DependencyProperty
        MoreStringProperty =
            DependencyProperty.Register("MoreString", typeof(string), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression)),
            
        MoreDoubleProperty =
            DependencyProperty.Register("MoreDouble", typeof(double), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata()),
            
        MoreFloatProperty =
            DependencyProperty.Register("MoreFloat", typeof(float), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(float))),
            
        MoreIntProperty =
            DependencyProperty.Register("MoreInt", typeof(int), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression),
                new PropertyMetadata(default(int), OnDependencyPropertyChanged)),
            
        MoreBooleanProperty =
            DependencyProperty.Register("MoreBoolean", typeof(bool), typeof(DependencyPropertyDeclarationsInSingleFieldDeclarationThatAreCandidatesToUseNameofExpression),
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