using System;
using System.ComponentModel.Design;
using EnvDTE80;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.LanguageServices;
using Microsoft.VisualStudio.Shell;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal class CommandServicesContainer : ICommandServicesContainer
    {
        private CommandServicesContainer(
            Package package,
            VisualStudioWorkspace workspace,
            DTE2 visualStudioIde,
            IMenuCommandService menuCommandService)
        {
            Package = package;
            Workspace = workspace;
            VisualStudioIde = visualStudioIde;
            MenuCommandService = menuCommandService;
        }

        public Package Package { get; }

        public IServiceProvider ServiceProvider => Package;

        public VisualStudioWorkspace Workspace { get; }

        public DTE2 VisualStudioIde { get; }

        public IMenuCommandService MenuCommandService { get; }

        public static ICommandServicesContainer Create(Package package)
        {
            IServiceProvider serviceProvider = package;
            var componentModel = (IComponentModel)Package.GetGlobalService(typeof(SComponentModel));
            var workspace = componentModel.GetService<VisualStudioWorkspace>();
            var visualStudioIde = (DTE2)serviceProvider.GetService(typeof(EnvDTE.DTE));
            var menuCommandService = (OleMenuCommandService)serviceProvider.GetService(typeof(IMenuCommandService));

            return new CommandServicesContainer(package, workspace, visualStudioIde, menuCommandService);
        }
    }
}
