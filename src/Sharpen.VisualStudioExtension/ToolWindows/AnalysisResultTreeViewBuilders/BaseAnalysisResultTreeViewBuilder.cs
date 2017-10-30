using System.Collections.Generic;
using Sharpen.Engine;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders
{
    internal abstract class BaseAnalysisResultTreeViewBuilder : IAnalysisResultTreeViewBuilder
    {
        protected IEnumerable<AnalysisResult> AnalysisResults { get; }

        protected BaseAnalysisResultTreeViewBuilder(IEnumerable<AnalysisResult> analysisResults)
        {
            AnalysisResults = analysisResults;
        }

        public abstract IEnumerable<BaseTreeViewItem> GetRootTreeViewItems();
        public abstract IEnumerable<BaseTreeViewItem> GetChildrenTreeViewItemsOf(BaseTreeViewItem parent);
    }
}
