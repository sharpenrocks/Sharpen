using System;
using Task = System.Threading.Tasks.Task;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class ShowOptionsDialogCommand : BaseSharpenCommand<ShowOptionsDialogCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("B977FCAF-B5A3-49D8-9009-E0BDFDB1EFB6");

        private ShowOptionsDialogCommand(ICommandServicesContainer commandServicesContainer) : base(commandServicesContainer, CommandId, CommandSet) { }

        public static void Initialize(ICommandServicesContainer commandServicesContainer)
        {
            Instance = new ShowOptionsDialogCommand(commandServicesContainer);
        }

        protected override Task OnExecuteAsync()
        {
            UserInteraction.ShowInformation("Setting Sharpen options is currently not implemented.");
            return Task.CompletedTask;
        }
    }
}