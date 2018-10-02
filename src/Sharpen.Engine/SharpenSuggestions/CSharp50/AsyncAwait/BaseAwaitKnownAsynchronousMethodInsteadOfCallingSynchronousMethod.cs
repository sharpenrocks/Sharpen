using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.Extensions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp50.AsyncAwait
{
    internal abstract class BaseAwaitKnownAsynchronousMethodInsteadOfCallingSynchronousMethod : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {       
        public class MethodReplacementInfo
        {
            public string AsyncMethodDisplayName { get; set; }
            public string SynchronousMethodDisplayName { get; set; }
            public string SynchronousMethodName { get; set; }
            public string SynchronousMethodTypeNamespace { get; set; }
            public string SynchronousMethodTypeName { get; set; }
        }

        private readonly MethodReplacementInfo replacementInfo;

        protected BaseAwaitKnownAsynchronousMethodInsteadOfCallingSynchronousMethod(MethodReplacementInfo replacementInfo)
        {
            this.replacementInfo = replacementInfo;

            FriendlyName = $"Await {replacementInfo.AsyncMethodDisplayName} instead of calling {replacementInfo.SynchronousMethodDisplayName}";
        }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp50;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.AsyncAwait.Instance;

        public string FriendlyName { get; }

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<InvocationExpressionSyntax>()
                .Where(InvokedMethodHasAsynchronousEquivalentThatCanBeAwaited)
                .Select(invocation => new AnalysisResult(
                    this,
                    analysisContext,
                    syntaxTree.FilePath,
                    GetStartingSyntaxNode(invocation).GetFirstToken(),
                    invocation
                ));

            bool InvokedMethodHasAsynchronousEquivalentThatCanBeAwaited(InvocationExpressionSyntax invocation)
            {
                if (invocation.GetInvokedMethodName() != replacementInfo.SynchronousMethodName) return false;

                if (invocation.IsInvokedWithinLambdaOrAnonymousMethod()) return false;

                if (!EnclosingMethodIsAsync()) return false;

                if (!(ModelExtensions.GetSymbolInfo(semanticModel, invocation).Symbol is IMethodSymbol method)) return false;

                if (method.ContainingType == null) return false;

                return method.Name == replacementInfo.SynchronousMethodName &&
                       method.ContainingType.FullNameIsEqualTo(replacementInfo.SynchronousMethodTypeNamespace, replacementInfo.SynchronousMethodTypeName);

                bool EnclosingMethodIsAsync()
                {
                    return invocation.FirstAncestorOrSelf<MethodDeclarationSyntax>()?
                               .Modifiers.Any(syntaxToken => syntaxToken.IsKind(SyntaxKind.AsyncKeyword)) == true;
                }
            }

            SyntaxNode GetStartingSyntaxNode(InvocationExpressionSyntax invocation)
            {
                if (!(invocation.Expression is MemberAccessExpressionSyntax memberAccess)) return invocation.Expression;
                return memberAccess.Name ?? (SyntaxNode)memberAccess;
            }
        }
    }
}