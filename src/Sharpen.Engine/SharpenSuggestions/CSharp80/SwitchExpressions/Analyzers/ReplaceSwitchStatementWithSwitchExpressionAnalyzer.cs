using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.SharpenSuggestions.CSharp80.SwitchExpressions.Suggestions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp80.SwitchExpressions.Analyzers
{
    internal sealed class ReplaceSwitchStatementWithSwitchExpressionAnalyzer : ISingleSyntaxTreeAnalyzer
    {
        private ReplaceSwitchStatementWithSwitchExpressionAnalyzer() { }

        public static readonly ReplaceSwitchStatementWithSwitchExpressionAnalyzer Instance = new ReplaceSwitchStatementWithSwitchExpressionAnalyzer();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<SwitchStatementSyntax>()
                .Select(GetSwitchStatementPotentialReplaceabilityInfo)
                .Where(replaceabilityInfo => replaceabilityInfo.suggestion != null)
                .Select(replaceabilityInfo => new AnalysisResult
                (
                    replaceabilityInfo.suggestion,
                    analysisContext,
                    syntaxTree.FilePath,
                    replaceabilityInfo.switchStatement.SwitchKeyword,
                    replaceabilityInfo.switchStatement
                ));

            (ISharpenSuggestion suggestion,
             SwitchStatementSyntax switchStatement)
            GetSwitchStatementPotentialReplaceabilityInfo(SwitchStatementSyntax switchStatement)
            {
                // We have to have at least one switch section (case or default).
                if (switchStatement.Sections.Count <= 0) return (null, null);

                // TODO-IG: We can have more than one case label within a single section.
                //          E.g. case 1: case 2: case 3: ...
                //          At the moment we will simply not support this case.
                //          We insist so far on a single label.
                //          Implement this case in the future by offering a "Consider" suggestion.
                if (switchStatement.Sections.Any(switchSection => switchSection.Labels.Count != 1))
                    return (null, null);

                // If we have the default section it is surely exhaustive.
                // Otherwise we cannot be sure. We will, of course, not do any
                // check for exhaustiveness that the compiler does.
                bool isSurelyExhaustive = switchStatement.Sections.Any(switchSection =>
                    switchSection.Labels.Any(label => label.IsKind(SyntaxKind.DefaultSwitchLabel)));

                if (AllSwitchSectionsAreAssignmentsToTheSameIdentifier(switchStatement.Sections))
                    return
                    (
                        isSurelyExhaustive
                            ? (ISharpenSuggestion)ReplaceSwitchStatementContainingOnlyAssignmentsWithSwitchExpression.Instance
                            : ConsiderReplacingSwitchStatementContainingOnlyAssignmentsWithSwitchExpression.Instance,
                        switchStatement
                    );

                if (AllSwitchSectionsAreReturnStatements(switchStatement.Sections))
                    return
                    (
                        isSurelyExhaustive
                            ? (ISharpenSuggestion)ReplaceSwitchStatementContainingOnlyReturnsWithSwitchExpression.Instance
                            : ConsiderReplacingSwitchStatementContainingOnlyReturnsWithSwitchExpression.Instance,
                        switchStatement
                    );

                return (null, null);

                bool AllSwitchSectionsAreAssignmentsToTheSameIdentifier(SyntaxList<SwitchSectionSyntax> switchSections)
                {
                    ISymbol previousIdentifierSymbol = null;
                    foreach (var switchSection in switchSections)
                    {
                        // We can have two cases that are valid.
                        switch (switchSection.Statements.Count)
                        {
                            // We have only one statement which then must be exception throwing.
                            case 1:
                                if (!switchSection.Statements[0].IsKind(SyntaxKind.ThrowStatement)) return false;
                                break;

                            // We have two statements, which then must be an assignment immediately followed by break.
                            case 2:
                                if (!switchSection.Statements[1].IsKind(SyntaxKind.BreakStatement)) return false;
                                if (!(switchSection.Statements[0] is ExpressionStatementSyntax expression)) return false;
                                if (!(expression.Expression is AssignmentExpressionSyntax assignment)) return false;

                                // TODO-IG: At the moment we do not support compound assignments (+=, *=, -=, /=, ...).
                                //          We insist so far on the simple assignment operator (=).
                                //          Implement this case in the future by offering a "Consider" suggestion.
                                if (!assignment.IsKind(SyntaxKind.SimpleAssignmentExpression)) return false;

                                if (assignment.Left == null) return false;

                                var currentIdentifierSymbol = semanticModel.GetSymbolInfo(assignment.Left).Symbol;
                                if (currentIdentifierSymbol == null) return false;

                                if (previousIdentifierSymbol != null && !previousIdentifierSymbol.Equals(currentIdentifierSymbol)) return false;

                                previousIdentifierSymbol = currentIdentifierSymbol;
                                break;

                            default: return false;
                        }
                    }

                    return true;
                }

                bool AllSwitchSectionsAreReturnStatements(SyntaxList<SwitchSectionSyntax> switchSections)
                {
                    foreach (var switchSection in switchSections)
                    {
                        // Valid cases are either throwing an exception or having return.
                        // In both cases we expect exactly one statement.
                        if (switchSection.Statements.Count != 1) return false;

                        switch (switchSection.Statements[0].Kind())
                        {
                            case SyntaxKind.ReturnStatement:
                                var returnStatement = (ReturnStatementSyntax) switchSection.Statements[0];
                                // The statement must return something.
                                // We are not interested in checking the type
                                // of the returned expression, checking that
                                // they are always the same. We assume that the switch
                                // statement is already valid.
                                if (returnStatement.Expression == null) return false;
                                break;

                            case SyntaxKind.ThrowStatement:
                                // This is just fine.
                                break;

                            default: return false;
                        }
                    }

                    return true;
                }
            }
        }
    }
}