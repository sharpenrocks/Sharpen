using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.LanguageServices;

namespace Sharpen.VisualStudioExtension.Commands
{
    /// <summary>
    /// Containes shared services required by all Sharpen extension commands.
    /// </summary>
    internal interface ICommandServicesContainer
    {
        AsyncPackage Package { get; }
        IAsyncServiceProvider ServiceProvider { get; }
        VisualStudioWorkspace Workspace { get; }
        EnvDTE80.DTE2 VisualStudioIde { get; }
        IMenuCommandService MenuCommandService { get; }
        SharpenExtensionService SharpenExtensionService { get; }
    }
}