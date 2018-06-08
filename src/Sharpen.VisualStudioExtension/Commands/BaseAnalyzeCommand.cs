using System;
using Microsoft.VisualStudio.Shell;
using Sharpen.Engine.Analysis;
using Task = System.Threading.Tasks.Task;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal abstract class BaseAnalyzeCommand<TAnalyzeCommand> : BaseSharpenCommand<TAnalyzeCommand>
        where TAnalyzeCommand : BaseSharpenCommand<TAnalyzeCommand>
    {
        protected SharpenExtensionService SharpenExtensionService { get; }

        protected BaseAnalyzeCommand(Package package, SharpenExtensionService sharpenExtensionService, int commandId, Guid commandSet) : base(package, commandId, commandSet)
        {
            SharpenExtensionService = sharpenExtensionService;
        }

        protected override async Task OnExecuteAsync()
        {
            if (SharpenExtensionService.AnalysisIsRunning)
            {
                UserInteraction.ShowInformation($"An analysis is already running.{Environment.NewLine}{Environment.NewLine}" +
                                                "You have to wait until the current analysis is done, before starting a new one.");
                return;
            }

            var scopeAnalyzer = GetScopeAnalyzer();

            if (scopeAnalyzer == null) return;

            if (!scopeAnalyzer.CanExecuteScopeAnalysis(out string errorMessage))
            {
                UserInteraction.ShowInformation(errorMessage);
                return;
            }

            await ShowSharpenResultsToolWindowAsync();

            await SharpenExtensionService.RunScopeAnalysisAsync(scopeAnalyzer);
        }

        // Derived classes can cancel analysis without any additional message displayed to the
        // user by returning null here.
        protected abstract IScopeAnalyzer GetScopeAnalyzer();
    }
}