using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Analysis
{
    public sealed class SolutionScopeAnalyzer : BaseScopeAnalyzer
    {
        private readonly Solution solution;

        public SolutionScopeAnalyzer(Solution solution) // Solution can be null.
        {
            this.solution = solution;
        }

        protected override string GetCanExecuteScopeAnalysisErrorMessage()
        {
            if (solution?.FilePath == null)
            {
                return "There is no solution open.";
            }

            if (!solution.Projects.Any(ProjectIsCSharpProject))
            {
                return "The solution does not contain any C# projects.";
            }

            if (!solution.Projects.SelectMany(project => project.Documents).Any(DocumentShouldBeAnalyzed))
            {
                return "The C# projects in the solution do not contain any C# files that could be analyzed.";
            }

            return null;
        }

        protected override string ScopeAnalysisHelpMessage =>
            "To start solution analysis, open a solution that contains at least one C# project with at least one non-generated C# file.";

        protected override IEnumerable<Document> GetDocumentsToAnalyze()
        {
            if (solution == null) return Enumerable.Empty<Document>();

            return solution
                .Projects
                .Where(ProjectIsCSharpProject)
                .SelectMany(project => project.Documents)
                .Where(DocumentShouldBeAnalyzed);
        }
    }
}