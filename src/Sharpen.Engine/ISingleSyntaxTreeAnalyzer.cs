using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace Sharpen.Engine
{
    public interface ISingleSyntaxTreeAnalyzer
    {
        IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree);
    }
}
