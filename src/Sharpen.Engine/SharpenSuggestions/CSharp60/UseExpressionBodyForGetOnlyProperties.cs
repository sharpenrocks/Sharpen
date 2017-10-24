using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.CSharpFeatures;

namespace Sharpen.Engine.SharpenSuggestions.CSharp60
{
    public class UseExpressionBodyForGetOnlyProperties : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        private UseExpressionBodyForGetOnlyProperties() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp60;

        public ICSharpFeature LanguageFeature { get; } = ExpressionBodiedMembers.Instance;

        public string FriendlyName { get; } = "Use expression body for get-only properties";

        public static readonly UseExpressionBodyForGetOnlyProperties Instance = new UseExpressionBodyForGetOnlyProperties();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<AccessorDeclarationSyntax>()
                .Where
                (accessor =>
                    accessor.Keyword.IsKind(SyntaxKind.GetKeyword) &&
                    ((AccessorListSyntax)accessor.Parent).Accessors.Count == 1 // We must have only the get-accessor.
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
                .Select(accessor => new AnalysisResult(this, syntaxTree.FilePath, accessor.Keyword));
        }
    }
}