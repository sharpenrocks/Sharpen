// ReSharper disable All

using System.Collections;

namespace CSharp71.UseDefaultExpressionInOptionalMethodParameters
{
    public class OptionalMethodParametersThatAreNotCandidatesToUseDefaultExpression
    {
        public void Int01(int p = default(short)) {}
        public void Int02(System.Int32 p = default(short)) { }
        public void Int03(int p = default(System.Int16)) { }

        public void IEnumerable01(IEnumerable p = default(IList)) { }
        public void IEnumerable02(System.Collections.IEnumerable p = default(IList)) { }
        public void IEnumerable03(IEnumerable p = default(System.Collections.IList)) { }
    }
}