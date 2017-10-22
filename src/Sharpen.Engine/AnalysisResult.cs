using Microsoft.CodeAnalysis;

namespace Sharpen.Engine
{
    public class AnalysisResult
    {
        public ISharpenSuggestion Suggestion { get; }

        public string FilePath { get; }

        public FileLinePositionSpan Position { get; }

        public AnalysisResult(ISharpenSuggestion suggestion, string filePath, SyntaxToken startingSyntaxToken)
        {
            Suggestion = suggestion;
            FilePath = filePath;
            Position = startingSyntaxToken.GetLocation().GetLineSpan();
        }
    }
}