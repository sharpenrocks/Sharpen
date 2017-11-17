using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.CSharpFeatures;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70
{
    public class UseExpressionBodyForSetAccessors : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        private UseExpressionBodyForSetAccessors() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp70;

        public ICSharpFeature LanguageFeature { get; } = ExpressionBodiedMembers.Instance;

        public string FriendlyName { get; } = "Use expression body for set accessors";

        public static readonly UseExpressionBodyForSetAccessors Instance = new UseExpressionBodyForSetAccessors();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<AccessorDeclarationSyntax>()
                .Where
                (accessor => 
                    accessor.Keyword.IsKind(SyntaxKind.SetKeyword) &&
                    accessor.Body != null &&
                    accessor.Body.Statements.Count == 1 &&
                    accessor.Body.Statements[0].IsKind(SyntaxKind.ExpressionStatement)
                )
                .Select(accessor => new AnalysisResult
                (
                    this,
                    syntaxTree.FilePath,
                    accessor.Keyword,
                    accessor.FirstAncestorOrSelf<BasePropertyDeclarationSyntax>() // The common base class for both Properties and Indexers.
                ));
        }
    }
}