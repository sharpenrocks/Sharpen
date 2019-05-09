// The analysis algorithm is based on this one, used in the Roslyn project:
// https://github.com/dotnet/roslyn/blob/fd70a2aa33961bfe92afaecb68a1f15827b8b15b/src/Features/CSharp/Portable/UseSimpleUsingStatement/UseSimpleUsingStatementDiagnosticAnalyzer.cs
// The original copyright line:
// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.SharpenSuggestions.CSharp80.UsingDeclarations.Suggestions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp80.UsingDeclarations.Analyzers
{
    internal sealed class ReplaceUsingStatementWithUsingDeclarationAnalyzer : ISingleSyntaxTreeAnalyzer
    {
        private ReplaceUsingStatementWithUsingDeclarationAnalyzer() { }

        public static readonly ReplaceUsingStatementWithUsingDeclarationAnalyzer Instance = new ReplaceUsingStatementWithUsingDeclarationAnalyzer();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<UsingStatementSyntax>()
                .Select(GetUsingStatementPotentialReplaceabilityInfo)
                .Where(replaceabilityInfo => replaceabilityInfo.usingStatement != null)
                .Select(replaceabilityInfo => new AnalysisResult
                (
                    replaceabilityInfo.surelyPreservesSemantics
                        ? (ISharpenSuggestion)ReplaceUsingStatementWithUsingDeclaration.Instance
                        : ConsiderReplacingUsingStatementWithUsingDeclaration.Instance,
                    analysisContext,
                    syntaxTree.FilePath,
                    replaceabilityInfo.usingStatement.UsingKeyword,
                    replaceabilityInfo.usingStatement
                ));

            // A bit ugly way to get the information out.
            // Done this way in order to reuse the structure of the original algorithm.
            // TODO-IG: Refactor.
            // ´usingStatement´ is null if the replacement is not possible.
            (UsingStatementSyntax usingStatement, bool surelyPreservesSemantics) GetUsingStatementPotentialReplaceabilityInfo(UsingStatementSyntax usingStatement)
            {
                var outermostUsing = usingStatement;

                // Don't offer on a using statement that is parented by another using statement.
                // We'll just offer on the topmost using statement.
                if (!(outermostUsing.Parent is BlockSyntax parentBlock)) return (null, false);

                var innermostUsing = outermostUsing;

                // Check that all the immediately nested usings are convertible as well.
                // We don't want take a sequence of nested-using and only convert some of them.
                for (var current = outermostUsing; current != null; current = current.Statement as UsingStatementSyntax)
                {
                    innermostUsing = current;
                    if (current.Declaration == null) return (null, false);
                }

                // Verify that changing this using-statement into a using-declaration will not
                // change semantics.
                var parentStatements = parentBlock.Statements;
                var index = parentStatements.IndexOf(outermostUsing);

                // TODO: At the moment, if we have jumps (OMG!) we will simply not deal with it at all.
                if (!UsingStatementDoesNotInvolveJumps()) return (null, false);

                // Everything is fine, the using statement *could* be replaced
                // with the using declaration, the potential leakage of the using value
                // determines if it is 100% save to do it or not.
                return (usingStatement, UsingValueDoesNotLeakToFollowingStatements());
                           
                bool UsingValueDoesNotLeakToFollowingStatements()
                {
                    // Has to be one of the following forms:
                    // 1. Using statement is the last statement in the parent.
                    // 2. Using statement is not the last statement in parent, but is followed by 
                    //    something that is unaffected by simplifying the using statement.  I.e.
                    //    `return`/`break`/`continue`.  *Note*.  `return expr` would *not* be ok.
                    //    In that case, `expr` would now be evaluated *before* the using disposed
                    //    the resource, instead of afterwards.  Effectively, the statement following
                    //    cannot actually execute any code that might depend on the Dispose() method
                    //    being called or not.

                    // Very last statement in the block. Can be converted.
                    if (index == parentStatements.Count - 1) return true;

                    // Not the last statement, get the next statement and examine that.
                    var nextStatement = parentStatements[index + 1];
                    // Using statement followed by break/continue. Can convert this as executing
                    // the break/continue will cause the code to exit the using scope, causing
                    // Dispose to be called at the same place as before.
                    if (nextStatement is BreakStatementSyntax ||
                        nextStatement is ContinueStatementSyntax)
                        return true;

                    // Using statement followed by `return`. Can convert this as executing
                    // the `return` will cause the code to exit the using scope, causing
                    // Dispose() to be called at the same place as before.

                    // Note: the expr has to be null.  If it was non-null, then the expr would
                    // now execute before the using called Dispose() instead of after, potentially
                    // changing semantics.
                    if (nextStatement is ReturnStatementSyntax returnStatement &&
                        returnStatement.Expression == null)
                        return true;

                    return false;
                }

                bool UsingStatementDoesNotInvolveJumps()
                {
                    // Jumps are not allowed to cross a using declaration in the forward direction,
                    // and can't go back unless there is a curly brace between the using and the label.
                    // We conservatively implement this by disallowing the change if there are gotos/labels
                    // in the containing block, or inside the using body.

                    // TODO-IG: Check for after as well in the case of "Consider" suggestion where we will have statements after the using.
                    // Note: we only have to check up to the `using`, since the checks below in
                    // UsingValueDoesNotLeakToFollowingStatements ensure that there would be no
                    // labels/gotos *after* the using statement.
                    for (int i = 0; i < index; i++)
                    {
                        var priorStatement = parentStatements[i];
                        if (IsGotoOrLabeledStatement(priorStatement))
                        {
                            return false;
                        }
                    }

                    var innerStatements = innermostUsing.Statement is BlockSyntax block
                        ? block.Statements
                        // TODO-IG: See how to create a SyntaxList. This version of Roslyn does not support the constructor with parameters.
                        : new SyntaxList<StatementSyntax>().Add(innermostUsing.Statement);

                    foreach (var statement in innerStatements)
                    {
                        if (IsGotoOrLabeledStatement(statement)) return false;
                    }

                    return true;

                    bool IsGotoOrLabeledStatement(StatementSyntax priorStatement)
                        => priorStatement.Kind() == SyntaxKind.GotoStatement ||
                           priorStatement.Kind() == SyntaxKind.LabeledStatement;
                }
            }
        }        
    }
}