using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    internal class FilePathTreeViewItem : BaseTreeViewItem
    {
        public string FilePath { get; }

        public FilePathTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, string filePath, bool isLeaf = false)
            : base(parent, treeViewBuilder, isLeaf)
        {
            FilePath = filePath;
            Text = filePath;
        }
    }
}