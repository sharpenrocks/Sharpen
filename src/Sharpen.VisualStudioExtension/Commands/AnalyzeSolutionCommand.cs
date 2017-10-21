using System;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.VisualStudio.Shell;
using Sharpen.Engine;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class AnalyzeSolutionCommand : BaseAnalyzeCommand<AnalyzeSolutionCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("8E0186D5-53C8-4662-A6B7-BEC6CDDC08DD");

        private AnalyzeSolutionCommand(Package package, SharpenEngine sharpenEngine) : base(package, sharpenEngine, CommandId, CommandSet) { }

        public static void Initialize(Package package, SharpenEngine sharpenEngine)
        {
            Instance = new AnalyzeSolutionCommand(package, sharpenEngine);
        }

        protected override void ExecuteAnalyzeCommand()
        {
            var analysisResult = SharpenEngine.Analyze(Workspace);

            StringBuilder sb = new StringBuilder();

            foreach (var result in analysisResult)
            {
                sb.AppendLine(result.Suggestion.FriendlyName + " " + Path.GetFileName(result.FilePath) + " " + result.Location);
            }

            Clipboard.SetText(sb.ToString());

            ShowInformation("Analysis result copied to clipboard.");
        }
    }
}