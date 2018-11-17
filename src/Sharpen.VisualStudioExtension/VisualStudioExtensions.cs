using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using EnvDTE80;
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

        public static IEnumerable<Document> GetRoslynDocumentsFromVisualStudioSelectedItems(this VisualStudioWorkspace workspace, IEnumerable<SelectedItem> visualStudioSelectedItems)
        {
            // TODO-PERF: It's crazy what this method does for such a trivial(?) task
            //            of mapping "this to that"!!
            //            Is there any better way to do this?
            //            (We expect the number of selected items to always be small, but still.)

            if (workspace.CurrentSolution == null) return Enumerable.Empty<Document>();
            if (visualStudioSelectedItems == null) return Enumerable.Empty<Document>();

            var roslynProjects = new Dictionary<string, Project>();

            var result = new HashSet<Document>();
            foreach (var selectedItem in visualStudioSelectedItems)
            {
                var roslynProject = GetRoslynProjectOfSelectedItem(selectedItem);
                if (roslynProject == null) continue;

                var selectedItemFileName = GetSelectedItemFileName(selectedItem);
                if (selectedItemFileName == null) continue;
                                
                var roslynDocument = roslynProject
                    .Documents
                    .FirstOrDefault(document => document.FilePath == selectedItemFileName);

                if (roslynDocument != null)
                    result.Add(roslynDocument);
            }

            return result;

            string GetSelectedItemFileName(SelectedItem selectedItem)
            {
                if (selectedItem.ProjectItem?.FileCount != 1) return null;

                return selectedItem.ProjectItem.FileNames[0];
            }

            Project GetRoslynProjectOfSelectedItem(SelectedItem selectedItem)
            {
                var visualStudioProject = selectedItem?.ProjectItem?.ContainingProject;

                var projectUniqueName = visualStudioProject?.UniqueName;
                if (projectUniqueName == null) return null;

                if (!roslynProjects.ContainsKey(projectUniqueName))
                    roslynProjects.Add(projectUniqueName, workspace.GetRoslynProjectFromVisualStudioProject(visualStudioProject));

                return roslynProjects[projectUniqueName];
            }
        }

        public static bool IsCSharpProject(this EnvDTE.Project visualStudioProject)
        {
            return visualStudioProject?.CodeModel?.Language == CodeModelLanguageConstants.vsCMLanguageCSharp;
        }

        public static bool IsCSharpDocument(this EnvDTE.Document visualStudioDocument)
        {
            return visualStudioDocument?.ProjectItem?.FileCodeModel?.Language == CodeModelLanguageConstants.vsCMLanguageCSharp;
        }

        public static bool IsCSharpDocument(this SelectedItem visualStudioSelectedItem)
        {
            return visualStudioSelectedItem?.ProjectItem?.FileCodeModel?.Language == CodeModelLanguageConstants.vsCMLanguageCSharp;
        }

        public static IEnumerable<EnvDTE.Project> GetSelectedVisualStudioProjects(this DTE2 visualStudioIde)
        {
            if (!(visualStudioIde.ActiveSolutionProjects is object[] selectedProjects))
                return Enumerable.Empty<EnvDTE.Project>();

            return selectedProjects.OfType<EnvDTE.Project>();
        }

        public static IEnumerable<SelectedItem> GetSelectedVisualStudioItems(this DTE2 visualStudioIde)
        {
            if (visualStudioIde.SelectedItems == null)
                return Enumerable.Empty<SelectedItem>();

            return visualStudioIde
                .SelectedItems
                .Cast<SelectedItem>();
        }
    }
}