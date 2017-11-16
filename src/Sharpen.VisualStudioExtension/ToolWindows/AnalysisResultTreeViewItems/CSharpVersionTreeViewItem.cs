using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    internal class CSharpVersionTreeViewItem : BaseTreeViewItem
    {
        public string CSharpVersion { get; }

        public CSharpVersionTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, int numberOfItems, string csharpVersion)
            : base(parent, treeViewBuilder, numberOfItems)
        {
            CSharpVersion = csharpVersion;
            Text = "C# " + csharpVersion;
        }
    }
}