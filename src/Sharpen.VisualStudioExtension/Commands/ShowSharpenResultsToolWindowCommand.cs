using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Sharpen.VisualStudioExtension.ToolWindows;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class ShowSharpenResultsToolWindowCommand
    {
        public const int CommandId = 4129;
        public static readonly Guid CommandSet = new Guid("b5e43671-9e80-4169-beb1-74b688b21375");

        private readonly Package package;
        private IServiceProvider ServiceProvider { get; }

        private ShowSharpenResultsToolWindowCommand(Package package)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            ServiceProvider = package;

            if (ServiceProvider.GetService(typeof(IMenuCommandService)) is OleMenuCommandService commandService)
            {
                var menuCommandId = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(OnMenuItemClicked, menuCommandId);
                commandService.AddCommand(menuItem);
            }
        }

        public static ShowSharpenResultsToolWindowCommand Instance { get; private set; }

        public static void Initialize(Package package)
        {
            Instance = new ShowSharpenResultsToolWindowCommand(package);
        }

        private void OnMenuItemClicked(object sender, EventArgs e)
        {
            ToolWindowPane window = package.FindToolWindow(typeof(SharpenResultsToolWindow), 0, true);
            if (window?.Frame == null)
                throw new NotSupportedException($"Cannot create the '{typeof(SharpenResultsToolWindow)}' tool window.");

            IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }
    }
}
