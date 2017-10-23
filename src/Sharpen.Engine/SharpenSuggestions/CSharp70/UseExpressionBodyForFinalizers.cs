using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.CSharpFeatures;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70
{
    public class UseExpressionBodyForFinalizers : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        private UseExpressionBodyForFinalizers() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp70;

        public ICSharpFeature LanguageFeature { get; } = ExpressionBodiedMembers.Instance;

        public string FriendlyName { get; } = "Use expression body for finalizers";

        public static readonly UseExpressionBodyForFinalizers Instance = new UseExpressionBodyForFinalizers();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<DestructorDeclarationSyntax>()
                .Where(destructor => destructor.Body != null && destructor.Body.Statements.Count == 1 && destructor.Body.Statements[0] is ExpressionStatementSyntax)
                .Select(destructor => new AnalysisResult(this, syntaxTree.FilePath, destructor.TildeToken));
        }
    }
}