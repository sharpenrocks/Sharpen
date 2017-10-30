using System;
using System.Collections.Generic;
using System.Linq;
using Sharpen.Engine;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders
{
    internal class CSharpVersionSuggestionFilePathTreeViewBuilder : BaseAnalysisResultTreeViewBuilder
    {
        public CSharpVersionSuggestionFilePathTreeViewBuilder(IEnumerable<AnalysisResult> analysisResults) : base(analysisResults)
        {
        }

        public override IEnumerable<BaseTreeViewItem> GetRootTreeViewItems()
        {
            return AnalysisResults
                .Select(result => result.Suggestion.MinimumLanguageVersion)
                .Distinct()
                .OrderBy(version => version)
                .Select(version => new CSharpVersionTreeViewItem
                (
                    null,
                    this,
                    version
                ));
        }

        public override IEnumerable<BaseTreeViewItem> GetChildrenTreeViewItemsOf(BaseTreeViewItem parent)
        {
            switch (parent)
            {
                case CSharpVersionTreeViewItem csharpVersionTreeViewItem:
                    return AnalysisResults
                        .Where(result => result.Suggestion.MinimumLanguageVersion == csharpVersionTreeViewItem.CSharpVersion)
                        .Select(result => result.Suggestion)
                        .Distinct()
                        .OrderBy(suggestion => suggestion.FriendlyName)
                        .Select(suggestion => new SuggestionTreeViewItem
                        (
                            parent,
                            this,
                            suggestion
                        ));

                case SuggestionTreeViewItem suggestionTreeViewItem:
                    return AnalysisResults
                        .Where(result => result.Suggestion == suggestionTreeViewItem.Suggestion)
                        .OrderBy(suggestion => suggestion.FilePath)
                        .ThenBy(suggestion => suggestion.Position.StartLinePosition.Line)
                        .ThenBy(suggestion => suggestion.Position.StartLinePosition.Character)
                        .Select(result => result.FilePath)
                        .Select(filePath => new FilePathTreeViewItem
                        (
                            parent,
                            this,
                            filePath,
                            true
                        ));

                default:
                    throw new ArgumentOutOfRangeException
                    (
                        nameof(parent),
                        $"The parent of the type '{parent.GetType().Name}' is not supported as a parent in the '{GetType().Name}'."
                    );
            }
        }
    }
}
