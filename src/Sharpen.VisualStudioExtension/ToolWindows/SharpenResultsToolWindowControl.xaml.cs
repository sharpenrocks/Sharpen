using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.CodeAnalysis;
using Sharpen.Engine;

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

        private void OnResultListViewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var resultsList = (ListView) sender;

            if (resultsList.SelectedItem is AnalysisResult selectedAnalysisResult)
            {
                commandHandler.OpenResultFile(selectedAnalysisResult.FilePath, selectedAnalysisResult.Position);
            }
        }
    }
}