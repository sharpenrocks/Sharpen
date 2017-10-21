using System;
using Microsoft.VisualStudio.Shell;
using Sharpen.Engine;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class AnalyzeSelectedProjectsCommand : BaseAnalyzeCommand<AnalyzeSelectedProjectsCommand>
    {
        public const int CommandId = 0x300;
        public static readonly Guid CommandSet = new Guid("8E0186D5-53C8-4662-A6B7-BEC6CDDC08DD");

        private AnalyzeSelectedProjectsCommand(Package package, SharpenEngine sharpenEngine) : base(package, sharpenEngine, CommandId, CommandSet) { }

        public static void Initialize(Package package, SharpenEngine sharpenEngine)
        {
            Instance = new AnalyzeSelectedProjectsCommand(package, sharpenEngine);
        }

        protected override void ExecuteAnalyzeCommand()
        {
            ShowInformation("Analyzing selected projects is currently not implemented.");
        }
    }
}