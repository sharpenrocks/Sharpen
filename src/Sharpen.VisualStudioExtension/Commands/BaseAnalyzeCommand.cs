using System;
using Microsoft.VisualStudio.Shell;
using Sharpen.Engine.Extensions;
using Task = System.Threading.Tasks.Task;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal abstract class BaseAnalyzeCommand<TAnalyseCommand> : BaseSharpenCommand<TAnalyseCommand>
        where TAnalyseCommand : BaseSharpenCommand<TAnalyseCommand>
    {
        protected SharpenExtensionService SharpenExtensionService { get; }

        protected BaseAnalyzeCommand(Package package, SharpenExtensionService sharpenExtensionService, int commandId, Guid commandSet) : base(package, commandId, commandSet)
        {
            SharpenExtensionService = sharpenExtensionService;
        }

        protected override async Task OnExecuteAsync()
        {
            if (!Workspace.IsSolutionOpen())
            {
                UserInteraction.ShowInformation("There is no solution open. To start code analysis, open a solution that contains at least one C# project.");
                return;
            }

            if (SharpenExtensionService.AnalysisIsRunning)
            {
                UserInteraction.ShowInformation($"An analysis is already running.{Environment.NewLine}" +
                                                "You have to wait until the current analysis is done, before starting a new one.");
                return;
            }

            await ShowSharpenResultsToolWindowAsync();

            await ExecuteAnalysisAsync();
        }

        protected abstract Task ExecuteAnalysisAsync();
    }
}