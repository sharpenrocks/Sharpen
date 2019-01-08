using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.SharpenSuggestions.CSharp30;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpen.Engine.Tests.Unit.SharpenSuggestions.CSharp30.VarKeyword
{
    [TestFixture]
    class UseVarInsteadOfPredefinedTypeTests
    {
        private static readonly MetadataReference MscorlibMetadataReference = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        private static readonly MetadataReference SystemMetadataReference = MetadataReference.CreateFromFile(typeof(System.Net.Sockets.Socket).Assembly.Location);

        private static readonly SingleSyntaxTreeAnalysisContext AnalysisContext = new SingleSyntaxTreeAnalysisContext
        (
            nameof(UseVarInsteadOfPredefinedType),
            nameof(UseVarInsteadOfPredefinedType)
        );


        [TestCase("int i = new System.Int32();")]
        [TestCase("List<int> list = new List<int>(10000);")]
        [TestCase("List<int> list = new System.Collections.Generic.List<int>(10000);")]
        [TestCase("System.Collections.Generic.List<int> list = new List<int>(10000);")]
        [TestCase("CustomClass myObject = new CustomClass(1,2);")]
        [TestCase("CustomClass myObject1 = new CustomClass { MyProperty = 4 };")]
        [TestCase(@" using (StreamReader file = new StreamReader(""C:\\myfile.txt"")) {}")]
        public void Gives_suggestions_if_variable_initialized_with_Object_Creation(string innerCode)
        {
            var analysisResult = Analyze(innerCode);

            Assert.That(analysisResult.Length, Is.EqualTo(1));
        }


        [TestCase("IEnumerable<int> list = new List<int>(10000);")]
        [TestCase("long l = (long)(new int());")]
        [TestCase("List<int> first = new List<int>(), second = new List<int>();")]
        public void No_suggestion_If_type_in_object_creation_not_exactly_same(string innerCode)
        {
            var analysisResult = Analyze(innerCode);

            Assert.That(analysisResult.Length, Is.EqualTo(0));
        }

        private static AnalysisResult[] Analyze(string innerCode)
        {
            var code = $@"
            using System;
            class Class
	        {{
	            void Method()
	            {{
                    {innerCode}
	            }}
	            
	        }}

            class CustomClass
            {{

            public int Property {{get; set;}}

            public CustomClass()
            {{
            }}
            
            public CustomClass(int a, int b)
            {{

            }}

            }}


            ";



            var (syntaxTree, semanticModel) = GetSyntaxTreeAndSemanticModelFor(code);

            var analysisResult = UseVarInsteadOfPredefinedType.Instance.Analyze(syntaxTree, semanticModel, AnalysisContext)
                .ToArray();
            return analysisResult;
        }


        private static (SyntaxTree, SemanticModel) GetSyntaxTreeAndSemanticModelFor(string code)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var compilation = CSharpCompilation.Create(
                $"{nameof(UseVarInsteadOfPredefinedType)}",
                new[] { syntaxTree },
                new[] { MscorlibMetadataReference, SystemMetadataReference });
            var semanticModel = compilation.GetSemanticModel(syntaxTree);

            return (syntaxTree, semanticModel);
        }
    }
}
