using System;
using System.ComponentModel.Design;
using System.Linq;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.LanguageServices;
using Microsoft.VisualStudio.Shell;
using Sharpen.Engine;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal sealed class RunExperimentCommand
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("B977FCAF-B5A3-49D8-9009-E0BDFDB1EFB7");

        private readonly AsyncPackage package;
        public VisualStudioWorkspace Workspace { get; private set; }

        private IServiceProvider ServiceProvider => package;

        private RunExperimentCommand(AsyncPackage package)
        {
            this.package = package;

            if (ServiceProvider.GetService(typeof(IMenuCommandService)) is OleMenuCommandService commandService)
            {
                var menuCommandId = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(MenuItemCallback, menuCommandId);
                commandService.AddCommand(menuItem);

                var componentModel = (IComponentModel)Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(SComponentModel));
                Workspace = componentModel.GetService<VisualStudioWorkspace>();
            }
        }

        private void MenuItemCallback(object sender, EventArgs e)
        {
            ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            var syntaxTree = Workspace
                .CurrentSolution
                .Projects
                .FirstOrDefault(project => project.Language == "C#")
                ?.Documents
                .FirstOrDefault(document => document.SupportsSyntaxTree)
                ?.GetSyntaxTreeAsync()
                .Result;

            if (syntaxTree == null)
            {
                UserInteraction.ShowError("There is no solution open or there is no any C# file in the solution. In order to run the experiment you have to open any Visual Studio Solution with a non-empty C# project in it.");
                return;
            }

            UserInteraction.ShowInformation(SharpenPackage.SharpenEngine.SomeSharpenEngineInterface.DoSomethingWithTheSyntaxTree(syntaxTree));
        }

        public static void Initialize(AsyncPackage package)
        {
            new RunExperimentCommand(package);
        }
    }
}