using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using Microsoft.VisualStudio.LanguageServices;
using Document = Microsoft.CodeAnalysis.Document;
using Project = Microsoft.CodeAnalysis.Project;

namespace Sharpen.VisualStudioExtension
{
    internal static class VisualStudioExtensions
    {
        public static Project GetRoslynProjectFromVisualStudioProject(this VisualStudioWorkspace workspace, EnvDTE.Project visualStudioProject)
        {
            if (workspace.CurrentSolution == null) return null;
            if (visualStudioProject == null) return null;

            return workspace
                .CurrentSolution
                .Projects
                .FirstOrDefault(project => project.FilePath == visualStudioProject.FullName);
        }

        public static IEnumerable<Project> GetRoslynProjectsFromVisualStudioProjects(this VisualStudioWorkspace workspace, IEnumerable<EnvDTE.Project> visualStudioProjects)
        {
            if (workspace.CurrentSolution == null) return Enumerable.Empty<Project>();
            if (visualStudioProjects == null) return Enumerable.Empty<Project>();

            var visualStudioProjectsFullNames = new HashSet<string>(visualStudioProjects.Select(project => project.FullName));

            return workspace
                .CurrentSolution
                .Projects
                .Where(project => visualStudioProjectsFullNames.Contains(project.FilePath));
        }

        public static Document GetRoslynDocumentFromVisualStudioDocument(this VisualStudioWorkspace workspace, EnvDTE.Document visualStudioDocument)
        {
            if (workspace.CurrentSolution == null) return null;
            if (visualStudioDocument?.ProjectItem == null) return null;

            var documentsProject = workspace.GetRoslynProjectFromVisualStudioProject(visualStudioDocument.ProjectItem.ContainingProject);

            return documentsProject?
                .Documents
                .FirstOrDefault(document => document.FilePath == visualStudioDocument.FullName);
        }

        public static bool IsCSharpProject(this EnvDTE.Project visualStudioProject)
        {
            return visualStudioProject?.CodeModel?.Language == CodeModelLanguageConstants.vsCMLanguageCSharp;
        }

        public static IEnumerable<EnvDTE.Project> GetSelectedVisualStudioProjects(this EnvDTE80.DTE2 visualStudioIde)
        {
            if (!(visualStudioIde.ActiveSolutionProjects is object[] selectedProjects))
                return Enumerable.Empty<EnvDTE.Project>();

            return selectedProjects.OfType<EnvDTE.Project>();
        }
    }
}