using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;
using Sharpen.Engine.SharpenSuggestions.CSharp70.OutVariables;

namespace Sharpen.Engine.Tests.Unit.SharpenSuggestions.CSharp70.OutVariables
{
    [TestFixture]
    class UseOutVariablesInMethodInvocationsTests
    {
        private static readonly MetadataReference MscorlibMetadataReference = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        private static readonly MetadataReference SystemMetadataReference = MetadataReference.CreateFromFile(typeof(System.Net.Sockets.Socket).Assembly.Location);

        private static readonly SingleSyntaxTreeAnalysisContext AnalysisContext = new SingleSyntaxTreeAnalysisContext
        (
            nameof(UseOutVariablesInMethodInvocationsTests),
            nameof(UseOutVariablesInMethodInvocationsTests)
        );

        [TestCase("int i; Call( out  i ); i = 0;", "Call( out  i )")]
        [TestCase("int i; { Call( out  i ); } i = 0;", "Call( out  i )")]
        [TestCase("int i; { { Call( out  i ); } } i = 0;", "Call( out  i )")]
        [TestCase("int i; { { { Call( out  i ); } } } i = 0;", "Call( out  i )")]

        [TestCase("int i; int l; Call( out  i ); i = 0;", "Call( out  i )")]
        [TestCase("int i; int l; { Call( out  i ); } i = 0;", "Call( out  i )")]
        [TestCase("int i; int l; { { Call( out  i ); } } i = 0;", "Call( out  i )")]
        [TestCase("int i; int l; { { { Call( out  i ); } } } i = 0;", "Call( out  i )")]

        [TestCase("int i; int l = 0; Call( out  i ); i = 0;", "Call( out  i )")]
        [TestCase("int i; int l = 0; { Call( out  i ); } i = 0;", "Call( out  i )")]
        [TestCase("int i; int l = 0; { { Call( out  i ); } } i = 0;", "Call( out  i )")]
        [TestCase("int i; int l = 0; { { { Call( out  i ); } } } i = 0;", "Call( out  i )")]

        [TestCase("int i; int l = 0; Call(l, out  i ); i = 0;", "Call(l, out  i )")]
        [TestCase("int i; int l = 0; { Call(l, out  i ); } i = 0;", "Call(l, out  i )")]
        [TestCase("int i; int l = 0; { { Call(l, out  i ); } } i = 0;", "Call(l, out  i )")]
        [TestCase("int i; int l = 0; { { { Call(l, out  i ); } } } i = 0;", "Call(l, out  i )")]

        [TestCase("int i; if (Call( out  i )) {  i = 0; }", "Call( out  i )")]
        [TestCase("int i; if (Call( out  i )) { } i = 0;", "Call( out  i )")]
        [TestCase("int i; if (Call( out  i )) { } else { i = 0; }", "Call( out  i )")]
        [TestCase("int i; if (Call( out  i )) { } else { i = 0; } i = 0;", "Call( out  i )")]
        public void Variable_is_not_used_before_passed_as_out_argument_and_is_used_afterwards__analysis_gives_suggestion(string innerCode, string expectedDisplayText)
        {
            var analysisResult = Analyze(innerCode);

            Assert.That(analysisResult.Length, Is.EqualTo(1), innerCode);
            Assert.That(analysisResult[0].DisplayText, Is.EqualTo(expectedDisplayText));
        }

        [TestCase("int i; Call( out  i );")]
        [TestCase("int i; { Call( out  i ); }")]
        [TestCase("int i; { { Call( out  i ); } }")]
        [TestCase("int i; { { { Call( out  i ); } } }")]

        [TestCase("int i; int l; Call( out  i );")]
        [TestCase("int i; int l; { Call( out  i ); }")]
        [TestCase("int i; int l; { { Call( out  i ); } }")]
        [TestCase("int i; int l; { { { Call( out  i ); } } }")]

        [TestCase("int i; int l = 0; Call( out  i );")]
        [TestCase("int i; int l = 0; { Call( out  i ); }")]
        [TestCase("int i; int l = 0; { { Call( out  i ); } }")]
        [TestCase("int i; int l = 0; { { { Call( out  i ); } } }")]

        [TestCase("int i; int l = 0; Call(l, out  i );")]
        [TestCase("int i; int l = 0; { Call(l, out  i ); }")]
        [TestCase("int i; int l = 0; { { Call(l, out  i ); } }")]
        [TestCase("int i; int l = 0; { { { Call(l, out  i ); } } }")]

        [TestCase("int i; if (Call( out  i )) { }")]
        public void Variable_is_not_used_before_passed_as_out_argument_and_is_not_used_afterwards__analysis_does_not_give_suggestions(string innerCode)
        {
            var analysisResult = Analyze(innerCode);

            Assert.That(analysisResult.Length, Is.EqualTo(0));
        }

        [TestCase("int a; Call( out int i );")]
        [TestCase("int a; { Call( out var i ); }")]

        [TestCase("int a; if (Call( out int i )) { }")]
        [TestCase("int a; if (Call( out var i )) { }")]

        [TestCase("int a; if (Call( out int i )) { } else { i = 0; }")]
        [TestCase("int a; if (Call( out var i )) { } else { i = 0; }")]
        public void Method_invocation_already_have_out_variable__analysis_does_not_give_suggestions(string innerCode)
        {
            var analysisResult = Analyze(innerCode);

            Assert.That(analysisResult.Length, Is.EqualTo(0));
        }

        [TestCase("Call( out i );")]
        [TestCase("Func<int, bool> a = i => Call(out i);")]
        public void Out_variable_is_not_a_local_variable__analysis_does_not_give_suggestions(string innerCode)
        {
            var analysisResult = Analyze(innerCode);

            Assert.That(analysisResult.Length, Is.EqualTo(0));
        }

        [TestCase("object o; if (o is int i) { Call( out i ); }")]
        [TestCase("object o; switch (o) { case int i: Call( out i ); break; }")]
        public void Out_variable_is_declared_in_pattern_matching__analysis_does_not_give_suggestions(string innerCode)
        {
            var analysisResult = Analyze(innerCode);

            Assert.That(analysisResult.Length, Is.EqualTo(0));
        }

        [TestCase("int i = 0; Call( out i ); i = 0;")]
        [TestCase("int i; i = 0; Call( out i ); i = 0;")]
        [TestCase("int i; i = 0; { Call( out i ); } i = 0;")]
        [TestCase("int i; i = 0; { { Call( out i ); } } i = 0;")]
        [TestCase("int i; { i = 0; { Call( out i ); } } i = 0;")]
        [TestCase("int i; { { i = 0; Call( out i ); } } i = 0;")]
        [TestCase("int i; Call(i, out i ); i = 0;")]
        public void Variable_is_used_before_passed_as_out_argument_and_is_used_afterwards__analysis_does_not_give_suggestions(string innerCode)
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
	            bool Call(out i) {{ i = 0; return true; }}
                bool Call(int a, out i) {{ i = 0; return true; }}
                int GetInt() => 0;
	        }}";

            var (syntaxTree, semanticModel) = GetSyntaxTreeAndSemanticModelFor(code);

            var analysisResult = UseOutVariablesInMethodInvocations.Instance.Analyze(syntaxTree, semanticModel, AnalysisContext)
                .ToArray();
            return analysisResult;
        }

        private static (SyntaxTree, SemanticModel) GetSyntaxTreeAndSemanticModelFor(string code)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var compilation = CSharpCompilation.Create(
                $"{nameof(UseOutVariablesInMethodInvocationsTests)}",
                new[] { syntaxTree },
                new[] { MscorlibMetadataReference, SystemMetadataReference });
            var semanticModel = compilation.GetSemanticModel(syntaxTree);

            return (syntaxTree, semanticModel);
        }
    }
}
