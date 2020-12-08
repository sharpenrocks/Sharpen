using Sharpen.Engine.Analysis;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    internal sealed class SingleSuggestionTreeViewItem : BaseTreeViewItem
    {
        public IAnalysisResult AnalysisResult { get; }

        public SingleSuggestionTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, IAnalysisResult analysisResult)
            : base(parent, treeViewBuilder, 0, null, null)
        {
            AnalysisResult = analysisResult;
        }

        protected override string GetText() => AnalysisResult.DisplayText; // DisplayText lazy loads the text.
    }
}