using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.SharpenSuggestions.CSharp30.ImplicitlyTypedLocalVariables;

namespace Sharpen.Engine.Tests.Unit.SharpenSuggestions.CSharp30.ImplicitlyTypedLocalVariables
{
    [TestFixture]
    class UseVarKeywordInVariableDeclarationWithObjectCreationTests
    {
        private static readonly MetadataReference MscorlibMetadataReference = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        private static readonly MetadataReference SystemMetadataReference = MetadataReference.CreateFromFile(typeof(System.Net.Sockets.Socket).Assembly.Location);

        private static readonly SingleSyntaxTreeAnalysisContext AnalysisContext = new SingleSyntaxTreeAnalysisContext
        (
            nameof(UseVarKeywordInVariableDeclarationWithObjectCreation),
            nameof(UseVarKeywordInVariableDeclarationWithObjectCreation)
        );

        [TestCase("int i = new System.Int32();", "int i = new System.Int32()")]
        [TestCase("List<int> list = new List<int>(10000);", "List<int> list = new List<int>(10000)")]
        [TestCase("List<int> list = new System.Collections.Generic.List<int>(10000);", "List<int> list = new System.Collections.Generic.List<int>(10000)")]
        [TestCase("System.Collections.Generic.List<int> list = new List<int>(10000);", "System.Collections.Generic.List<int> list = new List<int>(10000)")]
        [TestCase("CustomClass myObject = new CustomClass(1,2);", "CustomClass myObject = new CustomClass(1,2)")]
        [TestCase("CustomClass myObject1 = new CustomClass { MyProperty = 4 };", "CustomClass myObject1 = new CustomClass { MyProperty = 4 }")]
        [TestCase(@"using (StreamReader file = new StreamReader(""C:\\myfile.txt"")) {}", @"StreamReader file = new StreamReader(""C:\\myfile.txt"")")]
        public void Left_side_type_exactly_the_same_as_right_hand_type__analysis_gives_suggestion(string innerCode, string expectedDisplayText)
        {
            var analysisResult = Analyze(innerCode);

            Assert.That(analysisResult.Length, Is.EqualTo(1), innerCode);
            Assert.That(analysisResult[0].DisplayText, Is.EqualTo(expectedDisplayText));
        }

        [TestCase("IEnumerable<int> list = new List<int>(10000);")]
        [TestCase("long l = (long)(new int());")]
        public void Left_side_type_not_exactly_the_same_as_right_hand_type__analysis_does_not_give_suggestion(string innerCode)
        {
            var analysisResult = Analyze(innerCode);

            Assert.That(analysisResult.Length, Is.EqualTo(0));
        }

        [TestCase("List<int> first = new List<int>(), second = new List<int>();")]
        public void Multiple_variables_declared_in_a_single_declaration__analysis_does_not_give_suggestion(string innerCode)
        {
            var analysisResult = Analyze(innerCode);

            Assert.That(analysisResult.Length, Is.EqualTo(0));
        }

        private static AnalysisResult[] Analyze(string innerCode)
        {
            var code = $@"
            using System;
            using System.Collections.Generic; 

            class Class
	        {{
	            void Method()
	            {{
                    {innerCode}
	            }}
	        }}

            class CustomClass
            {{
                public int Property {{ get; set; }}
    
                public CustomClass()
                {{
                }}
                
                public CustomClass(int a, int b)
                {{
                }}
            }}";

            var (syntaxTree, semanticModel) = GetSyntaxTreeAndSemanticModelFor(code);

            var analysisResult = UseVarKeywordInVariableDeclarationWithObjectCreation.Instance.Analyze(syntaxTree, semanticModel, AnalysisContext)
                .ToArray();
            return analysisResult;
        }

        private static (SyntaxTree, SemanticModel) GetSyntaxTreeAndSemanticModelFor(string code)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var compilation = CSharpCompilation.Create(
                $"{nameof(UseVarKeywordInVariableDeclarationWithObjectCreation)}",
                new[] { syntaxTree },
                new[] { MscorlibMetadataReference, SystemMetadataReference });
            var semanticModel = compilation.GetSemanticModel(syntaxTree);

            return (syntaxTree, semanticModel);
        }
    }
}
