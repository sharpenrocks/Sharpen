namespace Sharpen.VisualStudioExtension.ToolWindows
{
    internal partial class SharpenResultsToolWindowControl
    {
        private readonly ISharpenResultsCommandHandler commandHandler;

        public SharpenResultsToolWindowControl(ISharpenResultsCommandHandler commandHandler)
        {
            InitializeComponent();

            this.commandHandler = commandHandler;
        }
    }
}