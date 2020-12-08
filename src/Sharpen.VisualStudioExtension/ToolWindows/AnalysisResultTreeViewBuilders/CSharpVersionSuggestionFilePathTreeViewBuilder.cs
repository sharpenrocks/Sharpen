using System;
using System.Collections.Generic;
using System.Linq;
using Sharpen.Engine.Analysis;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders
{
    internal class CSharpVersionSuggestionFilePathTreeViewBuilder : BaseAnalysisResultTreeViewBuilder
    {
        public CSharpVersionSuggestionFilePathTreeViewBuilder(IEnumerable<IAnalysisResult> analysisResults) : base(analysisResults)
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
                        .Select(result => result.Suggestion.LanguageFeature)
                        .Distinct()
                        .OrderBy(feature => feature.FriendlyName)
                        .Select(feature => new CSharpFeatureTreeViewItem
                        (
                            parent,
                            this,
                            AnalysisResults.Count(result => result.Suggestion.MinimumLanguageVersion == csharpVersionTreeViewItem.CSharpVersion &&
                                                            result.Suggestion.LanguageFeature == feature),
                            feature
                        ));

                case CSharpFeatureTreeViewItem csharpFeatureTreeViewItem:
                    // A certain C# feature can be introduced within several versions of C#.
                    // For example, Expression-bodied members are introduced in C# 6.0 and C# 7.0.
                    var parentLanguageVersion = ((CSharpVersionTreeViewItem)csharpFeatureTreeViewItem.Parent).CSharpVersion;
                    return AnalysisResults
                        .Where(result => result.Suggestion.MinimumLanguageVersion == parentLanguageVersion &&
                                         result.Suggestion.LanguageFeature == csharpFeatureTreeViewItem.Feature)
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
                        .GroupBy(suggestion => new {suggestion.AnalysisContext.ProjectName, suggestion.FilePath})
                        .OrderBy(group => group.Key.ProjectName)
                        .ThenBy(group => group.Key.FilePath)
                        .Select(group => new FilePathTreeViewItem
                        (
                            parent,
                            this,
                            group.Count(),
                            // TODO: Inefficient and ugly workaround that will work so far.
                            //       We will soon replace all the LINQ code in this method with an access to an optimized indexing structure.
                            AnalysisResults.First(result => result.AnalysisContext.ProjectName == group.Key.ProjectName && result.FilePath == group.Key.FilePath).AnalysisContext,
                            group.Key.FilePath
                        ));

                case FilePathTreeViewItem filePathTreeViewItem:
                    var parentSuggestion = ((SuggestionTreeViewItem) filePathTreeViewItem.Parent).Suggestion;
                    return AnalysisResults
                        .Where(result => result.Suggestion == parentSuggestion && result.AnalysisContext.ProjectName == filePathTreeViewItem.ProjectName && result.FilePath == filePathTreeViewItem.FilePath)
                        .OrderBy(suggestion => suggestion.Position.StartLinePosition.Line)
                        .ThenBy(suggestion => suggestion.Position.StartLinePosition.Character)
                        .Select(result => new SingleSuggestionTreeViewItem
                        (
                            parent,
                            this,
                            result
                        ));

                default:
                    throw new ArgumentOutOfRangeException
                    (
                        nameof(parent),
                        $"The parent of the type {parent.GetType().Name} is not supported as a parent in the {nameof(CSharpVersionSuggestionFilePathTreeViewBuilder)}."
                    );
            }
        }
    }
}
