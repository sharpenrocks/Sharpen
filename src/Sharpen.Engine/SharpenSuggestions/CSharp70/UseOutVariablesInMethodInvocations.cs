using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.CSharpFeatures;
using Sharpen.Engine.Extensions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70
{
    internal sealed class UseOutVariablesInMethodInvocations : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        private UseOutVariablesInMethodInvocations() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp70;

        public ICSharpFeature LanguageFeature { get; } = OutVariables.Instance;

        public string FriendlyName { get; } = "Use out variables in method invocations";

        public static readonly UseOutVariablesInMethodInvocations Instance = new UseOutVariablesInMethodInvocations();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<ArgumentSyntax>()
                .Where(argument =>
                    argument.RefOrOutKeyword.IsKind(SyntaxKind.OutKeyword) &&
                    argument.Expression.IsKind(SyntaxKind.IdentifierName) &&
                    GetLocalVariableDeclaratorForIdentifier(argument, ((IdentifierNameSyntax)argument.Expression).Identifier) is VariableDeclaratorSyntax declarator &&
                    VariableIsNotUsedBeforePassedAsOutArgument(semanticModel, declarator, argument)
                )
                .Select(argument => new AnalysisResult
                (
                    this,
                    analysisContext,
                    syntaxTree.FilePath,
                    argument.RefOrOutKeyword,
                    argument.FirstAncestorOrSelf<InvocationExpressionSyntax>()
                ));
        }

        // TODO-IG: Rename all the below methods, adapt their signatures and move them to some common library.
        //          E.g. bool OutIdentifierIsDeclaredAsALocalVariable(SyntaxNode nodeWithinTheScope, SyntaxToken identifier)

        private static VariableDeclaratorSyntax GetLocalVariableDeclaratorForIdentifier(SyntaxNode nodeWithinTheScope, SyntaxToken identifier)
        {
            var statement = nodeWithinTheScope.LastAncestorOrSelf<StatementSyntax>();

            return statement?
                .DescendantNodes()
                .OfType<LocalDeclarationStatementSyntax>()
                .SelectMany(localDeclaration => localDeclaration.DescendantNodes().OfType<VariableDeclarationSyntax>())
                .SelectMany(variableDeclaration => variableDeclaration.Variables)
                .FirstOrDefault(variable => variable.Identifier.ValueText == identifier.ValueText);
        }

        private static bool VariableIsNotUsedBeforePassedAsOutArgument(SemanticModel semanticModel, VariableDeclaratorSyntax variableDeclarator, ArgumentSyntax argument)
        {
            var firstStatement = variableDeclarator.FirstAncestorOrSelf<StatementSyntax>();
            var lastStatement = argument.FirstAncestorOrSelf<StatementSyntax>().PrecedingSyblingOrSelf();


            DataFlowAnalysis dataFlow;
            try
            {
                // TODO-IG: Implement a proprietary data flow analysis that will work over statements that do not have same parent.
                //          The AnalyzeDataFlow() method will throw exception if the firstStatement and the lastStatement are
                //          not within the same immediate parent statement. We have to implement a data flow analysis that will
                //          accept statements that have a common root parent statement, but are not necessarily within the same
                //          immediate parent statement.
                dataFlow = semanticModel.AnalyzeDataFlow(firstStatement, lastStatement);
            }
            catch
            {
                // TODO-IG: Remove the try-catch block once the data flow analysis is implemented.
                //          At the moment, if the firstStatement and the lastStatement are not within the same immediate parent
                //          we will simply assume that the variable is used, although this must not actually be the case.
                //          Such cases will anyway appear rarely, so we can live with it so far.
                return false;
            }

            var outVariableName = variableDeclarator.Identifier.ValueText;
            return dataFlow.ReadInside.Union(dataFlow.WrittenInside).All(symbol => symbol.Name != outVariableName);
        }
    }
}