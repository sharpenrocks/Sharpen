using System.Linq;
using Microsoft.VisualStudio.LanguageServices;
using Document = Microsoft.CodeAnalysis.Document;
using Project = Microsoft.CodeAnalysis.Project;

namespace Sharpen.VisualStudioExtension
{
    internal static class VisualStudioWorkspaceExtensions
    {
        public static Project GetProjectFromVisualStudioProject(this VisualStudioWorkspace workspace, EnvDTE.Project visualStudioProject)
        {
            if (workspace.CurrentSolution == null) return null;
            if (visualStudioProject == null) return null;

            return workspace
                .CurrentSolution
                .Projects
                .FirstOrDefault(project => project.FilePath == visualStudioProject.FullName);
        }

        public static Document GetDocumentFromVisualStudioDocument(this VisualStudioWorkspace workspace, EnvDTE.Document visualStudioDocument)
        {
            if (workspace.CurrentSolution == null) return null;
            if (visualStudioDocument?.ProjectItem == null) return null;

            var documentsProject = workspace.GetProjectFromVisualStudioProject(visualStudioDocument.ProjectItem.ContainingProject);

            return documentsProject?
                .Documents
                .FirstOrDefault(document => document.FilePath == visualStudioDocument.FullName);
        }
    }
}
