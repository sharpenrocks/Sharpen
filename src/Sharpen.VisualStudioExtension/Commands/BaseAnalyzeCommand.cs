using System;
using Microsoft.VisualStudio.Shell;
using Sharpen.VisualStudioExtension.Extensions;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal abstract class BaseAnalyzeCommand<TAnalyseCommand> : BaseSharpenCommand<TAnalyseCommand> where TAnalyseCommand : BaseSharpenCommand<TAnalyseCommand>
    {
        protected SharpenExtensionService SharpenExtensionService { get; }

        protected BaseAnalyzeCommand(Package package, SharpenExtensionService sharpenExtensionService, int commandId, Guid commandSet) : base(package, commandId, commandSet)
        {
            SharpenExtensionService = sharpenExtensionService;
        }

        protected override void OnExecute()
        {
            if (!Workspace.IsSolutionOpen())
            {
                ShowInformation("There is no solution open. To analyze code, open a solution that contains at least one C# project.");
                return;
            }
            
            ExecuteAnalyzeCommand();
        }

        protected abstract void ExecuteAnalyzeCommand();
    }
}