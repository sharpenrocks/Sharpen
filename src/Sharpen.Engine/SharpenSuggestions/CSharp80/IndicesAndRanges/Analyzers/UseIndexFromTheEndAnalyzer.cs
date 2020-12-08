using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Sharpen.Engine.Analysis;

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