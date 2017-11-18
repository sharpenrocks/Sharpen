using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.CSharpFeatures;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70
{
    public abstract class BaseUseExpressionBodyForGetAccessors<TBasePropertyDeclarationSyntax> : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
        where TBasePropertyDeclarationSyntax: BasePropertyDeclarationSyntax
    {
        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp70;

        public ICSharpFeature LanguageFeature { get; } = ExpressionBodiedMembers.Instance;

        public abstract string FriendlyName { get; }

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<AccessorDeclarationSyntax>()
                .Where
                (accessor => 
                    accessor.Keyword.IsKind(SyntaxKind.GetKeyword) &&
                    accessor.Body != null &&
                    accessor.Body.Statements.Count == 1 &&
                    accessor.Body.Statements[0].IsKind(SyntaxKind.ReturnStatement) &&
                    ((AccessorListSyntax)accessor.Parent).Accessors.Count > 1 && // We must have the set-accessor as well (see [1]).
                    accessor.FirstAncestorOrSelf<TBasePropertyDeclarationSyntax>() != null // We must be either in a property or in an indexer.
                )
                .Select(accessor => new AnalysisResult
                (
                    this,
                    syntaxTree.FilePath,
                    accessor.Keyword,
                    accessor.FirstAncestorOrSelf<TBasePropertyDeclarationSyntax>()
                ));
        }
    }
}

/* 
    [1] If there is now set accessor then we do not want to have the get accessor with expression body but the get-only property with expression body.
*/