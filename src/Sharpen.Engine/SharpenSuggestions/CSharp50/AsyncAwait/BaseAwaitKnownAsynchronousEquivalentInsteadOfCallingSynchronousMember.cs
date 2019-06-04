using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.Extensions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal abstract class BaseAwaitKnownAsynchronousEquivalentInsteadOfCallingSynchronousMember : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {       
        public class SynchronousMemberReplacementInfo
        {
            public string AsyncEquivalentDisplayName { get; set; }
            public string SynchronousMemberDisplayName { get; set; }
            public string SynchronousMemberName { get; set; }
            public string SynchronousMemberTypeNamespace { get; set; }
            public string SynchronousMemberTypeName { get; set; }
        }

        private readonly SynchronousMemberReplacementInfo replacementInfo;

        protected BaseAwaitKnownAsynchronousEquivalentInsteadOfCallingSynchronousMember(SynchronousMemberReplacementInfo replacementInfo)
        {
            this.replacementInfo = replacementInfo;

            FriendlyName = $"Await {replacementInfo.AsyncEquivalentDisplayName} instead of calling {replacementInfo.SynchronousMemberDisplayName}";
        }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp50;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.AsyncAwait.Instance;

        public string FriendlyName { get; }

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .Where(method => method.IsAsync())
                .SelectMany(method => method.DescendantNodes())
                // TODO-IG: We have a slight bug here!
                //          We have to check that the invocation is exactly within
                //          this method and not within a local function within that
                //          method.
                // TODO-IG: Support also LocalFunctionStatementSyntax and not only
                //          MethodDeclarationSyntax.
                // We can have both methods (invocation) and properties (simple member access).
                // Unfortunately, it is not possible to combine them under a single umbrella.
                .Where(node => 
                    (
                        node.IsKind(SyntaxKind.InvocationExpression) &&
                        !node.IsWithinLambdaOrAnonymousMethod() && // See [1].
                        ((InvocationExpressionSyntax)node).GetInvokedMemberName() == replacementInfo.SynchronousMemberName
                        ||
                        node.IsKind(SyntaxKind.SimpleMemberAccessExpression) &&
                        !node.IsWithinLambdaOrAnonymousMethod() && // See [1].
                        node.Parent?.IsKind(SyntaxKind.InvocationExpression) == false &&
                        ((MemberAccessExpressionSyntax)node).Name.Identifier.ValueText == replacementInfo.SynchronousMemberName
                        )
                    &&
                    InvokedMemberHasAsynchronousEquivalentThatCanBeAwaited(node)
                )
                .Select(node => new AnalysisResult(
                    this,
                    analysisContext,
                    syntaxTree.FilePath,
                    GetStartingSyntaxNode(node).GetFirstToken(),
                    node.FirstAncestorOrSelf<StatementSyntax>() ?? node
                ));

            bool InvokedMemberHasAsynchronousEquivalentThatCanBeAwaited(SyntaxNode invocation)
            {
                var invokedMember = semanticModel.GetSymbolInfo(invocation).Symbol;
                if (invokedMember?.ContainingType == null) return false;

                return invokedMember.Name == replacementInfo.SynchronousMemberName &&
                       invokedMember.ContainingType.FullNameIsEqualTo(replacementInfo.SynchronousMemberTypeNamespace, replacementInfo.SynchronousMemberTypeName);
            }

            SyntaxNode GetStartingSyntaxNode(SyntaxNode node)
            {
                MemberAccessExpressionSyntax memberAccess;
                if (node.IsKind(SyntaxKind.InvocationExpression))
                {
                    var invocation = (InvocationExpressionSyntax) node;
                    memberAccess = invocation.Expression as MemberAccessExpressionSyntax;
                    if (memberAccess == null) return invocation.Expression;
                }
                else
                {
                    memberAccess = (MemberAccessExpressionSyntax) node;
                }

                return memberAccess.Name ?? (SyntaxNode)memberAccess;
            }
        }
    }
}

// [1]
// We want the cheapest IsKind() calls to be called first
// and afterwards immediately to have cheap checks for non-wanted
// containment in lambdas or anonymous methods.
// That's why the call to IsWithinLambdaOrAnonymousMethod() is
// not extracted but rather copied in both decision branches.