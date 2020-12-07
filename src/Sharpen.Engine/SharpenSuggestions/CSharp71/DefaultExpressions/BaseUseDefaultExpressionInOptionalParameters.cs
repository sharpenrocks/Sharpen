using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;

namespace Sharpen.Engine.SharpenSuggestions.CSharp71.DefaultExpressions
{
    internal abstract class BaseUseDefaultExpressionInOptionalParameters<TBaseMethodDeclarationSyntax> : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
        where TBaseMethodDeclarationSyntax : SyntaxNode
    {
        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp71;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.DefaultExpressions.Instance;

        public abstract string FriendlyName { get; }

        public SharpenSuggestionType SuggestionType { get; } = SharpenSuggestionType.Recommendation;

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<DefaultExpressionSyntax>()
                .Where(expression => 
                    expression.FirstAncestorOrSelf<ParameterSyntax>() != null &&
                    expression.FirstAncestorOrSelf<TBaseMethodDeclarationSyntax>() != null
                )
                .Select(expression => new
                    {
                        Parameter = expression.FirstAncestorOrSelf<ParameterSyntax>(),
                        DefaultExpressionType = semanticModel.GetTypeInfo(expression).Type,
                        DefaultKeywordToken = expression.Keyword
                    }
                )
                .Where(types => types.DefaultExpressionType.Equals(semanticModel.GetTypeInfo(types.Parameter.Type).Type))
                .Select(types => new AnalysisResult
                (
                    this,
                    analysisContext,
                    syntaxTree.FilePath,
                    types.DefaultKeywordToken,
                    types.Parameter
                ));
        }
    }
}