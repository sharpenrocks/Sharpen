using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace Sharpen.Engine
{
    internal interface ISingleSyntaxTreeAnalyzer
    {
        IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree);
    }
}
