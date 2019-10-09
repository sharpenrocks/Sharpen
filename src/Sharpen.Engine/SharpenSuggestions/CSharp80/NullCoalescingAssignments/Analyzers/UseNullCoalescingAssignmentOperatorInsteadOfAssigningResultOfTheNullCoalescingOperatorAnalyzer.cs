// The analysis algorithm is based on this one, used in the Roslyn project:
// https://github.com/dotnet/roslyn/blob/2b6fb9371020373ff1addb661b7c528dea435714/src/Features/Core/Portable/UseCompoundAssignment/AbstractUseCompoundAssignmentDiagnosticAnalyzer.cs
// The original copyright line:
// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.Extensions;
using Sharpen.Engine.Facts;
using Sharpen.Engine.SharpenSuggestions.CSharp80.NullCoalescingAssignments.Suggestions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullCoalescingAssignments.Analyzers
{
    internal sealed class UseNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperatorAnalyzer : ISingleSyntaxTreeAnalyzer
    {
        private UseNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperatorAnalyzer() { }

        public static readonly UseNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperatorAnalyzer Instance = new UseNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperatorAnalyzer();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfKind(SyntaxKind.CoalesceExpression)
                .Where(node =>
                    node.Parent?.IsKind(SyntaxKind.SimpleAssignmentExpression) == true &&
                    node.Parent is AssignmentExpressionSyntax assignment &&
                    assignment.Right == node &&
                    node is BinaryExpressionSyntax coalesceExpressionNode &&
                    assignment.Left != null && coalesceExpressionNode.Left != null &&
                    AssignmentTargetIsSameAsCoalesceOperatorLeftSide(assignment.Left, coalesceExpressionNode.Left) &&
                    // Ignore situations like: X = X ?? throw new Exception().
                    coalesceExpressionNode.Right?.IsKind(SyntaxKind.ThrowExpression) == false &&
                    // Don't offer suggestion if this is `X = X ?? ...` inside an object initializer like e.g. `new SomeClass { X = X ?? ... }`.
                    !assignment.Left.IsObjectInitializerNamedAssignmentIdentifier()
                )
                .Select(coalesceExpressionNode => new AnalysisResult
                (
                    IsSideEffectFree(((AssignmentExpressionSyntax)coalesceExpressionNode.Parent).Left, true)
                        ? (ISharpenSuggestion)UseNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperator.Instance
                        : ConsiderUsingNullCoalescingAssignmentOperatorInsteadOfAssigningResultOfTheNullCoalescingOperator.Instance,
                    analysisContext,
                    syntaxTree.FilePath,
                    coalesceExpressionNode.Parent.GetFirstToken(),
                    coalesceExpressionNode.Parent
                ));
            
            // We are changing the number of times the expression is executed from
            // twice to ones. This is potentially not side-effect-free in certain cases.
            // E.g. when expression looks like `SomeProperty.SomeOtherProperty.AgainSomeOtherProperty`
            // and there is an arbitrary logic running behind each of the properties.
            // Even in a simple case like `SomeProperty = SomeProperty ?? ...`
            // we can have side effects. In the above case, the setter is always called,
            // while `SomeProperty ??= ...` calls the setter only if SomeProperty is null.
            bool IsSideEffectFree(SyntaxNode expression, bool isTopLevel)
            {
                // This algorithm works "backwards". E.g for "this.a.b.c" the check goes
                // from "c" towards "this".

                if (expression == null) return false;

                // Expression basically has to be of the form "a.b.c", where all parts are locals,
                // parameters or fields. Basically, nothing that can cause arbitrary user code
                // execution when being evaluated by the compiler.

                // Referencing this or base like e.g. this.a.b.c causes no side effects itself.
                if (expression.IsThisExpression() || expression.IsBaseExpression())
                    return true;

                if (expression.IsIdentifierName())
                {
                    return IsSideEffectFreeSymbol(expression, isTopLevel);
                }

                if (expression.IsParenthesizedExpression())
                {
                    expression.GetPartsOfParenthesizedExpression(out _, out var parenthesizedExpression, out _);

                    return IsSideEffectFree(parenthesizedExpression, isTopLevel);
                }

                if (expression.IsSimpleMemberAccessExpression())
                {
                    expression.GetPartsOfMemberAccessExpression(out var subExpression, out _, out _);

                    return IsSideEffectFree(subExpression, isTopLevel: false) &&
                           IsSideEffectFreeSymbol(expression, isTopLevel);
                }

                if (expression.IsConditionalAccessExpression())
                {
                    expression.GetPartsOfConditionalAccessExpression(out var accessExpression, out _, out var whenNotNull);

                    return IsSideEffectFree(accessExpression, isTopLevel: false) &&
                           IsSideEffectFree(whenNotNull, isTopLevel: false);
                }

                // Something we don't explicitly handle. Assume this may have side effects.
                return false;

                bool IsSideEffectFreeSymbol(SyntaxNode node, bool isTopLevelNode)
                {
                    var symbolInfo = semanticModel.GetSymbolInfo(node);
                    if (symbolInfo.CandidateSymbols.Length > 0 || symbolInfo.Symbol == null)
                    {
                        // Couldn't bind successfully, assume that this might have side-effects.
                        return false;
                    }

                    var symbol = symbolInfo.Symbol;
                    switch (symbol.Kind)
                    {
                        case SymbolKind.Namespace:
                        case SymbolKind.NamedType:
                        case SymbolKind.Field:
                        case SymbolKind.Parameter:
                        case SymbolKind.Local:
                            return true;
                    }

                    if (symbol.Kind == SymbolKind.Property && isTopLevelNode)
                    {
                        // TODO: Check this. It looks like a bug for ??.
                        //       Will the setter be called?
                        //       What when it is ref-property?

                        // Note, this doesn't apply if the property is a ref-property. In that case, we'd
                        // go from a read and a write to just a read (and a write to it's returned ref
                        // value).
                        var property = (IPropertySymbol)symbol;
                        // TODO: There is no RefKind in this version of Roslyn that we use.
                        //       Investigate how to implement the below line in this version.
                        //       I guess that should be possible with the available RefCustomModifiers and ReturnsByRef.
                        //       So far we wil just ignore it.
                        //if (property.RefKind == RefKind.None)
                        //{
                        //    return true;
                        //}
                    }

                    return false;
                }
            }


            bool AssignmentTargetIsSameAsCoalesceOperatorLeftSide(SyntaxNode assignmentTarget, SyntaxNode coalesceOperatorLeftSide)
            {
                // TODO: Implement symbol and not only text equality. E.g. this.x = x ?? ...
                return SyntaxNodeFacts.AreEquivalent(assignmentTarget, coalesceOperatorLeftSide);
            }
        }
    }
}