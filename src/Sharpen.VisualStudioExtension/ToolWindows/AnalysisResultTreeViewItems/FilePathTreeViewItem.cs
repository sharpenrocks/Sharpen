using System.IO;
using Sharpen.Engine;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    internal sealed class FilePathTreeViewItem : BaseTreeViewItem
    {
        private readonly SingleSyntaxTreeAnalysisContext analysisContext;

        public string FilePath { get; }

        public string ProjectName => analysisContext.ProjectName;

        public FilePathTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, int numberOfItems, SingleSyntaxTreeAnalysisContext analysisContext, string filePath)
            : base(parent, treeViewBuilder, numberOfItems, null)
        {
            this.analysisContext = analysisContext;
            FilePath = filePath;
        }

        protected override string GetText()
        {
            return string.IsNullOrEmpty(analysisContext.LogicalFolderPath)
                ? $"<{analysisContext.ProjectName}>\\{Path.GetFileName(FilePath)}"
                : $"<{analysisContext.ProjectName}>\\{analysisContext.LogicalFolderPath}\\{Path.GetFileName(FilePath)}";
        }
    }
}