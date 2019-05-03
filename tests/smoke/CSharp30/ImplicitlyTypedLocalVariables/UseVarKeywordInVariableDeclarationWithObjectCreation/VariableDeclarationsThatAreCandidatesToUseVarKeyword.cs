// ReSharper disable All

// Expected number of suggestions: 8

using System.Collections.Generic;
using System.IO;

namespace CSharp30.ImplicitlyTypedLocalVariables.UseVarKeywordInVariableDeclarationWithObjectCreation
{
    public class VariableDeclarationsThatAreCandidatesToUseVarKeyword
    {
        public void CanUseVarKeyword()
        {
            int a = new int();
            int b = new System.Int32();
            List<int> listA = new List<int>(10000);
            List<int> listB = new System.Collections.Generic.List<int>(10000);
            System.Collections.Generic.List<int> listC = new List<int>(10000);
            CustomClass myObjectA = new CustomClass(1,2);
            CustomClass myObjectB = new CustomClass { MyProperty = 4 };
            using (StreamReader file = new StreamReader("C:\\myfile.txt")) { }
        }
    }

    public class CustomClass
    {
        public CustomClass() { }
        public CustomClass(int a, int b) { }
        public int MyProperty { get; set; }
    }
}
