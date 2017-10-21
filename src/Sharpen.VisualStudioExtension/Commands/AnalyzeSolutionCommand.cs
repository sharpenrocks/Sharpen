using System;
using Microsoft.VisualStudio.Shell;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class AnalyzeSolutionCommand : BaseSharpenCommand<AnalyzeSolutionCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("8E0186D5-53C8-4662-A6B7-BEC6CDDC08DD");

        private AnalyzeSolutionCommand(Package package) : base(package, CommandId, CommandSet) { }

        public static void Initialize(Package package)
        {
            Instance = new AnalyzeSolutionCommand(package);
        }

        protected override void OnExecute()
        {
            ShowInformation("Analyzing solution is currently not implemented.");
        }
    }
}