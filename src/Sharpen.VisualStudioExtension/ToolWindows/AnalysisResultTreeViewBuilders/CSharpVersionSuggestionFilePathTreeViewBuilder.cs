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

        public override IEnumerable<BaseTreeViewItem> BuildRootTreeViewItems()
        {
            return AnalysisResults
                .Select(result => result.Suggestion.MinimumLanguageVersion)
                .Distinct()
                .OrderBy(version => version)
                .Select(version => new CSharpVersionTreeViewItem
                (
                    null,
                    this,
                    AnalysisResults.Count(result => result.Suggestion.MinimumLanguageVersion == version),
                    version
                ));
        }

        public override IEnumerable<BaseTreeViewItem> BuildChildrenTreeViewItemsOf(BaseTreeViewItem parent)
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
                            AnalysisResults.Count(result => result.Suggestion == suggestion),
                            suggestion
                        ));

                case SuggestionTreeViewItem suggestionTreeViewItem:
                    return AnalysisResults
                        .Where(result => result.Suggestion == suggestionTreeViewItem.Suggestion)
                        .OrderBy(suggestion => suggestion.FilePath)
                        .ThenBy(suggestion => suggestion.Position.StartLinePosition.Line)
                        .ThenBy(suggestion => suggestion.Position.StartLinePosition.Character)
                        .Select(result => new FilePathTreeViewItem
                        (
                            parent,
                            this,
                            result.FilePath,
                            0,
                            result
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
