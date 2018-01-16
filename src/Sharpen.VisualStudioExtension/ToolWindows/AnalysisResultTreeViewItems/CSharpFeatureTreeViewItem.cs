using Sharpen.Engine;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    internal sealed class CSharpFeatureTreeViewItem : BaseTreeViewItem
    {
        public ICSharpFeature Feature { get; }

        public CSharpFeatureTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, int numberOfItems, ICSharpFeature feature)
            : base(parent, treeViewBuilder, numberOfItems, feature.FriendlyName)
        {
            Feature = feature;
        }
    }
}