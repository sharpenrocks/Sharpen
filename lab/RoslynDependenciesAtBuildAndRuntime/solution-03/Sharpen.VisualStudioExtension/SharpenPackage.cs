using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Sharpen.Engine.Abstractions;
using Sharpen.VisualStudioExtension.Commands;

namespace Sharpen.VisualStudioExtension
{
    [ProvideAutoLoad(UIContextGuids80.SolutionExists, PackageAutoLoadFlags.BackgroundLoad)]
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "0.1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms.")]
    public sealed class SharpenPackage : AsyncPackage
    {
        public const string PackageGuidString = "01263ed2-7232-4367-a2cd-3982380b3985";

        // Just to quickly store the engine reference and make it available to the command.
        internal static ISharpenEngine SharpenEngine { get; private set; }

        protected override async System.Threading.Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            InitializeCommands();

            SharpenEngine = SharpenEngineCreator.GetSharpenEngine();

            await base.InitializeAsync(cancellationToken, progress);

            void InitializeCommands()
            {
                RunExperimentCommand.Initialize(this);
            }
        }
    }
}