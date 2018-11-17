using System;
using System.Linq;
using Microsoft.VisualStudio.Shell;
using Sharpen.Engine.Analysis;

namespace Sharpen.VisualStudioExtension.Commands.ContextCommands
{
    internal sealed class AnalyzeSelectedDocumentsContextCommand : BaseAnalyzeCommand<AnalyzeSelectedDocumentsContextCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("44C626A3-69B6-4A5A-9C56-DB9CC85AF4F9");

        private AnalyzeSelectedDocumentsContextCommand(Package package, SharpenExtensionService sharpenExtensionService) : base(package, sharpenExtensionService, CommandId, CommandSet, true) { }

        public static void Initialize(Package package, SharpenExtensionService sharpenExtensionService)
        {
            Instance = new AnalyzeSelectedDocumentsContextCommand(package, sharpenExtensionService);
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
                .Where(item => item.IsCSharpDocument());

            var documents = Workspace.GetRoslynDocumentsFromVisualStudioSelectedItems(selectedCSharpDocuments);

            return new MultipleDocumentsScopeAnalyzer(documents.ToArray());
        }
    }
}