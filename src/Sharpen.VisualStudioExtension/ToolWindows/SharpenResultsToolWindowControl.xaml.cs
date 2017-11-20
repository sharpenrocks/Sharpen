using System.Windows.Controls;
using System.Windows.Input;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems;

namespace Sharpen.VisualStudioExtension.ToolWindows
{
    internal sealed partial class SharpenResultsToolWindowControl
    {
        private readonly ISharpenResultsCommandHandler commandHandler;

        public SharpenResultsToolWindowControl(ISharpenResultsCommandHandler commandHandler)
        {
            InitializeComponent();

            this.commandHandler = commandHandler;
        }

        private void OnResultTreeViewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenResultFile((TreeView)sender);
        }

        private void OnResultTreeViewKeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.Key == Key.Return || e.Key == Key.Space)) return;

            OpenResultFile((TreeView)sender);
        }

        private void OpenResultFile(TreeView resultsTreeView)
        {
            if (resultsTreeView.SelectedItem is SingleSuggestionTreeViewItem singleSuggestion)
            {
                commandHandler.OpenResultFile(singleSuggestion.AnalysisResult.FilePath, singleSuggestion.AnalysisResult.Position);
            }
        }
    }
}