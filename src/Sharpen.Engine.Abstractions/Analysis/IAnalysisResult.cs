using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Analysis
{
    public interface IAnalysisResult
    {
        SingleSyntaxTreeAnalysisContext AnalysisContext { get; }
        string DisplayText { get; }
        string FilePath { get; }
        FileLinePositionSpan Position { get; }
        ISharpenSuggestion Suggestion { get; }
    }
}