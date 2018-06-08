using System;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Shell;
using Sharpen.Engine.Analysis;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class AnalyzeSelectedProjectsCommand : BaseAnalyzeCommand<AnalyzeSelectedProjectsCommand>
    {
        public const int CommandId = 0x300;
        public static readonly Guid CommandSet = new Guid("8E0186D5-53C8-4662-A6B7-BEC6CDDC08DD");

        private AnalyzeSelectedProjectsCommand(Package package, SharpenExtensionService sharpenExtensionService) : base(package, sharpenExtensionService, CommandId, CommandSet) { }

        public static void Initialize(Package package, SharpenExtensionService sharpenExtensionService)
        {
            Instance = new AnalyzeSelectedProjectsCommand(package, sharpenExtensionService);
        }

        protected override IScopeAnalyzer GetScopeAnalyzer()
        {
            // TODO-IG: Display project selection dialog here one day.
            // TODO-IG: Return null if the dialog result is not OK (Cancel button clicked, dialog closed on X, etc.).
            return new MultipleProjectsScopeAnalyzer(new Project[0]);
        }
    }
}