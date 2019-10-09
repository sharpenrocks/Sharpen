using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.Extensions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp70.OutVariables
{
    /// <remarks>
    /// The <typeparamref name="TEnclosingExpressionSyntax"/> can be only <see cref="InvocationExpressionSyntax"/> or <see cref="ObjectCreationExpressionSyntax"/>.
    /// Basically, this base class knows its descendants and tailors its implementation for these two possible cases.
    /// Not the best class design practice but in this case fairly simple and useful.
    /// </remarks>
    // TODO-PERF: Reuse the analysis and have only one instead of four per syntax tree.
    //            In the current design we have four different Sharpen suggestions that execute this code.
    //            This means the same code is executed four times per syntax tree although we can already
    //            know in a single pass if any of those four cases happens.
    //            See if we can optimize this. So far it is perfectly fine to have it this way.
    internal abstract class BaseUseOutVariables<TEnclosingExpressionSyntax> : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
        where TEnclosingExpressionSyntax : ExpressionSyntax
    {
        private readonly bool outArgumentCanBeDiscarded;

        protected BaseUseOutVariables(bool outArgumentCanBeDiscarded)
        {
            this.outArgumentCanBeDiscarded = outArgumentCanBeDiscarded;

            FriendlyName = GetFriendlyName();

            string GetFriendlyName()
            {
                if (outArgumentCanBeDiscarded)
                {
                    return typeof(TEnclosingExpressionSyntax) == typeof(InvocationExpressionSyntax)
                        ? "Discard out variables in method invocations"
                        : "Discard out variables in object creations";
                }

                return typeof(TEnclosingExpressionSyntax) == typeof(InvocationExpressionSyntax)
                    ? "Use out variables in method invocations"
                    : "Use out variables in object creations";
            }
        }

        public string MinimumLanguageVersion { get; } = CSharpLanguageVersions.CSharp70;

        public ICSharpFeature LanguageFeature { get; } = CSharpFeatures.OutVariables.Instance;

        public string FriendlyName { get; }

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<ArgumentSyntax>()
                .Where(argument =>
                    argument.RefOrOutKeyword.IsKind(SyntaxKind.OutKeyword) &&
                    argument.Expression.IsKind(SyntaxKind.IdentifierName) &&
                    OutArgumentCanBecomeOutVariableOrCanBeDiscarded(semanticModel, argument, outArgumentCanBeDiscarded)
                )
                .Select(argument => new AnalysisResult
                (
                    this,
                    analysisContext,
                    syntaxTree.FilePath,
                    argument.RefOrOutKeyword,
                    argument.FirstAncestorOrSelf<TEnclosingExpressionSyntax>()
                ));
        }

        private static bool OutArgumentCanBecomeOutVariableOrCanBeDiscarded(SemanticModel semanticModel, ArgumentSyntax outArgument, bool outArgumentCanBeDiscarded)
        {
            var enclosingStatement = outArgument.LastAncestorOrSelf<StatementSyntax>(); // E.g. method body block.
            var outArgumentIdentifier = (IdentifierNameSyntax) outArgument.Expression;
            var outVariableName = outArgumentIdentifier.Identifier.ValueText;

            // 1. The enclosing expression (method/constructor call) must correspond to the TEnclosingExpressionSyntax type.
            var enclosingExpression = GetEnclosingExpression();
            if (enclosingExpression == null) return false;

            // 2. The out argument must be a local variable.
            var variableDeclarator = GetLocalVariableDeclaratorForOutArgument();
            if (variableDeclarator == null) return false;

            // 3. If the local variable is initialized within the declaration, it means that it is used.
            if (variableDeclarator.Initializer != null) return false;


            // 4. The local variable must not be used before it is passed to the method/constructor as an out argument.
            //    Also, if it is a requirement that the out argument can be discarded, it must not be used
            //    anywhere in code after the out argument.

            var localVariableSymbol = semanticModel.GetSymbolInfo(outArgumentIdentifier).Symbol;
            if (localVariableSymbol == null) return false;
            var localVariableTextSpan = variableDeclarator.Identifier.Span;
            var outArgumentTextSpan = outArgumentIdentifier.Span;

            // Find all the usages of the local variable within the enclosing e.g. method body block
            // that are different then its declaration and the usage in the out variable itself.
            // Those usage then appear either between the variable declaration and the out argument
            // or after the out argument.
            var usagesOfTheLocalVariable = enclosingStatement
                .DescendantNodes()
                .OfType<IdentifierNameSyntax>()
                .Where(identifier =>
                    identifier.Identifier.ValueText == outVariableName &&
                    identifier.Span != localVariableTextSpan && // It is not the declaration of the local variable itself.
                    identifier != outArgumentIdentifier && // It is not the out argument itself.
                    semanticModel.GetSymbolInfo(identifier).Symbol?.Equals(localVariableSymbol) == true
                )
                .ToList();

            var(numberOfUsagesBeforeOutArgument, numberOfUsagesAfterOutArgument) = usagesOfTheLocalVariable
                .CountMany
                (
                    identifier => identifier.Identifier.Span.IsBetween(localVariableTextSpan, outArgumentTextSpan),
                    identifier => identifier.Identifier.Span.IsAfter(outArgumentTextSpan)
                );

            var localVariableCouldBecomeOutVariableOrDiscarded =
                    numberOfUsagesBeforeOutArgument == 0 &&
                    (
                        outArgumentCanBeDiscarded && numberOfUsagesAfterOutArgument == 0
                        ||
                        !outArgumentCanBeDiscarded && numberOfUsagesAfterOutArgument > 0
                    );

            if (!localVariableCouldBecomeOutVariableOrDiscarded) return false;

            // 5. If turned into out variable, the local variable identifier still has the
            //    scope that contains all of the usages of that identifier that originally
            //    appear in the code after the out variable declaration.

            // If it can be discarded there is no usages after the out argument.
            // Thus, there cannot be any issues with the scope.
            if (outArgumentCanBeDiscarded && numberOfUsagesAfterOutArgument == 0)
                return true;

            var outVariableScope = GetOutVariableScope();
            // If we have reached here, all the usages of the local variable are actually
            // after the out argument. We have to check that they are all in the scope
            // of the out variable.
            return usagesOfTheLocalVariable
                .All(identifier => outVariableScope.IsAnyAncestorOfOrSelf(identifier, enclosingStatement.Parent));

            // The enclosing expression can be only a method or constructor call.
            // We have to additionally check for the case where we have them nested ;-)
            ExpressionSyntax GetEnclosingExpression()
            {
                var result = outArgument.FirstAncestorOrSelf<TEnclosingExpressionSyntax>();
                if (result == null) return null;

                // Check the possibly nested calls. E.g. Method(out j, new Constructor(out i));
                var potentialOtherEnclosingExpression = typeof(TEnclosingExpressionSyntax) == typeof(InvocationExpressionSyntax)
                                                        ? (ExpressionSyntax)outArgument.FirstAncestorOrSelf<ObjectCreationExpressionSyntax>()
                                                        : outArgument.FirstAncestorOrSelf<InvocationExpressionSyntax>();
                
                if (potentialOtherEnclosingExpression == null)
                {
                    // No nesting, just return the result.
                    return result;
                }

                // Nesting. Check that the invocation of the type TEnclosingExpressionSyntax comes first.
                return potentialOtherEnclosingExpression.IsAncestorOfOrSelf(result, enclosingStatement)
                    ? result
                    : null;
            }

            // Why an array here and not a single StatementSyntax node?
            // We have rare cases like e.g. for loop incrementors
            // where we do not have a single syntax node that would enclose
            // the scope but rather a list of mutually "disconnected" nodes.
            SyntaxNode[] GetOutVariableScope()
            {
                var potentialIfStatement = GetPotentialEnclosingIfStatement();
                if (potentialIfStatement != null) return new SyntaxNode[] { potentialIfStatement.FirstAncestorOrSelf<BlockSyntax>() };

                var potentialSwitchStatement = GetPotentialEnclosingSwitchStatement();
                if (potentialSwitchStatement != null) return new SyntaxNode[] { potentialSwitchStatement.FirstAncestorOrSelf<BlockSyntax>() };

                var potentialSwitchSection = GetPotentialEnclosingSwitchSection();
                if (potentialSwitchSection != null) return new SyntaxNode[] { (SwitchStatementSyntax)potentialSwitchSection.Parent };

                var potentialWhileStatement = GetPotentialEnclosingWhileStatement();
                if (potentialWhileStatement != null) return new SyntaxNode[] { potentialWhileStatement };

                // If the method/constructor invocation is within the while part of
                // a do-while statement the declared variable will not be visible anywhere
                // else but within that while part. Also, if we are checking that that method/constructor
                // invocation as a candidate to have an out variable, we know already that the
                // out variable is not used anywhere else in the do-while body.
                // In other words, the returned do-while statement will not contain any access
                // to the local variable that we want to turn into out variable.
                // Also, if the out variable is declared in the while part of the do-while loop,
                // it will not be visible after the while loop.
                // In other words, its new scope will be just the while part which is effectively
                // a kind of a "empty" scope.
                // Also, we ignore the usages like Method(out x, out x);
                var potentialDoStatement = GetPotentialEnclosingDoStatement();
                if (potentialDoStatement != null) return new SyntaxNode[0];

                var potentialForStatement = GetPotentialEnclosingForStatement();
                if (potentialForStatement != null) return new SyntaxNode[] { potentialForStatement };

                var potentialForIncrementors = GetPotentialEnclosingForIncrementors();
                if (potentialForIncrementors != default) return potentialForIncrementors.Cast<SyntaxNode>().ToArray();

                var potentialForEachStatement = GetPotentialEnclosingForEachStatement();
                if (potentialForEachStatement != null) return new SyntaxNode[] { potentialForEachStatement };

                var potentialAnonymousFunction = GetPotentialEnclosingAnonymousFunction();
                if (potentialAnonymousFunction != null) return new SyntaxNode[] { potentialAnonymousFunction.Body };

                // If it is nothing of the above, the method/constructor is called within some
                // "regular" block.
                return new SyntaxNode[] { enclosingExpression.FirstAncestorOrSelf<BlockSyntax>() };

                AnonymousFunctionExpressionSyntax GetPotentialEnclosingAnonymousFunction()
                {
                    var anonymousFunction = enclosingExpression.FirstAncestorOrSelf<AnonymousFunctionExpressionSyntax>();
                    if (anonymousFunction == null) return null;

                    // Method/constructor invocation is within an anonymous delegate or lambda expression.
                    // But we have to make sure that it is not within a separate block within that
                    // anonymous delegate or lambda expression.
                    var block = enclosingExpression.FirstAncestorOrSelf<BlockSyntax>();

                    // Why enclosingStatement.Parent?
                    // Anonymous functions in general do not have to have a block.
                    // So the above search for the first enclosing block could return
                    // the enclosingStatement itself.
                    // So in general case we have to step one step out of it.
                    return anonymousFunction.IsAncestorOfOrSelf(block, enclosingStatement.Parent)
                        ? null
                        : anonymousFunction;
                }

                ForEachStatementSyntax GetPotentialEnclosingForEachStatement()
                {
                    var forEachStatement = enclosingExpression.FirstAncestorOrSelf<ForEachStatementSyntax>();
                    if (forEachStatement == null) return null;

                    return forEachStatement.Expression.IsAncestorOfOrSelf(enclosingExpression, forEachStatement)
                        ? forEachStatement
                        : null;
                }

                SeparatedSyntaxList<ExpressionSyntax> GetPotentialEnclosingForIncrementors()
                {
                    // Is the method/constructor invocation a part of incrementors of a for loop?
                    var forStatement = enclosingExpression.FirstAncestorOrSelf<ForStatementSyntax>();
                    if (forStatement == null) return default;
                    
                    if (forStatement.Incrementors != default && forStatement.Incrementors.IsAnyAncestorOfOrSelf(enclosingExpression, forStatement))
                        return forStatement.Incrementors;

                    return default;
                }

                ForStatementSyntax GetPotentialEnclosingForStatement()
                {
                    // Is the method/constructor invocation a part of the declaration/initializers or condition
                    // of a for loop?
                    var forStatement = enclosingExpression.FirstAncestorOrSelf<ForStatementSyntax>();
                    if (forStatement == null) return null;

                    if (forStatement.Condition != null && forStatement.Condition.IsAncestorOfOrSelf(enclosingExpression, forStatement))
                        return forStatement;

                    if (forStatement.Declaration != null && forStatement.Declaration.IsAncestorOfOrSelf(enclosingExpression, forStatement))
                        return forStatement;

                    return null;
                }

                DoStatementSyntax GetPotentialEnclosingDoStatement()
                {
                    var doStatement = enclosingExpression.FirstAncestorOrSelf<DoStatementSyntax>();
                    if (doStatement == null) return null;

                    return doStatement.Condition.IsAncestorOfOrSelf(enclosingExpression, doStatement)
                        ? doStatement
                        : null;
                }

                WhileStatementSyntax GetPotentialEnclosingWhileStatement()
                {
                    var whileStatement = enclosingExpression.FirstAncestorOrSelf<WhileStatementSyntax>();
                    if (whileStatement == null) return null;
                    
                    return whileStatement.Condition.IsAncestorOfOrSelf(enclosingExpression, whileStatement)
                        ? whileStatement
                        : null;
                }

                SwitchSectionSyntax GetPotentialEnclosingSwitchSection()
                {
                    var switchSection = enclosingExpression.FirstAncestorOrSelf<SwitchSectionSyntax>();
                    if (switchSection == null) return null;

                    // Method/constructor invocation is within a switch section.
                    // But we have to make sure that it is not within a block within that
                    // switch section.
                    var block = enclosingExpression.FirstAncestorOrSelf<BlockSyntax>();

                    // Why enclosingStatement.Parent?
                    // The switch statement does not have a block. So the above search for the
                    // first enclosing block could return the enclosingStatement itself.
                    // So in general case we have to step one step out of it.
                    return switchSection.IsAncestorOfOrSelf(block, enclosingStatement.Parent)
                        ? null
                        : switchSection;
                }

                SwitchStatementSyntax GetPotentialEnclosingSwitchStatement()
                {
                    var switchStatement = enclosingExpression.FirstAncestorOrSelf<SwitchStatementSyntax>();
                    if (switchStatement == null) return null;

                    return switchStatement.Expression.IsAncestorOfOrSelf(enclosingExpression, switchStatement)
                        ? switchStatement
                        : null;
                }

                IfStatementSyntax GetPotentialEnclosingIfStatement()
                {
                    var ifStatement = enclosingExpression.FirstAncestorOrSelf<IfStatementSyntax>();
                    if (ifStatement == null) return null;

                    return ifStatement.Condition.IsAncestorOfOrSelf(enclosingExpression, ifStatement)
                        ? ifStatement
                        : null;
                }
            }

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