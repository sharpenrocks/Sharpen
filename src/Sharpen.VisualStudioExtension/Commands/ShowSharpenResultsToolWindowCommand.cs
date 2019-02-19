using System;
using Task = System.Threading.Tasks.Task;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class ShowSharpenResultsToolWindowCommand : BaseSharpenCommand<ShowSharpenResultsToolWindowCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("89079AFD-E03C-46B1-A2F4-EE0C3611D9DB");

        private ShowSharpenResultsToolWindowCommand(ICommandServicesContainer commandServicesContainer) : base(commandServicesContainer, CommandId, CommandSet) { }

        public static void Initialize(ICommandServicesContainer commandServicesContainer)
        {
            Instance = new ShowSharpenResultsToolWindowCommand(commandServicesContainer);
        }

        protected override async Task OnExecuteAsync()
        {
            await ShowSharpenResultsToolWindowAsync();
        }
    }
}
