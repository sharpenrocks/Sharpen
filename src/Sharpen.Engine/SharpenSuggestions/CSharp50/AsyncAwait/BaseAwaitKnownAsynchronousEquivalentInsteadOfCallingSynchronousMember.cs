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

        public SharpenSuggestionType SuggestionType { get; } = SharpenSuggestionType.Recommendation;

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfAnyOfKinds(SyntaxKind.MethodDeclaration, SyntaxKind.LocalFunctionStatement)
                .Where(methodOrLocalFunction => methodOrLocalFunction.IsAsync())
                .SelectMany(methodOrLocalFunction => methodOrLocalFunction
                    .DescendantNodes()
                    // We can have both known methods like e.g. Wait() (invocation)
                    // and known properties like e.g. Result (simple member access).
                    .OfAnyOfKinds(SyntaxKind.InvocationExpression, SyntaxKind.SimpleMemberAccessExpression)
                    .Select(node =>
                    (
                        caller: methodOrLocalFunction,
                        node
                    )))
                .Where(callerAndNode =>
                    !callerAndNode.node.IsWithinLambdaOrAnonymousMethod()
                    &&
                    InvocationIsDirectlyWithinTheCaller(callerAndNode.node, callerAndNode.caller)
                    &&
                    (
                        callerAndNode.node.IsKind(SyntaxKind.InvocationExpression) &&
                        ((InvocationExpressionSyntax)callerAndNode.node).GetInvokedMemberName() == replacementInfo.SynchronousMemberName
                        ||
                        callerAndNode.node.IsKind(SyntaxKind.SimpleMemberAccessExpression) &&
                        callerAndNode.node.Parent?.IsKind(SyntaxKind.InvocationExpression) == false &&
                        ((MemberAccessExpressionSyntax)callerAndNode.node).Name.Identifier.ValueText == replacementInfo.SynchronousMemberName
                    )
                    &&
                    InvocationHasAsynchronousEquivalentThatCanBeAwaited(callerAndNode.node)
                )
                .Select(callerAndNode => new AnalysisResult(
                    this,
                    analysisContext,
                    syntaxTree.FilePath,
                    GetStartingSyntaxNode(callerAndNode.node).GetFirstToken(),
                    callerAndNode.node.FirstAncestorOrSelf<StatementSyntax>() ?? callerAndNode.node
                ));

            bool InvocationIsDirectlyWithinTheCaller(SyntaxNode invocation, SyntaxNode caller)
            {
                // We have to check that the invocation node is directly within
                // the caller, means it is not within some local function within the
                // caller.
                // In other words, there must not be any LocalFunctionStatementSyntax node
                // between the invocation and the caller.
                return invocation.FirstAncestorOrSelfWithinEnclosingNode<LocalFunctionStatementSyntax>(caller, false) == null;
            }

            bool InvocationHasAsynchronousEquivalentThatCanBeAwaited(SyntaxNode invocation)
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