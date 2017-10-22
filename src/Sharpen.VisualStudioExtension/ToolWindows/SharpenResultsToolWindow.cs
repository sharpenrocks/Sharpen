using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace Sharpen.VisualStudioExtension.ToolWindows
{
    [Guid("65004bcd-32ae-4aef-934f-e82446ae942c")]
    public sealed class SharpenResultsToolWindow : ToolWindowPane
    {
        public SharpenResultsToolWindow() : base(null)
        {
            Caption = "Sharpen Results";

            var control = new SharpenResultsToolWindowControl { DataContext = SharpenExtensionService.Instance };

            Content = control;
        }
    }
}