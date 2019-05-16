using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.Extensions.CodeDetection;
using Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait;
using Sharpen.Engine.SharpenSuggestions.CSharp80.AsyncStreams.Suggestions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp80.AsyncStreams.Analyzers
{
    // TODO: At the moment a quick copy-paste from the C# 5.0 AsyncAwait suggestions,
    //       in order to have a cool demo at the Weblica conference. Clean it up and refactor completely.
    internal sealed class ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerableAnalyzer : ISingleSyntaxTreeAnalyzer
    {
        // So far we will simply use the hardcoded one.
        private readonly EquivalentAsynchronousMethodFinder asynchronousMethodFinder =
            HardcodedLookupBasedEquivalentAsynchronousMethodFinder.Instance;

        private ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerableAnalyzer() { }

        public static readonly ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerableAnalyzer Instance = new ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerableAnalyzer();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            var descendantNodes = syntaxTree.GetRoot().DescendantNodes();

            // In unit test we of course expect people to test synchronous
            // versions of their methods. Moreover, we expect them to write
            // all kind of crazy acrobatics in tests in general.
            // Every suggestion to replace any synchronous method with their
            // async counterparts would very likely be totally
            // misplaced and misleading in unit tests. So we will simply
            // ignore these suggestions in unit tests.

            // It's fine to re-enumerate the nodes tree. It is a materialized structure.
            // ReSharper disable once PossibleMultipleEnumeration
            if (descendantNodes.ContainUnitTestingCode()) return Enumerable.Empty<AnalysisResult>();

            // ReSharper disable once PossibleMultipleEnumeration
            return descendantNodes
                .OfType<YieldStatementSyntax>()
                .Select(yieldStatement => yieldStatement.FirstAncestorOrSelf<MethodDeclarationSyntax>())
                // TODO: Yield must be in the method itself, not nested within a local function, or lambda, or delegate.
                // TODO: Make it work also for local functions and not only for methods.
                .Where(method => method != null)
                .Distinct() // Because we can have more than one yield statement in a method.
                .SelectMany(method => method.DescendantNodes().OfType<InvocationExpressionSyntax>())
                .Where(InvokedMethodHasAsynchronousEquivalent)
                .Select(invocation => new AnalysisResult(
                    ConsiderAwaitingEquivalentAsynchronousMethodAndYieldingIAsyncEnumerable.Instance,
                    analysisContext,
                    syntaxTree.FilePath,
                    GetStartingSyntaxNode(invocation).GetFirstToken(),
                    invocation
                ));

            bool InvokedMethodHasAsynchronousEquivalent(InvocationExpressionSyntax invocation)
            {
                return asynchronousMethodFinder.EquivalentAsynchronousCandidateExistsFor(invocation, semanticModel, EquivalentAsynchronousMethodFinder.CallerAsyncStatus.CallerMustNotBeAsync);
            }

            SyntaxNode GetStartingSyntaxNode(InvocationExpressionSyntax invocation)
            {
                if (!(invocation.Expression is MemberAccessExpressionSyntax memberAccess)) return invocation.Expression;
                return memberAccess.Name ?? (SyntaxNode)memberAccess;
            }
        }
    }
}