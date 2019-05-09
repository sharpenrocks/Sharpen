using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.Extensions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp80.UsingDeclarations.Analyzers
{
    internal sealed class ReplaceUsingStatementWithUsingDeclarationAnalyzer : ISingleSyntaxTreeAnalyzer
    {
        private ReplaceUsingStatementWithUsingDeclarationAnalyzer() { }

        public static readonly ReplaceUsingStatementWithUsingDeclarationAnalyzer Instance = new ReplaceUsingStatementWithUsingDeclarationAnalyzer();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return Enumerable.Empty<AnalysisResult>();
        }
    }
}