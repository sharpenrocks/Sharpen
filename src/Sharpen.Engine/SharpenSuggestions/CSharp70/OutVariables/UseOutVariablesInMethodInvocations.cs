using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Extensions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70.OutVariables
{
    internal sealed class UseOutVariablesInMethodInvocations : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        private UseOutVariablesInMethodInvocations() { }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp70;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.OutVariables.Instance;

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
                    OutArgumentCanBecomeOutVariableOrCanBeDiscarded(semanticModel, argument, false)
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

        private static bool OutArgumentCanBecomeOutVariableOrCanBeDiscarded(SemanticModel semanticModel, ArgumentSyntax outArgument, bool outArgumentCanBeDiscarded)
        {
            var enclosingStatement = outArgument.LastAncestorOrSelf<StatementSyntax>(); // E.g. method body block.
            var outArgumentIdentifier = (IdentifierNameSyntax) outArgument.Expression;
            var outVariableName = outArgumentIdentifier.Identifier.ValueText;

            // 1. The out argument must be a local variable.
            var variableDeclarator = GetLocalVariableDeclaratorForOutArgument();
            if (variableDeclarator == null) return false;

            // 2. If the local variable is initialized within the declaration, it means that it is used.
            if (variableDeclarator.Initializer != null) return false;


            // 3. The local variable must not be used before it is passed to the method as an out argument.
            //    Also, if it is a requirement that the out argument can be discarded, it must not be used
            //    anywhere in code after the out argument.

            var localVariableSymbol = semanticModel.GetSymbolInfo(outArgumentIdentifier).Symbol;
            var localVariableTextSpan = variableDeclarator.Identifier.Span;
            var outArgumentTextSpan = outArgumentIdentifier.Span;

            // Find all the usages of the local variable within the enclosing e.g. method body block
            // that are different then its declaration and the usage in the out variable itself.
            // Those usage then appear either between the variable declaration and the out argument
            // or after the out argument.
            var (numberOfUsagesBeforeOutArgument, numberOfUsagesAfterOutArgument) = enclosingStatement
                .DescendantNodes()
                .OfType<IdentifierNameSyntax>()
                .Where(identifier =>
                    identifier.Identifier.ValueText == outVariableName &&
                    identifier.Span != localVariableTextSpan && // It is not the declaration of the local variable.
                    identifier != outArgumentIdentifier && // It is not the out argument itself.
                    semanticModel.GetSymbolInfo(identifier).Symbol.Equals(localVariableSymbol)
                )
                .CountMany
                (
                    identifier => identifier.Identifier.Span.IsBetween(localVariableTextSpan, outArgumentTextSpan),
                    identifier => identifier.Identifier.Span.IsAfter(outArgumentTextSpan)
                );

            return numberOfUsagesBeforeOutArgument == 0 &&
                   (
                       outArgumentCanBeDiscarded && numberOfUsagesAfterOutArgument == 0
                       ||
                       !outArgumentCanBeDiscarded && numberOfUsagesAfterOutArgument > 0
                   );

            // TODO: One check is missing. See the Remark #1 at the bottom of this file.

            VariableDeclaratorSyntax GetLocalVariableDeclaratorForOutArgument()
            {
                return enclosingStatement?
                    .DescendantNodes()
                    .OfType<LocalDeclarationStatementSyntax>()
                    .SelectMany(localDeclaration => localDeclaration.DescendantNodes().OfType<VariableDeclarationSyntax>())
                    .SelectMany(variableDeclaration => variableDeclaration.Variables)
                    .FirstOrDefault(variable => variable.Identifier.ValueText == outVariableName);
            }
        }
    }
}

/*
    Remark #1.
    We have to check that if the argument cannot be discarded
    (the local variable is used afterwards) and if we turn it into
    an out variable, that the scope of the out variable remains the
    same as the previous scope of the local variable.

    E.g. in this case we would end up in compile error if we turn the
    local variable into an out variable.

    int i;
    if (someCondition)
    {
        Out(out i);
    }
    else
    {
        i = Something();
    }
 
    So far we will assume that this case happens rarely in real life
    and we will ship the current solution.
    Still, this has to be properly implemented.
 */