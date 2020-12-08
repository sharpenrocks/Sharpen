using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Analysis
{
    public static class ScopeAnalyzerCreatorExtensions
    {
        // Will end up in a user friendly error message.
        public static IScopeAnalyzer CreateMultipleDocumentsScopeAnalyzer(this IScopeAnalyzerCreator scopeAnalyzerCreator)
        {
             return scopeAnalyzerCreator.CreateMultipleDocumentsScopeAnalyzer(null);
        }

        public static IScopeAnalyzer CreateMultipleDocumentsScopeAnalyzer(this IScopeAnalyzerCreator scopeAnalyzerCreator, Document? document)
        {
             return scopeAnalyzerCreator.CreateMultipleDocumentsScopeAnalyzer(document == null ? null : new [] { document });
        }
    }
}
