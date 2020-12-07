using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;

namespace Sharpen.Engine.SharpenSuggestions.CSharp60.ExpressionBodiedMembers
{
    internal abstract class BaseUseExpressionBodyForGetOnlyMembers<TBasePropertyDeclarationSyntax> : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
        where TBasePropertyDeclarationSyntax : BasePropertyDeclarationSyntax
    {
        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp60;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.ExpressionBodiedMembers.Instance;

        public abstract string FriendlyName { get; }

        public SharpenSuggestionType SuggestionType { get; } = SharpenSuggestionType.Recommendation;

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<AccessorDeclarationSyntax>()
                .Where
                (accessor =>
                    accessor.Keyword.IsKind(SyntaxKind.GetKeyword) &&
                    ((AccessorListSyntax)accessor.Parent).Accessors.Count == 1 // We must have only the get-accessor.
                    &&
                    accessor.FirstAncestorOrSelf<TBasePropertyDeclarationSyntax>() != null // We must be either in a property or in an indexer.
                    &&
                    (
                        // We have a get accessor with a body.
                        (
                        accessor.Body != null &&
                        accessor.Body.Statements.Count == 1 &&
                        accessor.Body.Statements[0].IsKind(SyntaxKind.ReturnStatement)
                        )
                    ||
                        // We have an expression bodied get accessor.
                        accessor.ExpressionBody != null
                    )
                )
                .Select(accessor => new AnalysisResult
                (
                    this,
                    analysisContext,
                    syntaxTree.FilePath,
                    accessor.Keyword,
                    accessor.FirstAncestorOrSelf<TBasePropertyDeclarationSyntax>()
                ));
        }
    }
}