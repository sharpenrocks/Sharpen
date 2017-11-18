using System.IO;
using Sharpen.Engine;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    internal class FilePathTreeViewItem : BaseTreeViewItem
    {
        private string text;
        private readonly SingleSyntaxTreeAnalysisContext analysisContext;

        public string FilePath { get; }

        public string ProjectName => analysisContext.ProjectName;

        public FilePathTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, int numberOfItems, SingleSyntaxTreeAnalysisContext analysisContext, string filePath)
            : base(parent, treeViewBuilder, numberOfItems)
        {
            this.analysisContext = analysisContext;
            FilePath = filePath;
        }

        public new string Text => text ?? (text = GetText());

        private string GetText()
        {
            return string.IsNullOrEmpty(analysisContext.LogicalFolderPath)
                ? $"<{analysisContext.ProjectName}>\\{Path.GetFileName(FilePath)}"
                : $"<{analysisContext.ProjectName}>\\{analysisContext.LogicalFolderPath}\\{Path.GetFileName(FilePath)}";
        }
    }
}