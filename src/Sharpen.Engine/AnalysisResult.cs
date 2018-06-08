using System;
using Microsoft.CodeAnalysis;
using Sharpen.Engine.Analysis;

namespace Sharpen.Engine
{
    public class AnalysisResult
    {
        private readonly SyntaxNode displayTextNode;
        private readonly Func<SyntaxNode, string> getDisplayText;
        private string displayText;

        public ISharpenSuggestion Suggestion { get; }

        // This will change for sure as soon as we introduce analysis that goes beyond a single syntax tree.
        // But so far so good :-)
        public SingleSyntaxTreeAnalysisContext AnalysisContext { get; } 

        public string FilePath { get; }

        public FileLinePositionSpan Position { get; }

        internal AnalysisResult(ISharpenSuggestion suggestion, SingleSyntaxTreeAnalysisContext analysisContext, string filePath, SyntaxToken startingToken, SyntaxNode displayTextNode)
            : this(suggestion, analysisContext, filePath, startingToken, displayTextNode, Engine.DisplayText.For)
        {
        }

        internal AnalysisResult(ISharpenSuggestion suggestion, SingleSyntaxTreeAnalysisContext analysisContext, string filePath, SyntaxToken startingToken, SyntaxNode displayTextNode, Func<SyntaxNode, string> getDisplayText)
        {
            Suggestion = suggestion;
            AnalysisContext = analysisContext;
            FilePath = filePath;
            this.displayTextNode = displayTextNode;
            this.getDisplayText = getDisplayText;
            Position = startingToken.GetLocation().GetLineSpan();
        }

        public string DisplayText => displayText ?? (displayText = getDisplayText(displayTextNode));
    }
}