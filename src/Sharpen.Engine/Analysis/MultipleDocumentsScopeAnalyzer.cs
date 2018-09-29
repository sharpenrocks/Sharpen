using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Analysis
{
    // We have a slight terminology issue here. Users talk about files.
    // Roslyn talks about documents. For the code identifiers we will
    // use the term documents. For the user messages we will use files.
    public sealed class MultipleDocumentsScopeAnalyzer : BaseScopeAnalyzer
    {
        private readonly Document[] documents;

        public MultipleDocumentsScopeAnalyzer(params Document[] documents) // Documents array can be null.
        {
            this.documents = documents;
        }

        protected override string GetCanExecuteScopeAnalysisErrorMessage()
        {
            if (documents == null || documents.Length <= 0)
            {
                return "There are no files selected.";
            }

            if (!documents.Any(DocumentShouldBeAnalyzed))
            {
                return "The selected files do not contain any C# files that could be analyzed.";
            }

            return null;
        }

        protected override string ScopeAnalysisHelpMessage => 
            "To start file analysis, select at least one non-generated C# file.";

        protected override IEnumerable<Document> GetDocumentsToAnalyze()
        {
            return documents ?? Enumerable.Empty<Document>();
        }
    }
}