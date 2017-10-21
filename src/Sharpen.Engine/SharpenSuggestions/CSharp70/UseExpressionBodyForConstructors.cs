using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.CSharpFeatures;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70
{
    public class UseExpressionBodyForConstructors : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        private UseExpressionBodyForConstructors() { }

        public CSharpLanguageVersion MinimumLanguageVersion { get; } = CSharpLanguageVersion.CSharp70;

        public ICSharpFeature LanguageFeature { get; } = ExpressionBodiedMembers.Instance;

        public string FriendlyName { get; } = "Use expression body for constructors";

        public static readonly UseExpressionBodyForConstructors Instance = new UseExpressionBodyForConstructors();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<ConstructorDeclarationSyntax>()
                .Select(constructor => new AnalysisResult(this, syntaxTree.FilePath, constructor.FullSpan));
        }
    }
}
