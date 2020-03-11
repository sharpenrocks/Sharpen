using System;
using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;

namespace Sharpen.Engine.Tests.Unit
{
    [TestFixture]
    class SomeSharpenEngineClassTests
    {
        [Test]
        public void DoSomethingWithASyntaxTreeTest()
        {
            const string code = @"class C { }";
            
            var output = new SomeSharpenEngineClass().DoSomethingWithTheSyntaxTree(CSharpSyntaxTree.ParseText(code));

            Console.WriteLine(output);
        }
    }
}