using Sharpen.Engine;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    internal class SuggestionTreeViewItem : BaseTreeViewItem
    {
        public ISharpenSuggestion Suggestion { get; }

        public SuggestionTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, int numberOfItems, ISharpenSuggestion suggestion)
            : base(parent, treeViewBuilder, numberOfItems)
        {
            Suggestion = suggestion;
            Text = suggestion.FriendlyName;
        }
    }
}