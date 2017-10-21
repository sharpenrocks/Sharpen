using Microsoft.VisualStudio.LanguageServices;

namespace Sharpen.VisualStudioExtension.Extensions
{
    internal static class VisualStudioWorkspaceExtensions
    {
        internal static bool IsSolutionOpen(this VisualStudioWorkspace workspace)
        {
            return workspace.CurrentSolution?.FilePath != null;
        }
    }
}
