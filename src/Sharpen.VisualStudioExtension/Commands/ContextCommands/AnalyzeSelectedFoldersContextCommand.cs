using System;
using System.Linq;
using Sharpen.Engine.Analysis;

namespace Sharpen.VisualStudioExtension.Commands.ContextCommands
{
    internal sealed class AnalyzeSelectedFoldersContextCommand : BaseAnalyzeCommand<AnalyzeSelectedFoldersContextCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("D5F51202-BC76-4306-A911-E8B74B87B998");

        private AnalyzeSelectedFoldersContextCommand(SharpenExtensionService sharpenExtensionService, ICommandServicesContainer commandServicesContainer)
            : base(sharpenExtensionService, commandServicesContainer, CommandId, CommandSet, true) { }

        public static void Initialize(SharpenExtensionService sharpenExtensionService, ICommandServicesContainer commandServicesContainer)
        {
            Instance = new AnalyzeSelectedFoldersContextCommand(sharpenExtensionService, commandServicesContainer);
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