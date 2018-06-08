using System;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class ShowSharpenResultsToolWindowCommand : BaseSharpenCommand<ShowSharpenResultsToolWindowCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("89079AFD-E03C-46B1-A2F4-EE0C3611D9DB");

        private ShowSharpenResultsToolWindowCommand(Package package) : base(package, CommandId, CommandSet) { }

        public static void Initialize(Package package)
        {
            Instance = new ShowSharpenResultsToolWindowCommand(package);
        }

        protected override async Task OnExecuteAsync()
        {
            await ShowSharpenResultsToolWindowAsync();
        }
    }
}
