// ReSharper disable All

using System.Collections;

namespace CSharp71.UseDefaultExpressionInOptionalConstructorParameters
{
    public class OptionalConstructorParametersThatAreNotCandidatesToUseDefaultExpression
    {
        OptionalConstructorParametersThatAreNotCandidatesToUseDefaultExpression(int i, int p = default(short)) { }
        OptionalConstructorParametersThatAreNotCandidatesToUseDefaultExpression(string s, System.Int32 p = default(short)) { }
        OptionalConstructorParametersThatAreNotCandidatesToUseDefaultExpression(double d, int p = default(System.Int16)) { }

        OptionalConstructorParametersThatAreNotCandidatesToUseDefaultExpression(int i, IEnumerable p = default(IList)) { }
        OptionalConstructorParametersThatAreNotCandidatesToUseDefaultExpression(string s, System.Collections.IEnumerable p = default(IList)) { }
        OptionalConstructorParametersThatAreNotCandidatesToUseDefaultExpression(double d, IEnumerable p = default(System.Collections.IList)) { }
    }
}