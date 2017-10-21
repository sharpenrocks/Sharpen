using System;
using Microsoft.VisualStudio.Shell;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class AnalyzeSelectedProjectsCommand : BaseSharpenCommand<AnalyzeSelectedProjectsCommand>
    {
        public const int CommandId = 0x300;
        public static readonly Guid CommandSet = new Guid("8E0186D5-53C8-4662-A6B7-BEC6CDDC08DD");

        private AnalyzeSelectedProjectsCommand(Package package) : base(package, CommandId, CommandSet) { }

        public static void Initialize(Package package)
        {
            Instance = new AnalyzeSelectedProjectsCommand(package);
        }

        protected override void OnExecute()
        {
            ShowInformation("Analyzing selected projects is currently not implemented.");
        }
    }
}