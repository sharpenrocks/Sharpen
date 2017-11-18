using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.CSharpFeatures;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70
{
    internal sealed class UseExpressionBodyForConstructors : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        private UseExpressionBodyForConstructors() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp70;

        public ICSharpFeature LanguageFeature { get; } = ExpressionBodiedMembers.Instance;

        public string FriendlyName { get; } = "Use expression body for constructors";

        public static readonly UseExpressionBodyForConstructors Instance = new UseExpressionBodyForConstructors();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<ConstructorDeclarationSyntax>()
                .Where
                (constructor =>
                    constructor.Body != null &&
                    constructor.Body.Statements.Count == 1
                    && constructor.Body.Statements[0].IsKind(SyntaxKind.ExpressionStatement)
                )
                .Select(constructor => new AnalysisResult
                (
                    this,
                    syntaxTree.FilePath,
                    constructor.Identifier,
                    constructor
                ));
        }
    }
}
