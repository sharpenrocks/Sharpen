// ReSharper disable All

// Expected number of suggestions: 13

using System.Collections;
using System.Drawing;

namespace CSharp71.UseDefaultExpressionInOptionalMethodParameters
{
    public class OptionalMethodParametersThatAreCandidatesToUseDefaultExpressions
    {
        public void Int01(int p = default(int)) {}
        public void Int02(System.Int32 p = default(int)) { }
        public void Int03(int p = default(System.Int32)) { }

        public void String01(string p = default(string)) { }
        public void String02(System.String p = default(string)) { }
        public void String03(string p = default(System.String)) { }

        public void IEnumerable01(IEnumerable p = default(IEnumerable)) { }
        public void IEnumerable02(System.Collections.IEnumerable p = default(IEnumerable)) { }
        public void IEnumerable03(IEnumerable p = default(System.Collections.IEnumerable)) { }

        public void Point01(Point p = default(Point)) { }
        public void Point02(System.Drawing.Point p = default(Point)) { }
        public void Point03(Point p = default(System.Drawing.Point)) { }

        public void TZero<T0>(T0 p = default(T0)) { }
    }
}