using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;

namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal sealed class ConsiderAwaitingEquivalentAsynchronousMethod : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        // So far we will simply use the hardcoded one.
        private readonly EquivalentAsynchronousMethodFinder asynchronousMethodFinder =
            HardcodedLookupBasedEquivalentAsynchronousMethodFinder.Instance;

        private ConsiderAwaitingEquivalentAsynchronousMethod() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp50;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.AsyncAwait.Instance;

        public string FriendlyName { get; } = "Consider awaiting equivalent asynchronous method";

        public static readonly ConsiderAwaitingEquivalentAsynchronousMethod Instance = new ConsiderAwaitingEquivalentAsynchronousMethod();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<InvocationExpressionSyntax>()
                .Where(InvokedMethodHasAsynchronousEquivalent)
                .Select(invocation => new AnalysisResult(
                    this,
                    analysisContext,
                    syntaxTree.FilePath,
                    GetStartingSyntaxNode(invocation).GetFirstToken(),
                    invocation
                ));

            bool InvokedMethodHasAsynchronousEquivalent(InvocationExpressionSyntax invocation)
            {
                return asynchronousMethodFinder.EquivalentAsynchronousMethodExistsFor(invocation, semanticModel);
            }

            SyntaxNode GetStartingSyntaxNode(InvocationExpressionSyntax invocation)
            {
                if (!(invocation.Expression is MemberAccessExpressionSyntax memberAccess)) return invocation.Expression;
                return memberAccess.Name ?? (SyntaxNode)memberAccess;
            }
        }
    }
}