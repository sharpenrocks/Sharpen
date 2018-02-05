using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70.ExpressionBodiedMembers
{
    internal sealed class UseExpressionBodyForDestructors : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        private UseExpressionBodyForDestructors() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp70;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.ExpressionBodiedMembers.Instance;

        public string FriendlyName { get; } = "Use expression body for destructors";

        public static readonly UseExpressionBodyForDestructors Instance = new UseExpressionBodyForDestructors();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<DestructorDeclarationSyntax>()
                .Where
                (destructor =>
                    destructor.Body != null &&
                    destructor.Body.Statements.Count == 1 &&
                    destructor.Body.Statements[0].IsKind(SyntaxKind.ExpressionStatement)
                )
                .Select(destructor => new AnalysisResult
                (
                    this,
                    analysisContext,
                    syntaxTree.FilePath,
                    destructor.TildeToken,
                    destructor
                ));
        }
    }
}