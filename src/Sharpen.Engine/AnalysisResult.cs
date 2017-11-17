using Microsoft.CodeAnalysis;

namespace Sharpen.Engine
{
    public class AnalysisResult
    {
        private readonly SyntaxNode displayTextNode;
        private string displayText;

        public ISharpenSuggestion Suggestion { get; }

        public string FilePath { get; }

        public FileLinePositionSpan Position { get; }

        public AnalysisResult(ISharpenSuggestion suggestion, string filePath, SyntaxToken startingToken, SyntaxNode displayTextNode)
        {
            this.displayTextNode = displayTextNode;

            Suggestion = suggestion;
            FilePath = filePath;            
            Position = startingToken.GetLocation().GetLineSpan();
        }

        public string DisplayText => displayText ?? (displayText = Engine.DisplayText.For(displayTextNode));
    }
}