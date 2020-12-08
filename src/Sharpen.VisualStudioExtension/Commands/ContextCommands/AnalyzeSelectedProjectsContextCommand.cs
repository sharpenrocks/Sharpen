using System;
using System.Linq;
using Sharpen.Engine.Analysis;

namespace Sharpen.VisualStudioExtension.Commands.ContextCommands
{
    internal sealed class AnalyzeSelectedProjectsContextCommand : BaseAnalyzeCommand<AnalyzeSelectedProjectsContextCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("4E66CB31-B0E2-4974-A8FC-0667A6CC399D");

        private AnalyzeSelectedProjectsContextCommand(ICommandServicesContainer commandServicesContainer)
            : base(commandServicesContainer, CommandId, CommandSet, true) { }

        public static void Initialize(ICommandServicesContainer commandServicesContainer)
        {
            Instance = new AnalyzeSelectedProjectsContextCommand(commandServicesContainer);
        }

        protected override void IsCommandVisibleAndEnabled(out bool isVisible, out bool isEnabled)
        {
            var selectedProjects = VisualStudioIde.GetSelectedVisualStudioProjects();
            isVisible = isEnabled = selectedProjects.Any(project => project.IsCSharpProject());
        }

        protected override IScopeAnalyzer GetScopeAnalyzer()
        {
            var selectedCSharpProjects = VisualStudioIde
                .GetSelectedVisualStudioProjects()
                .Where(project => project.IsCSharpProject());

            var projects = Workspace.GetRoslynProjectsFromVisualStudioProjects(selectedCSharpProjects);

            return ScopeAnalyzerCreator.CreateMultipleProjectsScopeAnalyzer(true, projects.ToArray());
        }
    }
}