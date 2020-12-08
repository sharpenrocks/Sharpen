using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Analysis
{
    public interface IScopeAnalyzerCreator
    {
        IScopeAnalyzer CreateSolutionScopeAnalyzer(Solution? solution);
        IScopeAnalyzer CreateMultipleDocumentsScopeAnalyzer(IReadOnlyCollection<Document>? documents);

        // TODO-IG: isCalledFromContextMenu is a temporary workaround until we implement the dialog for selecting
        //          projects when project analysis is called from the tools menu (Analyze Selected Projects...)
        //          Remove it as soon as the selection dialog is implemented.
        IScopeAnalyzer CreateMultipleProjectsScopeAnalyzer(bool isCalledFromContextMenu, IReadOnlyCollection<Project>? projects);
    }
}
