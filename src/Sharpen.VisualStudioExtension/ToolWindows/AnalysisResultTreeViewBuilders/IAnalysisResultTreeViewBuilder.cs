using System.Collections.Generic;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders
{
    internal interface IAnalysisResultTreeViewBuilder
    {
        IEnumerable<BaseTreeViewItem> GetRootTreeViewItems();
        IEnumerable<BaseTreeViewItem> GetChildrenTreeViewItemsOf(BaseTreeViewItem parent);
    }
}
