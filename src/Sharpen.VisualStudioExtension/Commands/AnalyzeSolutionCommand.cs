using System;
using Sharpen.Engine.Analysis;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class AnalyzeSolutionCommand : BaseAnalyzeCommand<AnalyzeSolutionCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("8E0186D5-53C8-4662-A6B7-BEC6CDDC08DD");

        private AnalyzeSolutionCommand(SharpenExtensionService sharpenExtensionService, ICommandServicesContainer commandServicesContainer)
            : base(sharpenExtensionService, commandServicesContainer, CommandId, CommandSet) { }

        public static void Initialize(SharpenExtensionService sharpenExtensionService, ICommandServicesContainer commandServicesContainer)
        {
            Instance = new AnalyzeSolutionCommand(sharpenExtensionService, commandServicesContainer);
        }

        protected override IScopeAnalyzer GetScopeAnalyzer()
        {
            return new SolutionScopeAnalyzer(Workspace.CurrentSolution);
        }
    }
}