using Microsoft.CodeAnalysis;
using System;
using System.Reflection;
using Task = System.Threading.Tasks.Task;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class ShowAboutDialogCommand : BaseSharpenCommand<ShowAboutDialogCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("CFDB73FC-D6FA-4F1D-93E0-434650DF7A86");

        private ShowAboutDialogCommand(ICommandServicesContainer commandServicesContainer) : base(commandServicesContainer, CommandId, CommandSet) { }

        public static void Initialize(ICommandServicesContainer commandServicesContainer)
        {
            Instance = new ShowAboutDialogCommand(commandServicesContainer);
        }

        protected override Task OnExecuteAsync()
        {
            var sharpenAssembly = Assembly.GetExecutingAssembly();
            var version = sharpenAssembly.GetName().Version;
            var description = sharpenAssembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;

            var roslynAssembly = typeof(SyntaxTree).Assembly;
            var roslynVersion = roslynAssembly.GetName().Version;

            var sharpenEngineAssembly = Services.ScopeAnalyzerCreator.GetType().Assembly;
            var sharpenEngineVersion = sharpenEngineAssembly.GetName().Name.Replace("Sharpen.Engine.", string.Empty).Replace("_", ".");

            var message = $"Sharpen v{version}{Environment.NewLine}" +
                          $"{Environment.NewLine}" +
                          $"{description}{Environment.NewLine}" +
                          $"{Environment.NewLine}" +
                          $"Diagnostic info:{Environment.NewLine}" +
                          $"    Sharpen version:\t\t{version}{Environment.NewLine}" +
                          $"    Roslyn version:\t\t{roslynVersion}{Environment.NewLine}" +
                          $"    Sharpen engine version:\t{sharpenEngineVersion}";

            UserInteraction.ShowInformation(message, "About Sharpen");

            return Task.CompletedTask;
        }
    }
}