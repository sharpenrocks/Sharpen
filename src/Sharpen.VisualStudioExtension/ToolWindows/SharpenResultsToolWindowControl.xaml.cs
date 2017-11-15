using System.Windows.Controls;
using System.Windows.Input;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems;

namespace Sharpen.VisualStudioExtension.ToolWindows
{
    internal partial class SharpenResultsToolWindowControl
    {
        private readonly ISharpenResultsCommandHandler commandHandler;

        public SharpenResultsToolWindowControl(ISharpenResultsCommandHandler commandHandler)
        {
            InitializeComponent();

            this.commandHandler = commandHandler;
        }

        private void OnResultTreeViewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var resultsList = (TreeView)sender;

            if (resultsList.SelectedItem is BaseTreeViewItem treeViewItem && treeViewItem.AnalysisResult != null)
            {
                commandHandler.OpenResultFile(treeViewItem.AnalysisResult.FilePath, treeViewItem.AnalysisResult.Position);
            }
        }
    }
}