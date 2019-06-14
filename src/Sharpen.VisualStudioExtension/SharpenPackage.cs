using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Sharpen.VisualStudioExtension.Commands;
using Sharpen.VisualStudioExtension.Commands.ContextCommands;
using Sharpen.VisualStudioExtension.ToolWindows;

namespace Sharpen.VisualStudioExtension
{
    [ProvideAutoLoad(UIContextGuids80.SolutionExists, PackageAutoLoadFlags.BackgroundLoad)]
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "0.9.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms.")]
    [ProvideToolWindow(typeof(SharpenResultsToolWindow), Style = VsDockStyle.Tabbed, Window = "34E76E81-EE4A-11D0-AE2E-00A0C90FFFC3" /* Output Window. */)]
    public sealed class SharpenPackage : AsyncPackage
    {
        public const string PackageGuidString = "01263ec2-7232-4367-a2cd-3982380b3985";

        protected override async System.Threading.Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            var commandServicesContainerBuilder = new CommandServicesContainer.Builder(this);

            await commandServicesContainerBuilder.CreateServicesAsync();

            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            commandServicesContainerBuilder.CreateServicesOnUIThread();

            var commandServicesContainer = commandServicesContainerBuilder.GetCommandServicesContainer();

            InitializeCommands();

            await base.InitializeAsync(cancellationToken, progress);

            void InitializeCommands()
            {
                AnalyzeSolutionCommand.Initialize(commandServicesContainer);
                AnalyzeSelectedProjectsCommand.Initialize(commandServicesContainer);

                ShowOptionsDialogCommand.Initialize(commandServicesContainer);
                ShowSharpenResultsToolWindowCommand.Initialize(commandServicesContainer);

                AnalyzeCurrentDocumentContextCommand.Initialize(commandServicesContainer);
                AnalyzeSolutionContextCommand.Initialize(commandServicesContainer);
                AnalyzeSelectedProjectsContextCommand.Initialize(commandServicesContainer);
                AnalyzeSelectedDocumentsContextCommand.Initialize(commandServicesContainer);
                AnalyzeSelectedFoldersContextCommand.Initialize(commandServicesContainer);
            }
        }
    }
}