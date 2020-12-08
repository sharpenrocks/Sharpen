using System;
using System.Linq;
using Sharpen.Engine.Analysis;

namespace Sharpen.VisualStudioExtension.Commands.ContextCommands
{
    internal sealed class AnalyzeSelectedDocumentsContextCommand : BaseAnalyzeCommand<AnalyzeSelectedDocumentsContextCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("44C626A3-69B6-4A5A-9C56-DB9CC85AF4F9");

        private AnalyzeSelectedDocumentsContextCommand(ICommandServicesContainer commandServicesContainer)
            : base(commandServicesContainer, CommandId, CommandSet, true) { }

        public static void Initialize(ICommandServicesContainer commandServicesContainer)
        {
            Instance = new AnalyzeSelectedDocumentsContextCommand(commandServicesContainer);
        }

        protected override void IsCommandVisibleAndEnabled(out bool isVisible, out bool isEnabled)
        {
            var selectedItems = VisualStudioIde.GetSelectedVisualStudioItems();

            isVisible = isEnabled = selectedItems.Any(item => item.IsCSharpDocument());
        }

        protected override IScopeAnalyzer GetScopeAnalyzer()
        {
            var selectedCSharpDocuments = VisualStudioIde
                .GetSelectedVisualStudioItems()
                .Where(item => item.IsCSharpDocument())
                .Select(item => item.ProjectItem)
                .Where(projectItem => projectItem != null);

            var documents = Workspace.GetRoslynDocumentsFromVisualStudioProjectItems(selectedCSharpDocuments);

            return ScopeAnalyzerCreator.CreateMultipleDocumentsScopeAnalyzer(documents);
        }
    }
}