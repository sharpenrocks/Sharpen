using Sharpen.Engine;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    internal class FilePathTreeViewItem : BaseTreeViewItem
    {
        public string FilePath { get; }

        public FilePathTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, string filePath, AnalysisResult analysisResult = null)
            : base(parent, treeViewBuilder, analysisResult)
        {
            FilePath = filePath;
            Text = filePath;
        }
    }
}