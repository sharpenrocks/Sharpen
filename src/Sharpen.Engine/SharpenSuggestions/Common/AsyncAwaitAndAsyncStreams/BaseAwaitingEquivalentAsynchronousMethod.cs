using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.Extensions.CodeDetection;
using Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait;

namespace Sharpen.Engine.SharpenSuggestions.Common.AsyncAwaitAndAsyncStreams
{
    internal abstract class BaseAwaitingEquivalentAsynchronousMethod : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        private readonly EquivalentAsynchronousMethodFinder.CallerAsyncStatus callerAsyncStatus;
        private readonly EquivalentAsynchronousMethodFinder.CallerYieldingStatus callerYieldingStatus;

        // So far we will simply use the hardcoded one.
        private readonly EquivalentAsynchronousMethodFinder asynchronousMethodFinder =
            HardcodedLookupBasedEquivalentAsynchronousMethodFinder.Instance;

        protected BaseAwaitingEquivalentAsynchronousMethod(EquivalentAsynchronousMethodFinder.CallerAsyncStatus callerAsyncStatus, EquivalentAsynchronousMethodFinder.CallerYieldingStatus callerYieldingStatus)
        {
            this.callerAsyncStatus = callerAsyncStatus;
            this.callerYieldingStatus = callerYieldingStatus;
        }

        public virtual string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp50;

        public virtual ICSharpFeature LanguageFeature { get; } = CSharpFeatures.AsyncAwait.Instance;

        public abstract string FriendlyName { get; }

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
                return asynchronousMethodFinder.EquivalentAsynchronousCandidateExistsFor(invocation, semanticModel, callerAsyncStatus, callerYieldingStatus);
            }

            SyntaxNode GetStartingSyntaxNode(InvocationExpressionSyntax invocation)
            {
                if (!(invocation.Expression is MemberAccessExpressionSyntax memberAccess)) return invocation.Expression;
                return memberAccess.Name ?? (SyntaxNode)memberAccess;
            }
        }
    }
}