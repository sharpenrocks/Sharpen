using Sharpen.Engine;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    internal class SingleSuggestionTreeViewItem : BaseTreeViewItem
    {
        public AnalysisResult AnalysisResult { get; }

        public SingleSuggestionTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, AnalysisResult analysisResult)
            : base(parent, treeViewBuilder, 0, null)
        {
            AnalysisResult = analysisResult;
        }

        protected override string GetText() => AnalysisResult.DisplayText; // DisplayText lazy loads the text.
    }
}