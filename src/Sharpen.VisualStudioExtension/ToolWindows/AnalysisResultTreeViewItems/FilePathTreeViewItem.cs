using Sharpen.Engine;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    internal class FilePathTreeViewItem : BaseTreeViewItem
    {
        public string FilePath { get; }

        public FilePathTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, string filePath, int numberOfItems, AnalysisResult analysisResult = null)
            : base(parent, treeViewBuilder, numberOfItems, analysisResult)
        {
            FilePath = filePath;
            Text = filePath;
        }
    }
}