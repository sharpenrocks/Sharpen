// ReSharper disable All

// Expected number of suggestions: 7


using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharp30.UseVarInsteadOfPredefinedType
{
    public class DeclarationsThatAreCandidatesForUsingVar
    {
        public void DeclarationsWhereSuggestionsShouldCome()
        {
            int i = new System.Int32();
            List<int> list = new List<int>(10000);
            List<int> list1 = new System.Collections.Generic.List<int>(10000);
            System.Collections.Generic.List<int> list2 = new List<int>(10000);
            CustomClass myObject = new CustomClass(1,2);
            CustomClass myObject1 = new CustomClass { MyProperty = 4 };
            using (StreamReader file = new StreamReader("C:\\myfile.txt")) {

            }
        }

        public void DeclarationsWhereSuggestionsShouldNotCome()
        {
            IEnumerable<int> list = new List<int>(10000);
            long l = (long)(new int());
            List<int> first = new List<int>(), second = new List<int>();
        }
    }

    public class CustomClass
    {
        public CustomClass()
        {

        }
        public CustomClass(int a, int b)
        {

        }
        public int MyProperty { get; set; }
    }
}
