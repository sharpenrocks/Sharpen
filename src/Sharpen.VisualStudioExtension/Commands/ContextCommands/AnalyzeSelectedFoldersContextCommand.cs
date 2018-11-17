using System;
using System.Linq;
using Microsoft.VisualStudio.Shell;
using Sharpen.Engine.Analysis;

namespace Sharpen.VisualStudioExtension.Commands.ContextCommands
{
    internal sealed class AnalyzeSelectedFoldersContextCommand : BaseAnalyzeCommand<AnalyzeSelectedFoldersContextCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("D5F51202-BC76-4306-A911-E8B74B87B998");

        private AnalyzeSelectedFoldersContextCommand(Package package, SharpenExtensionService sharpenExtensionService) : base(package, sharpenExtensionService, CommandId, CommandSet, true) { }

        public static void Initialize(Package package, SharpenExtensionService sharpenExtensionService)
        {
            Instance = new AnalyzeSelectedFoldersContextCommand(package, sharpenExtensionService);
        }

        protected override void IsCommandVisibleAndEnabled(out bool isVisible, out bool isEnabled)
        {
            isVisible = isEnabled = true;
        }

        protected override IScopeAnalyzer GetScopeAnalyzer()
        {
            var selectedCSharpDocuments = VisualStudioIde
                .GetSelectedVisualStudioProjectItemsWithSubItems()
                .Where(item => item.IsCSharpDocument());

            var documents = Workspace.GetRoslynDocumentsFromVisualStudioProjectItems(selectedCSharpDocuments);

            return new MultipleDocumentsScopeAnalyzer(documents);
        }
    }
}