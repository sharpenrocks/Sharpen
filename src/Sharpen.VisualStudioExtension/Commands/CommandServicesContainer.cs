using System.ComponentModel.Design;
using System.Threading.Tasks;
using EnvDTE80;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.LanguageServices;
using Microsoft.VisualStudio.Shell;

namespace Sharpen.VisualStudioExtension.Commands
{
    internal class CommandServicesContainer : ICommandServicesContainer
    {
        private CommandServicesContainer(AsyncPackage package)
        {
            Package = package;
        }

        public AsyncPackage Package { get; }
        public IAsyncServiceProvider ServiceProvider => Package;
        public VisualStudioWorkspace Workspace { get; private set; }
        public DTE2 VisualStudioIde { get; private set; }
        public IMenuCommandService MenuCommandService { get; private set; }
        public SharpenExtensionService SharpenExtensionService { get; private set; }

        /// <summary>
        /// Builds an instance of <see cref="CommandServicesContainer"/>.
        /// </summary>
        /// <remarks>
        /// For more info about async packages, async package initialization, RPC calles etc see:
        /// https://docs.microsoft.com/en-us/visualstudio/extensibility/how-to-use-asyncpackage-to-load-vspackages-in-the-background?view=vs-2017
        /// https://github.com/Microsoft/VSSDK-Extensibility-Samples/blob/master/AsyncPackageMigration/AsyncAutoloadRestriction.md
        /// </remarks>
        // No need for any complex workflow here at the moment, checks etc.
        // The client has to know what it does and call the methods at the right time in the right order.
        // Let's keep it simple.
        public class Builder
        {
            private readonly AsyncPackage package;
            private readonly CommandServicesContainer commandServicesContainer;

            public Builder(AsyncPackage package)
            {
                this.package = package;
                commandServicesContainer = new CommandServicesContainer(package);
            }

            public async System.Threading.Tasks.Task CreateServicesAsync()
            {
                commandServicesContainer.SharpenExtensionService = SharpenExtensionService.CreateSingleInstance();

                IAsyncServiceProvider serviceProvider = package;
                commandServicesContainer.VisualStudioIde = (DTE2)await serviceProvider.GetServiceAsync(typeof(EnvDTE.DTE));
                commandServicesContainer.MenuCommandService = (OleMenuCommandService)await serviceProvider.GetServiceAsync(typeof(IMenuCommandService));
            }

            public void CreateServicesOnUIThread()
            {
                var componentModel = (IComponentModel)Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(SComponentModel));
                commandServicesContainer.Workspace = componentModel.GetService<VisualStudioWorkspace>();
            }

            public CommandServicesContainer GetCommandServicesContainer()
            {
                return commandServicesContainer;
            }
        }
    }
}