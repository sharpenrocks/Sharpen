using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class SharpenWholeSolutionCommand
    {
        public const int CommandId = 0x0100;
        public static readonly Guid CommandSet = new Guid("b5e43671-9e80-4169-beb1-74b688b21375");

        private IServiceProvider ServiceProvider { get; }

        private SharpenWholeSolutionCommand(Package package)
        {
            ServiceProvider = package ?? throw new ArgumentNullException(nameof(package));

            if (ServiceProvider.GetService(typeof(IMenuCommandService)) is OleMenuCommandService commandService)
            {
                var menuCommandId = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(OnMenuItemClicked, menuCommandId);
                commandService.AddCommand(menuItem);
            }
        }

        public static SharpenWholeSolutionCommand Instance { get; private set; }

        public static void Initialize(Package package)
        {
            Instance = new SharpenWholeSolutionCommand(package);
        }

        private void OnMenuItemClicked(object sender, EventArgs e)
        {
            VsShellUtilities.ShowMessageBox(
                ServiceProvider,
                "Sharpen Whole Solution - coming soon :-)",
                "Sharpen",
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }
    }
}