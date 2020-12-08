using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Analysis
{
    internal interface ISingleSyntaxTreeAnalyzer
    {
        IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext);
    }
}