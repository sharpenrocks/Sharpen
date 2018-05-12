// ReSharper disable All

using System.Collections;
using System.Drawing;

namespace CSharp71.DefaultExpressions.UseDefaultExpressionInOptionalConstructorParameters
{
    public class OptionalConstructorParametersThatAlreadyUseDefaultExpresion<T0>
    {
        OptionalConstructorParametersThatAlreadyUseDefaultExpresion(int i, int p = default) { }
        OptionalConstructorParametersThatAlreadyUseDefaultExpresion(string s, System.Int32 p = default) { }

        OptionalConstructorParametersThatAlreadyUseDefaultExpresion(int i, string p = default) { }
        OptionalConstructorParametersThatAlreadyUseDefaultExpresion(string s, System.String p = default) { }

        OptionalConstructorParametersThatAlreadyUseDefaultExpresion(int i, IEnumerable p = default) { }
        OptionalConstructorParametersThatAlreadyUseDefaultExpresion(string s, System.Collections.IEnumerable p = default) { }

        OptionalConstructorParametersThatAlreadyUseDefaultExpresion(int i, Point p = default) { }
        OptionalConstructorParametersThatAlreadyUseDefaultExpresion(string s, System.Drawing.Point p = default) { }

        OptionalConstructorParametersThatAlreadyUseDefaultExpresion(T0 Bp = default) { }
    }
}