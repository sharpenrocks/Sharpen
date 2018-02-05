using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.SharpenSuggestions.CSharp71.DefaultExpressions
{
    internal sealed class UseDefaultExpressionInReturnStatements : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        private UseDefaultExpressionInReturnStatements() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp71;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.DefaultExpressions.Instance;

        public string FriendlyName { get; } = "Use default expression in return statements";

        public static readonly UseDefaultExpressionInReturnStatements Instance = new UseDefaultExpressionInReturnStatements();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<DefaultExpressionSyntax>()
                .Where(expression => expression.Parent.IsKind(SyntaxKind.ReturnStatement))
                .Select(expression => new
                    {
                        ReturnStatement = (ReturnStatementSyntax)expression.Parent,
                        DefaultExpressionType = semanticModel.GetTypeInfo(expression).Type,
                        EnclosingDeclarationReturnType = GetEnclosingDeclarationReturnType(expression, semanticModel)
                    }
                )
                // DefaultExpressionType is never null and the EnclosingDeclarationReturnType can so far be null.
                // That's why it is important to call Equals exactly on the DefaultExpressionType.
                .Where(types => types.DefaultExpressionType.Equals(types.EnclosingDeclarationReturnType))
                .Select(types => new AnalysisResult
                (
                    this,
                    analysisContext,
                    syntaxTree.FilePath,
                    types.ReturnStatement.ReturnKeyword,
                    types.ReturnStatement
                ));
        }

        private static ITypeSymbol GetEnclosingDeclarationReturnType(DefaultExpressionSyntax expression, SemanticModel semanticModel)
        {
            var method = expression.FirstAncestorOrSelf<MethodDeclarationSyntax>();
            if (method != null) return semanticModel.GetDeclaredSymbol(method).ReturnType;

            var @operator = expression.FirstAncestorOrSelf<OperatorDeclarationSyntax>();
            if (@operator != null) return semanticModel.GetDeclaredSymbol(@operator).ReturnType;

            var conversion = expression.FirstAncestorOrSelf<ConversionOperatorDeclarationSyntax>();
            if (conversion != null) return semanticModel.GetDeclaredSymbol(conversion).ReturnType;

            var property = expression.FirstAncestorOrSelf<BasePropertyDeclarationSyntax>(); // Properties and indexers.
            if (property != null) return ((IPropertySymbol)semanticModel.GetDeclaredSymbol(property)).Type;

            // TODO: Support finding the type for other enclosing declarations in which the return statement can appear.
            //       So far we will check just the most important ones. It is anyway very unlikely to have the default(T) in most of them.
            //       Right now we will simply return null and the check for the type equality in the query will return false and thus
            //       at the moment simply ignore those cases.
            return null;
        }
    }
}