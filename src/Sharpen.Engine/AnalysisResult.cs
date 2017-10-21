using Microsoft.CodeAnalysis.Text;

namespace Sharpen.Engine
{
    public class AnalysisResult
    {
        public ISharpenSuggestion Suggestion { get; }

        public string FilePath { get; }

        public TextSpan Location { get; }

        public AnalysisResult(ISharpenSuggestion suggestion, string filePath, TextSpan location)
        {
            Suggestion = suggestion;
            FilePath = filePath;
            Location = location;
        }
    }
}