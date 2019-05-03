// ReSharper disable All

using System.Collections.Generic;

namespace CSharp30.ImplicitlyTypedLocalVariables.UseVarKeywordInVariableDeclarationWithObjectCreation
{
    public class VariableDeclarationsThatAreNotCandidatesToUseVarKeyword
    {
        public void RightAndLeftSideTypesAreNotNotExactlyTheSame()
        {
            IEnumerable<int> list = new List<int>(10000);
            long l = (long)(new int());
        }

        public void VariableDeclarationDeclaresMoreThenOneVariable()
        {
            List<int> first = new List<int>(), second = new List<int>();
        }
    }
}
