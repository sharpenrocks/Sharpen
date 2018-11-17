using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Analysis
{
    public sealed class MultipleProjectsScopeAnalyzer : BaseScopeAnalyzer
    {
        // TODO-IG: A temporary workaround until we implement the dialog for selecting
        //          projects when project analysis is called from the tools menu (Analyze Selected Projects...)
        //          Remove it as soon as the selection dialog is implemented.
        private readonly bool isCalledFromContextMenu;
        private readonly Project[] projects;

        public MultipleProjectsScopeAnalyzer(bool isCalledFromContextMenu, params Project[] projects) // Projects array can be null.
        {
            this.isCalledFromContextMenu = isCalledFromContextMenu;
            this.projects = projects;
        }

        protected override string GetCanExecuteScopeAnalysisErrorMessage()
        {
            if (!isCalledFromContextMenu)
                return "Analyzing selected projects is currently not implemented.";

            if (projects == null || projects.Length <= 0)
            {
                return "There are no projects selected.";
            }

            if (!projects.Any(ProjectIsCSharpProject))
            {
                return "The selected projects do not contain any C# projects.";
            }

            if (!projects.SelectMany(project => project.Documents).Any(DocumentShouldBeAnalyzed))
            {
                return "The selected C# projects do not contain any C# files that could be analyzed.";
            }

            return null;
        }

        protected override string ScopeAnalysisHelpMessage => 
            isCalledFromContextMenu
                ? "To start project analysis, select at least one C# project with at least one non-generated C# file."
                : null;

        protected override IEnumerable<Document> GetDocumentsToAnalyze()
        {
            if (projects == null || !projects.Any()) return Enumerable.Empty<Document>();

            return projects
                .Where(ProjectIsCSharpProject)
                .SelectMany(project => project.Documents)
                .Where(DocumentShouldBeAnalyzed);
        }
    }
}