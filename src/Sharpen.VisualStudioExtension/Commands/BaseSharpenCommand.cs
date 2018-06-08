using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.LanguageServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Sharpen.VisualStudioExtension.ToolWindows;
using Task = System.Threading.Tasks.Task;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal abstract class BaseSharpenCommand<TSharpenCommand> where TSharpenCommand : BaseSharpenCommand<TSharpenCommand>
    {
        protected Package Package { get; }
        protected IServiceProvider ServiceProvider { get; }
        protected VisualStudioWorkspace Workspace { get; }

        protected BaseSharpenCommand(Package package, int commandId, Guid commandSet)
        {
            Package = package ?? throw new ArgumentNullException(nameof(package));

            ServiceProvider = package;

            var componentModel = (IComponentModel)Package.GetGlobalService(typeof(SComponentModel));
            Workspace = componentModel.GetService<VisualStudioWorkspace>();

            if (!(ServiceProvider.GetService(typeof(IMenuCommandService)) is OleMenuCommandService commandService)) return;

            var menuCommandId = new CommandID(commandSet, commandId);
            var menuItem = new MenuCommand(async (sender, e) => await OnExecuteAsync(), menuCommandId);
            commandService.AddCommand(menuItem);
        }

        protected async Task ShowSharpenResultsToolWindowAsync()
        {
            ToolWindowPane window = Package.FindToolWindow(typeof(SharpenResultsToolWindow), 0, true);
            if (window?.Frame == null)
                throw new NotSupportedException($"Cannot create the '{typeof(SharpenResultsToolWindow)}' tool window.");

            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            var windowFrame = (IVsWindowFrame)window.Frame;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }

        protected abstract Task OnExecuteAsync();

        public static TSharpenCommand Instance { get; protected set; }
    }
}