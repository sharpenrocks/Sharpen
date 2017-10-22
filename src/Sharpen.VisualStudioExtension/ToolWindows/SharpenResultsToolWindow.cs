using System;
using System.IO;
using System.Runtime.InteropServices;
using EnvDTE;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Shell;

namespace Sharpen.VisualStudioExtension.ToolWindows
{
    [Guid("65004bcd-32ae-4aef-934f-e82446ae942c")]
    public sealed class SharpenResultsToolWindow : ToolWindowPane, ISharpenResultsCommandHandler
    {
        private DTE dte;

        public SharpenResultsToolWindow() : base(null)
        {
            Caption = "Sharpen Results";

            var control = new SharpenResultsToolWindowControl(this)
            {
                DataContext = SharpenExtensionService.Instance
            };

            Content = control;
        }

        public override void OnToolWindowCreated()
        {
            dte = (DTE)GetService(typeof(DTE));
        }

        public void OpenResultFile(string filePath, Location location)
        {
            try
            {
                // Things can go wrong here.
                // E.g. it can happen that the file in the result list is not there any more because the result list got stale.
                // In that particular case the ArgumentException will be thrown.
                // In general, the operation is sensitive so let's have a guard here.

                // Still, we want to cover some known cases.
                // Note that we cover them in the try block because the check can as well go wrong ;-)
                if (!File.Exists(filePath))
                {
                    UserInteraction.ShowInformation($"The file '{filePath}' does not exist." +
                                                    $"{Environment.NewLine}{Environment.NewLine}" +
                                                    "This usually means that the Sharpen Results list got stale." +
                                                    $"{Environment.NewLine}{Environment.NewLine}" +
                                                    "Run the Sharpen analysis again to get the actual results.");
                    return;
                }

                dte.ItemOperations.OpenFile(filePath);
            }
            catch
            {
                // In general, if anything goes wrong we will just show a friendly message, regardless of the concrete exception.
                UserInteraction.ShowError($"The file '{filePath}' cannot be opened.{Environment.NewLine}{Environment.NewLine}" +
                                          "Either something unpredictable went wrong or the Sharpen Results list got stale and the file does not exist any more." +
                                          $"{Environment.NewLine}{Environment.NewLine}" +
                                          "Try to run the Sharpen analysis again to get the actual results.");
            }
        }
    }
}