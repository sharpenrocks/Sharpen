using Microsoft.CodeAnalysis;

namespace Sharpen.Engine
{
    public class AnalysisResult
    {
        public ISharpenSuggestion Suggestion { get; }

        public string FilePath { get; }

        public string DisplayText { get; }

        public FileLinePositionSpan Position { get; }

        public AnalysisResult(ISharpenSuggestion suggestion, string filePath, SyntaxToken startingSyntaxToken, string displayText)
        {
            Suggestion = suggestion;
            FilePath = filePath;
            DisplayText = displayText;
            Position = startingSyntaxToken.GetLocation().GetLineSpan();
        }
    }
}