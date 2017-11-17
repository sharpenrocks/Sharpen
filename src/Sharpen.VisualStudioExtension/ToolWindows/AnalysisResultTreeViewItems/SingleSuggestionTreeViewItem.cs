using Sharpen.Engine;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    internal class SingleSuggestionTreeViewItem : BaseTreeViewItem
    {
        private string text;
        public AnalysisResult AnalysisResult { get; }

        public SingleSuggestionTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, AnalysisResult analysisResult)
            : base(parent, treeViewBuilder, 0)
        {
            AnalysisResult = analysisResult;
        }

        public new string Text => text ?? (text = AnalysisResult.DisplayText);
    }
}