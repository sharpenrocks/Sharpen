using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    internal sealed class CSharpVersionTreeViewItem : BaseTreeViewItem
    {
        public string CSharpVersion { get; }

        public CSharpVersionTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, int numberOfItems, string csharpVersion)
            : base(parent, treeViewBuilder, numberOfItems, "C# " + csharpVersion) // TODO: Replace the string creation once the abstraction for the C# version is fully implemented.
        {
            CSharpVersion = csharpVersion;
        }
    }
}