using Microsoft.CodeAnalysis;

namespace Sharpen.Engine
{
    public class AnalysisResult
    {
        private readonly SyntaxNode displayTextNode;
        private string displayText;

        public ISharpenSuggestion Suggestion { get; }

        // This will change for sure as soon as we introduce analysis that goes beyond a single syntax tree.
        // But so far so good :-)
        public SingleSyntaxTreeAnalysisContext AnalysisContext { get; } 

        public string FilePath { get; }

        public FileLinePositionSpan Position { get; }

        internal AnalysisResult(ISharpenSuggestion suggestion, SingleSyntaxTreeAnalysisContext analysisContext, string filePath, SyntaxToken startingToken, SyntaxNode displayTextNode)
        {
            this.displayTextNode = displayTextNode;

            Suggestion = suggestion;
            AnalysisContext = analysisContext;
            FilePath = filePath;            
            Position = startingToken.GetLocation().GetLineSpan();
        }

        public string DisplayText => displayText ?? (displayText = Engine.DisplayText.For(displayTextNode));
    }
}