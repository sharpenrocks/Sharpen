using System;
using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.LanguageServices;
using Document = Microsoft.CodeAnalysis.Document;
using Project = Microsoft.CodeAnalysis.Project;

namespace Sharpen.VisualStudioExtension
{
    // We use a simple convention to denote returning of materialized and non-materialized
    // enumerables. If the result is IEnumerable<T> it is not materialized.
    // If the result is IReadOnlyCollection<T> it is materialized.
    internal static class VisualStudioExtensions
    {
        public static Project? GetRoslynProjectFromVisualStudioProject(this VisualStudioWorkspace workspace, EnvDTE.Project visualStudioProject)
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

        public static Document? GetRoslynDocumentFromVisualStudioDocument(this VisualStudioWorkspace workspace, EnvDTE.Document visualStudioDocument)
        {
            if (workspace.CurrentSolution == null) return null;
            if (visualStudioDocument?.ProjectItem == null) return null;

            var documentsProject = workspace.GetRoslynProjectFromVisualStudioProject(visualStudioDocument.ProjectItem.ContainingProject);

            return documentsProject?
                .Documents
                .FirstOrDefault(document => document.FilePath == visualStudioDocument.FullName);
        }

        public static IReadOnlyCollection<Document> GetRoslynDocumentsFromVisualStudioProjectItems(this VisualStudioWorkspace workspace, IEnumerable<ProjectItem> visualStudioProjectItems)
        {
            // TODO-PERF: It's crazy what this method does for such a trivial(?) task
            //            of mapping "this to that"!!
            //            Is there any better way to do this?
            //            (We expect the number of selected items to always be small, but still.)

            if (workspace.CurrentSolution == null) return Array.Empty<Document>();
            if (visualStudioProjectItems == null) return Array.Empty<Document>();

            var roslynProjects = new Dictionary<string, Project>();

            var result = new HashSet<Document>();
            foreach (var projectItem in visualStudioProjectItems)
            {
                var roslynProject = GetRoslynProjectOfProjectItem(projectItem);
                if (roslynProject == null) continue;

                var selectedItemFileName = GetProjectItemFileName(projectItem);
                if (selectedItemFileName == null) continue;
                                
                var roslynDocument = roslynProject
                    .Documents
                    .FirstOrDefault(document => document.FilePath == selectedItemFileName);

                if (roslynDocument != null)
                    result.Add(roslynDocument);
            }

            return result;

            string? GetProjectItemFileName(ProjectItem projectItem)
            {
                if (projectItem?.FileCount != 1) return null;

                // Some items report a file count > 0 but don't return a file name!
                // See: https://github.com/tom-englert/Wax/blob/210b1038b0c282f3ae7c399178ae17bc5bf8fcd8/Wax.Model/VisualStudio/DteExtensions.cs#L181
                try
                {
                    return projectItem.FileNames[0];
                }
                catch
                {
                    return null;
                }                
            }

            Project? GetRoslynProjectOfProjectItem(ProjectItem projectItem)
            {
                var visualStudioProject = projectItem?.ContainingProject;

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

        public static bool IsCSharpDocument(this ProjectItem visualStudioProjectItem)
        {
            return visualStudioProjectItem?.FileCodeModel?.Language == CodeModelLanguageConstants.vsCMLanguageCSharp;
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

        public static IReadOnlyCollection<ProjectItem> GetSelectedVisualStudioProjectItemsWithSubItems(this DTE2 visualStudioIde)
        {
            if (visualStudioIde.SelectedItems == null)
                return Array.Empty<ProjectItem>();

            var result = new HashSet<ProjectItem>();

            var selectedProjectItems = visualStudioIde
                .SelectedItems
                .OfType<SelectedItem>()
                .Select(selectedItem => selectedItem.ProjectItem)
                .Where(projectItem => projectItem != null);

            CollectProjectItems(selectedProjectItems);

            return result;

            void CollectProjectItems(IEnumerable<ProjectItem> currentProjectItems)
            {
                if (currentProjectItems == null) return;

                foreach (var item in currentProjectItems)
                {
                    result.Add(item);
                    CollectProjectItems(item.ProjectItems?.OfType<ProjectItem>());
                }
            }
        }        
    }
}