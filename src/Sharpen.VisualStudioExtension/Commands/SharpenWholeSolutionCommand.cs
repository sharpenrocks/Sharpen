using System;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class SharpenWholeSolutionCommand : BaseSharpenCommand<SharpenWholeSolutionCommand>
    {
        public const int CommandId = 0x0100;
        public static readonly Guid CommandSet = new Guid("b5e43671-9e80-4169-beb1-74b688b21375");

        private SharpenWholeSolutionCommand(Package package) : base(package, CommandId, CommandSet) { }

        public static void Initialize(Package package)
        {
            Instance = new SharpenWholeSolutionCommand(package);
        }

        protected override void OnExecute()
        {
            VsShellUtilities.ShowMessageBox(
                ServiceProvider,
                "Sharpen Whole Solution - coming soon :-)",
                "Sharpen",
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);

            ShowSharpenResultsToolWindow();
        }
    }
}