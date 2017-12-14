// ReSharper disable All

// Expected number of suggestions: 13

using System.Collections;
using System.Drawing;

namespace CSharp71.UseDefaultExpressionInOptionalConstructorParameters
{
    public class OptionalConstructorParametersThatAreCandidatesToUseDefaultExpressions<T0>
    {
        OptionalConstructorParametersThatAreCandidatesToUseDefaultExpressions(int i, int p = default(int)) { }
        OptionalConstructorParametersThatAreCandidatesToUseDefaultExpressions(string s, System.Int32 p = default(int)) { }
        OptionalConstructorParametersThatAreCandidatesToUseDefaultExpressions(double d, int p = default(System.Int32)) { }

        OptionalConstructorParametersThatAreCandidatesToUseDefaultExpressions(int i, string p = default(string)) { }
        OptionalConstructorParametersThatAreCandidatesToUseDefaultExpressions(string s, System.String p = default(string)) { }
        OptionalConstructorParametersThatAreCandidatesToUseDefaultExpressions(double d, string p = default(System.String)) { }

        OptionalConstructorParametersThatAreCandidatesToUseDefaultExpressions(int i, IEnumerable p = default(IEnumerable)) { }
        OptionalConstructorParametersThatAreCandidatesToUseDefaultExpressions(string s, System.Collections.IEnumerable p = default(IEnumerable)) { }
        OptionalConstructorParametersThatAreCandidatesToUseDefaultExpressions(double d, IEnumerable p = default(System.Collections.IEnumerable)) { }

        OptionalConstructorParametersThatAreCandidatesToUseDefaultExpressions(int i, Point p = default(Point)) { }
        OptionalConstructorParametersThatAreCandidatesToUseDefaultExpressions(string s, System.Drawing.Point p = default(Point)) { }
        OptionalConstructorParametersThatAreCandidatesToUseDefaultExpressions(double d, Point p = default(System.Drawing.Point)) { }

        OptionalConstructorParametersThatAreCandidatesToUseDefaultExpressions(T0 Bp = default(T0)) { }
    }
}