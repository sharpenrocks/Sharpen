using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.LanguageServices;
using System;
using System.ComponentModel.Design;

namespace Sharpen.VisualStudioExtension.Commands
{
    /// <summary>
    /// Containes shared services required by all Sharpen extension commands.
    /// </summary>
    internal interface ICommandServicesContainer
    {
        Package Package { get; }
        IServiceProvider ServiceProvider { get; }
        VisualStudioWorkspace Workspace { get; }
        EnvDTE80.DTE2 VisualStudioIde { get; }
        IMenuCommandService MenuCommandService { get; }
    }
}
