using System;
using Microsoft.VisualStudio.Shell;
using Sharpen.Engine.Analysis;

namespace Sharpen.VisualStudioExtension.Commands.ContextCommands
{
    internal sealed class AnalyzeSolutionContextCommand : BaseAnalyzeCommand<AnalyzeSolutionContextCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("BE887A1D-5356-4D04-8D61-65479E35BB3C");

        private AnalyzeSolutionContextCommand(Package package, SharpenExtensionService sharpenExtensionService) : base(package, sharpenExtensionService, CommandId, CommandSet, true) { }

        public static void Initialize(Package package, SharpenExtensionService sharpenExtensionService)
        {
            Instance = new AnalyzeSolutionContextCommand(package, sharpenExtensionService);
        }

        protected override void IsCommandVisibleAndEnabled(out bool isVisible, out bool isEnabled)
        {
            isVisible = true;
            isEnabled = Workspace.CurrentSolution?.ProjectIds.Count > 0;
        }

        protected override IScopeAnalyzer GetScopeAnalyzer()
        {
            return new SolutionScopeAnalyzer(Workspace.CurrentSolution);
        }
    }
}