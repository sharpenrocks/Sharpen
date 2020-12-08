using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Analysis
{
    internal sealed class MultipleProjectsScopeAnalyzer : BaseScopeAnalyzer
    {
        private readonly bool isCalledFromContextMenu;
        private readonly IReadOnlyCollection<Project>? projects;

        public MultipleProjectsScopeAnalyzer(bool isCalledFromContextMenu, IReadOnlyCollection<Project>? projects)
        {
            this.isCalledFromContextMenu = isCalledFromContextMenu;
            this.projects = projects;
        }

        protected override string? GetCanExecuteScopeAnalysisErrorMessage()
        {
            if (!isCalledFromContextMenu)
                return $@"The dialog for selecting projects to analyze is currently not implemented.{Environment.NewLine}{Environment.NewLine}However, you can select the desired projects in the Solution Explorer and run the analysis on them by using the ""Analyze with Sharpen"" context menu option.";

            if (projects == null || projects.Count <= 0)
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

        protected override string? ScopeAnalysisHelpMessage => 
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