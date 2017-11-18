using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    internal class FilePathTreeViewItem : BaseTreeViewItem
    {
        public string FilePath { get; }

        public FilePathTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, int numberOfItems, string filePath)
            : base(parent, treeViewBuilder, numberOfItems)
        {
            FilePath = filePath;
            Text = filePath;
        }
    }
}