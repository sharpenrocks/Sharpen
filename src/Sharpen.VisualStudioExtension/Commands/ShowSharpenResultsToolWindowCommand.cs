using System;
using Microsoft.VisualStudio.Shell;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class ShowSharpenResultsToolWindowCommand : BaseSharpenCommand<ShowSharpenResultsToolWindowCommand>
    {
        public const int CommandId = 4129;
        public static readonly Guid CommandSet = new Guid("b5e43671-9e80-4169-beb1-74b688b21375");

        private ShowSharpenResultsToolWindowCommand(Package package) : base(package, CommandId, CommandSet) { }

        public static void Initialize(Package package)
        {
            Instance = new ShowSharpenResultsToolWindowCommand(package);
        }

        protected override void OnExecute()
        {
            ShowSharpenResultsToolWindow();
        }
    }
}
