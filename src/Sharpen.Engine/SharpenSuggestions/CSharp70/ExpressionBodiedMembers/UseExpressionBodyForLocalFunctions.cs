using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70.ExpressionBodiedMembers
{
    internal sealed class UseExpressionBodyForLocalFunctions : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        private UseExpressionBodyForLocalFunctions() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp70;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.ExpressionBodiedMembers.Instance;

        public string FriendlyName { get; } = "Use expression body for local functions";

        public static readonly UseExpressionBodyForLocalFunctions Instance = new UseExpressionBodyForLocalFunctions();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<LocalFunctionStatementSyntax>()
                .Where
                (localFunction =>
                    localFunction.Body != null &&
                    localFunction.Body.Statements.Count == 1
                    && localFunction.Body.Statements[0].IsKind(SyntaxKind.ExpressionStatement)
                )
                .Select(localFunction => new AnalysisResult
                (
                    this,
                    analysisContext,
                    syntaxTree.FilePath,
                    localFunction.Identifier,
                    localFunction
                ));
        }
    }
}
