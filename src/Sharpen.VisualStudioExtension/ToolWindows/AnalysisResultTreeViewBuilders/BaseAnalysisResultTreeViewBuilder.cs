using System.Collections.Generic;
using Sharpen.Engine;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders
{
    internal abstract class BaseAnalysisResultTreeViewBuilder : IAnalysisResultTreeViewBuilder
    {
        // TODO-PERF: Replace the repeated enumeration over the ConcurrentBag with a custom made indexing structure optimized for fast access and low memory footprint.
        //            Currently we repeatedly iterate over the Concurrent bag to get the children and to count the number of items. Terribly inefficient.
        protected IEnumerable<AnalysisResult> AnalysisResults { get; }

        protected BaseAnalysisResultTreeViewBuilder(IEnumerable<AnalysisResult> analysisResults)
        {
            AnalysisResults = analysisResults;
        }

        public abstract IEnumerable<BaseTreeViewItem> BuildRootTreeViewItems();
        public abstract IEnumerable<BaseTreeViewItem> BuildChildrenTreeViewItemsOf(BaseTreeViewItem parent);
    }
}
