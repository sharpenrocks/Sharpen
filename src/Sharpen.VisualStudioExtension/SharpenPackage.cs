using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Sharpen.VisualStudioExtension.Commands;
using Sharpen.VisualStudioExtension.ToolWindows;

namespace Sharpen.VisualStudioExtension
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "0.1.0", IconResourceID = 400)] // Info on this package for Help/About.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms.")]
    [ProvideToolWindow(typeof(SharpenResultsToolWindow))]
    public sealed class SharpenPackage : Package
    {
        public const string PackageGuidString = "01263ec2-7232-4367-a2cd-3982380b3985";

        protected override void Initialize()
        {
            SharpenWholeSolutionCommand.Initialize(this);
            ShowSharpenResultsToolWindowCommand.Initialize(this);

            base.Initialize();
        }
    }
}