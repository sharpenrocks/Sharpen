using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace Sharpen.Engine.Analysis
{
    internal class ScopeAnalyzerCreator : IScopeAnalyzerCreator
    {
        public IScopeAnalyzer CreateMultipleDocumentsScopeAnalyzer(IReadOnlyCollection<Document>? documents)
        {
            return new MultipleDocumentsScopeAnalyzer(documents);
        }

        public IScopeAnalyzer CreateMultipleProjectsScopeAnalyzer(bool isCalledFromContextMenu, IReadOnlyCollection<Project>? projects)
        {
            return new MultipleProjectsScopeAnalyzer(isCalledFromContextMenu, projects);
        }

        public IScopeAnalyzer CreateSolutionScopeAnalyzer(Solution? solution)
        {
            return new SolutionScopeAnalyzer(solution);
        }
    }
}
