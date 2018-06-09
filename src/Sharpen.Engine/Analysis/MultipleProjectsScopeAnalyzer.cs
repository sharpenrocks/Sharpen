using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Analysis
{
    public sealed class MultipleProjectsScopeAnalyzer : BaseScopeAnalyzer
    {
        private readonly Project[] projects;

        public MultipleProjectsScopeAnalyzer(params Project[] projects) // Projects array can be null.
        {
            this.projects = projects;
        }

        protected override string GetCanExecuteScopeAnalysisErrorMessage()
        {
            // TODO-IG: Uncomment the commented code as soon as the analysis of multiple projects is implemented.
            return "Analyzing selected projects is currently not implemented.";

            //if (projects == null || projects.Length <= 0)
            //{
            //    return "There are no projects selected.";
            //}
            //
            //if (!projects.Any(ProjectIsCSharpProject))
            //{
            //    return "The selected projects do not contain any C# projects.";
            //}
            //
            //if (!projects.SelectMany(project => project.Documents).Any(DocumentCanBeAnalyzed))
            //{
            //    return "The selected C# projects do not contain any C# files that could be analyzed.";
            //}

            //return null;
        }

        protected override string ScopeAnalysisHelpMessage => 
            null;
            // TODO-IG: Uncomment the commented code as soon as the analysis of multiple projects is implemented.
            //"To start project analysis, select at least one C# project with at least one non-generated C# file.";

        protected override IEnumerable<Document> GetDocumentsToAnalyze()
        {
            if (projects == null || !projects.Any()) return Enumerable.Empty<Document>();

            return projects
                .Where(ProjectIsCSharpProject)
                .SelectMany(project => project.Documents)
                .Where(DocumentCanBeAnalyzed);
        }
    }
}