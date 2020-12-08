using System;
using Sharpen.Engine.Analysis;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class AnalyzeSelectedProjectsCommand : BaseAnalyzeCommand<AnalyzeSelectedProjectsCommand>
    {
        public const int CommandId = 0x300;
        public static readonly Guid CommandSet = new Guid("8E0186D5-53C8-4662-A6B7-BEC6CDDC08DD");

        private AnalyzeSelectedProjectsCommand(ICommandServicesContainer commandServicesContainer)
            : base(commandServicesContainer, CommandId, CommandSet) { }

        public static void Initialize(ICommandServicesContainer commandServicesContainer)
        {
            Instance = new AnalyzeSelectedProjectsCommand(commandServicesContainer);
        }

        protected override IScopeAnalyzer GetScopeAnalyzer()
        {
            // TODO-IG: Display project selection dialog here one day.
            // TODO-IG: Return null if the dialog result is not OK (Cancel button clicked, dialog closed on X, etc.).

            return ScopeAnalyzerCreator.CreateMultipleProjectsScopeAnalyzer(false, null);
        }
    }
}