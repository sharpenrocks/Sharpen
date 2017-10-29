using Microsoft.VisualStudio.LanguageServices;

namespace Sharpen.Engine.Extensions
{
    public static class VisualStudioWorkspaceExtensions
    {
        public static bool IsSolutionOpen(this VisualStudioWorkspace workspace)
        {
            return workspace.CurrentSolution?.FilePath != null;
        }
    }
}
