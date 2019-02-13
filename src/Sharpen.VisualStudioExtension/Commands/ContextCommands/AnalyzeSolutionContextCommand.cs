using System;
using Sharpen.Engine.Analysis;

namespace Sharpen.VisualStudioExtension.Commands.ContextCommands
{
    internal sealed class AnalyzeSolutionContextCommand : BaseAnalyzeCommand<AnalyzeSolutionContextCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("BE887A1D-5356-4D04-8D61-65479E35BB3C");

        private AnalyzeSolutionContextCommand(SharpenExtensionService sharpenExtensionService, ICommandServicesContainer commandServicesContainer)
            : base(sharpenExtensionService, commandServicesContainer, CommandId, CommandSet, true) { }

        public static void Initialize(SharpenExtensionService sharpenExtensionService, ICommandServicesContainer commandServicesContainer)
        {
            Instance = new AnalyzeSolutionContextCommand(sharpenExtensionService, commandServicesContainer);
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