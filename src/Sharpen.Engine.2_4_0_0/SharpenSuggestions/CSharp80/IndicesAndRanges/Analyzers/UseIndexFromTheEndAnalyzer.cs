using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Semantics;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.Extensions;
using Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp80.IndicesAndRanges.Analyzers
{
    internal sealed class UseIndexFromTheEndAnalyzer : ISingleSyntaxTreeAnalyzer
    {
        private UseIndexFromTheEndAnalyzer() { }

        public static readonly UseIndexFromTheEndAnalyzer Instance = new UseIndexFromTheEndAnalyzer();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return Enumerable.Empty<AnalysisResult>();
        }
    }
}