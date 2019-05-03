﻿// ReSharper disable All

using System.Collections.Generic;
using System.IO;

namespace CSharp30.ImplicitlyTypedLocalVariables.UseVarKeywordInVariableDeclarationWithObjectCreation
{
    public class VariableDeclarationsThatAreNotCandidatesToUseVarKeyword
    {
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
            long l = (long)(new int());
        }

        public void VariableDeclarationDeclaresMoreThenOneVariable()
        {
            List<int> first = new List<int>(), second = new List<int>();
        }
    }
}
