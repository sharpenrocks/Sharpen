// ReSharper disable All
#pragma warning disable 219
#pragma warning disable 414
#pragma warning disable 168

using System.Collections.Generic;
using System.IO;

namespace CSharp30.ImplicitlyTypedLocalVariables.UseVarKeywordInVariableDeclarationWithObjectCreation
{
    public class VariableDeclarationsThatAreNotCandidatesToUseVarKeyword
    {
        private int _fieldDeclarationCannotUseVar = new int();

        public void AlreadyUsesVarKeyword()
        {
            var a = new int();
            var b = new System.Int32();
            var listA = new List<int>(10000);
            var listB = new System.Collections.Generic.List<int>(10000);
            var listC = new List<int>(10000);
            var myObjectA = new CustomClass(1,2);
            var myObjectB = new CustomClass { MyProperty = 4 };
            using (var file = new StreamReader("C:\\myfile.txt")) { }
        }

        public void UsesDynamicKeyword()
        {
            dynamic a = new int();
            dynamic b = new System.Int32();
            dynamic listA = new List<int>(10000);
            dynamic listB = new System.Collections.Generic.List<int>(10000);
            dynamic listC = new List<int>(10000);
            dynamic myObjectA = new CustomClass(1,2);
            dynamic myObjectB = new CustomClass { MyProperty = 4 };
        }

        public void RightAndLeftSideTypesAreNotNotExactlyTheSame()
        {
            IEnumerable<int> list = new List<int>(10000);
            long lA = (long)(new int());
            long lB = new int();
        }

        public void VariableDeclarationDeclaresMoreThenOneVariable()
        {
            List<int> first = new List<int>(), second = new List<int>();
            int a = new int(), b = new int();
            int c = 0, d = new int();
        }

        public void VariableDeclarationDoesNotHaveOnlyObjectCreation()
        {
            int a = 123;
            int b = 1 + 2 + 3;
            int c = LocalFunction(0) + LocalFunction(0);
            int d = new int() + new int();
            int e = LocalFunction(0);
            int f = LocalFunction(new int());
            int g = (int)(new int());
            int h = new int() * 2;

            int LocalFunction(int i) => i;
        }

        public void VariableDeclarationDoesNotHaveInitialization()
        {
            int a;
            long b;
            List<int> c;
        }
    }
}
