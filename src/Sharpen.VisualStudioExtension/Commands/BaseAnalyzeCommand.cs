using System;
using Microsoft.VisualStudio.Shell;
using Sharpen.Engine;
using Sharpen.VisualStudioExtension.Extensions;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal abstract class BaseAnalyzeCommand<TAnalyseCommand> : BaseSharpenCommand<TAnalyseCommand> where TAnalyseCommand : BaseSharpenCommand<TAnalyseCommand>
    {
        protected SharpenEngine SharpenEngine { get; }

        protected BaseAnalyzeCommand(Package package, SharpenEngine sharpenEngine, int commandId, Guid commandSet) : base(package, commandId, commandSet)
        {
            SharpenEngine = sharpenEngine;
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