using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.LanguageServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Sharpen.VisualStudioExtension.ToolWindows;
using Task = System.Threading.Tasks.Task;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal abstract class BaseSharpenCommand<TSharpenCommand> where TSharpenCommand : BaseSharpenCommand<TSharpenCommand>
    {
        protected ICommandServicesContainer Services { get; }
        protected VisualStudioWorkspace Workspace => Services.Workspace;
        protected EnvDTE80.DTE2 VisualStudioIde => Services.VisualStudioIde;

        protected BaseSharpenCommand(ICommandServicesContainer commandServicesContainer, int commandId, Guid commandSet, bool isDynamicallyVisibleAndEnabled = false)
        {
            Services = commandServicesContainer;

            CreateAndAddCommand(commandId, commandSet, isDynamicallyVisibleAndEnabled);
        }

        private void CreateAndAddCommand(int commandId, Guid commandSet, bool isDynamicallyVisibleAndEnabled)
        {
            if (Services.MenuCommandService == null) return;

            ThreadHelper.ThrowIfNotOnUIThread();

            var menuCommandId = new CommandID(commandSet, commandId);
            // isDynamicallyVisibleAndEnabled is a bit of redundant information.
            // But it's a simple way to avoid creating OleMenuCommand unless we really need it.
            var menuItem = isDynamicallyVisibleAndEnabled
                ? new OleMenuCommand(async (sender, e) => await OnExecuteAsync(), null, OnBeforeQueryStatus, menuCommandId)
                : new MenuCommand(async (sender, e) => await OnExecuteAsync(), menuCommandId);

            Services.MenuCommandService.AddCommand(menuItem);
        }

        private void OnBeforeQueryStatus(object sender, EventArgs e)
        {
            if (!(sender is OleMenuCommand menuCommand)) return;

            IsCommandVisibleAndEnabled(out bool isVisible, out bool isEnabled);

            menuCommand.Visible = isVisible;
            menuCommand.Enabled = isEnabled;
        }

        protected async Task ShowSharpenResultsToolWindowAsync()
        {
            ToolWindowPane window = Services.Package.FindToolWindow(typeof(SharpenResultsToolWindow), 0, true);
            if (window?.Frame == null)
                throw new NotSupportedException($"Cannot create the '{typeof(SharpenResultsToolWindow)}' tool window.");

            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            var windowFrame = (IVsWindowFrame)window.Frame;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }

        protected abstract Task OnExecuteAsync();

        protected virtual void IsCommandVisibleAndEnabled(out bool isVisible, out bool isEnabled)
        {
            isVisible = true;
            isEnabled = true;
        }

        public static TSharpenCommand Instance { get; protected set; }
    }
}