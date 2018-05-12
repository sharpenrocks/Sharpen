// ReSharper disable All

using System.Collections;
using System.Drawing;

namespace CSharp71.DefaultExpressions.UseDefaultExpressionInOptionalMethodParameters
{
    public class OptionalMethodParametersThatAlreadyUseDefaultExpression
    {
        public void Int01(int p = default) {}
        public void Int02(System.Int32 p = default) { }

        public void String01(string p = default) { }
        public void String02(System.String p = default) { }

        public void IEnumerable01(IEnumerable p = default) { }
        public void IEnumerable02(System.Collections.IEnumerable p = default) { }

        public void Point01(Point p = default) { }
        public void Point02(System.Drawing.Point p = default) { }

        public void TZero<T0>(T0 p = default) { }
    }
}