using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.Extensions;
using Sharpen.Engine.Extensions.CodeDetection;
using Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Analyzers
{
    // TODO-IG: This is the first analyzer that is actually not an ISingleSyntaxTreeAnalyzer.
    //          We finally have a reason to refactor the whole Analyzer/Scope/Context/Result/etc. stuff. :-)
    //          So far we will leave it like this with a workaround for filtering the duplicates.
    //          The current priority is to get v0.9.0 finally released.
    //          Topics to solve:
    //              - tree analyzers that have results other syntax trees
    //              - multiple results (duplicates, same suggestion reported few times)
    //              - showing only results in the original scope not those out of it
    //              - how to treat the lined files that could appear in several project (at the moment one suggestion per project which makes sense)
    internal sealed class EnableNullableContextAndDeclareIdentifierAsNullableAnalyzer : ISingleSyntaxTreeAnalyzer
    {
        private EnableNullableContextAndDeclareIdentifierAsNullableAnalyzer() { }

        public static readonly EnableNullableContextAndDeclareIdentifierAsNullableAnalyzer Instance = new EnableNullableContextAndDeclareIdentifierAsNullableAnalyzer();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            // TODO: At the moment, if an identifier is used in different syntaxTrees
            //       (very very very likely :-)) it will be reported several times in
            //       the result, once per syntax tree. So far we can live with that.
            //       Implement proper removal of duplicates.

            // TODO: What to do when a variable is declared by using the var keyword?
            //       At the moment we will simply pretend that the feature is there.
            //       It is planned and will be implemented one day.
            return syntaxTree.GetRoot()
                .DescendantNodes()
                // TODO: Parameter declaration with null as default value: string parameter = null.
                // TODO: Variable declaration with initialization to null: string variable = null.
                // TODO: Property declaration with initialization to null: public string Property { get; } = null.
                // TODO: Property and field initializers in constructors e.g. new X { Property = null, field = null }.
                // TODO: Property getters with return null;
                // TODO: What about indexers?
                .OfAnyOfKinds
                (
                    SyntaxKind.SimpleAssignmentExpression, // identifier = null;
                    SyntaxKind.EqualsExpression, // identifier == null;
                    SyntaxKind.NotEqualsExpression, // identifier != null
                    SyntaxKind.VariableDeclarator, // object _fieldIdentifier = null; object localVariableIdentifier = null;
                    SyntaxKind.ConditionalAccessExpression, // identifier?.Something;
                    SyntaxKind.CoalesceExpression // identifier ?? something;
                )
                .Select(GetNullableIdentifierSymbol)
                .Where(symbol => symbol?.IsImplicitlyDeclared == false)
                .Distinct()
                .Select(symbol => (symbol, declaringNode: GetSymbolDeclaringNode(symbol)))
                .Where(NullableContextCanBeEnabledForIdentifier)
                .Select(GetAnalysisResultInfo)
                .Where(analysisResultInfo => analysisResultInfo.suggestion != null)
                .Select(analysisResultInfo => new AnalysisResult
                (
                    analysisResultInfo.suggestion,
                    // TODO-IG: This is actually wrong, a bug to be completely honest.
                    //          In a usual case, the project in which the filePath
                    //          really is, is different then the project in which
                    //          the currently analyzed syntax tree resides.
                    //          Which means that the information in the analysisContext
                    //          does not fit to filePath.
                    //          Luckily the consequences are not so tragical, the
                    //          whole path to the file will be wrong.
                    //          The file will be misplaced, essentially the file name
                    //          of the filePath will be placed with the LogicalFolderPath
                    //          of the analysisContext.
                    //          Know bug, let's leave it so far, we have more urgent things
                    //          to do in order to have a reasonable release before the
                    //          talk in Bangalore.
                    analysisContext,
                    analysisResultInfo.filePath,
                    analysisResultInfo.startingToken,
                    analysisResultInfo.displayTextNode 
                ));

            bool NullableContextCanBeEnabledForIdentifier((ISymbol symbol, SyntaxNode declaringNode) symbolAndDeclaringNode)
            {
                var (symbol, declaringNode) = symbolAndDeclaringNode;
                var filePath = declaringNode?.SyntaxTree?.FilePath;

                if (string.IsNullOrEmpty(filePath))
                    return false;

                // We skip the check for IsGeneratedAssemblyInfo() so far.
                // To get the Document object at this point requires
                // a bit of refactoring. Plus, the chance that the declaring
                // node be in the generated AssemblyInfo is zero.
                // TODO-IG: Think of adding the check later.
                if (GeneratedCodeDetection.IsGeneratedFile(filePath) ||
                    declaringNode.SyntaxTree.BeginsWithAutoGeneratedComment())
                    return false;

                // If the nullable context is already enabled we do not
                // want to show the suggestion. In that case the compiler
                // will provide the appropriate warnings.
                // The main idea behind this suggestion is to motive
                // programmers to enable nullable context and start using
                // nullable reference types!
                if (NullableContextIsAlreadyEnabled())
                    return false;

                var typeSymbol = GetTypeSymbol();
                // WARNING: A bit paranoid but still. Never remove this check because
                //          the GetSuggestion() later on assumes that the type symbol exists.
                if (typeSymbol == null) return false;

                // For this, we want to have a special suggestion
                // that suggest to mark the type parameter as nullable.
                // So far, just ignore this case.
                // TODO-IG: Implement suggestion for marking unconstrained type parameters as nullable.
                if (typeSymbol.IsUnconstrainedTypeParameter())
                    return false;

                if (IdentifierIsAlreadyNullable())
                    return false;

                return true;

                bool IdentifierIsAlreadyNullable()
                {
                    // This is VS2017 implementation.
                    // If the identifier is value type and is
                    // surely nullable it can only by Nullable<T> (T?).
                    // So, it is already nullable if it is a
                    // value type.
                    // TODO-IG: Solve how to approach to support for VS2017 and VS2019
                    //          at the same time and implement properly the VS2019
                    //          version of this logic.
                    //          Also, add the negative-case smoke tests to the
                    //          CSharp80.VS2019.csproj.
                    //          In VS2019 (means C# 8.0) we have nullable reference types ;-)
                    return typeSymbol.IsValueType;
                }

                ITypeSymbol GetTypeSymbol()
                {
                    switch (symbol)
                    {
                        case IFieldSymbol fieldSymbol: return fieldSymbol.Type;
                        case IPropertySymbol propertySymbol: return propertySymbol.Type;
                        case IParameterSymbol parameterSymbol: return parameterSymbol.Type;
                        case ILocalSymbol localSymbol: return localSymbol.Type;
                        default: return null;
                    }
                }

                bool NullableContextIsAlreadyEnabled()
                {
                    // TODO-IG: This is the implementation for VS2017.
                    //          Solve how to approach to support for VS2017 and VS2019
                    //          at the same time and implement properly the VS2019
                    //          version of this method.
                    //          Also, add the negative-case smoke tests to the
                    //          CSharp80.VS2019.csproj.
                    return false;
                }
            }

            (ISharpenSuggestion suggestion,
            string filePath,
            SyntaxToken startingToken,
            SyntaxNode displayTextNode) GetAnalysisResultInfo((ISymbol symbol, SyntaxNode declaringNode) symbolAndDeclaringNode)
            {
                return
                (
                    GetSuggestion(symbolAndDeclaringNode.symbol),
                    symbolAndDeclaringNode.declaringNode.SyntaxTree.FilePath,
                    GetStartingToken(symbolAndDeclaringNode.declaringNode),
                    symbolAndDeclaringNode.declaringNode
                );
            }

            SyntaxToken GetStartingToken(SyntaxNode declaringNode)
            {
                // If we have more then one variable declared in the
                // declaration, we want to position the cursor to that variable.
                if (declaringNode.IsKind(SyntaxKind.VariableDeclarator) && // To avoid expensive type based checks.
                    declaringNode is VariableDeclaratorSyntax variableDeclarator &&
                    variableDeclarator.Parent is VariableDeclarationSyntax variableDeclaration &&
                    variableDeclaration.Variables.Count != 1)
                    return variableDeclarator.Identifier;

                // In general, we would like to position the cursor
                // to the type part of the declaration, because that's
                // what should be changed in code (by adding ?).
                // But to identify it in general case is a bit tricky,
                // and case by case implementation is time consuming.
                // Therefore at the moment we will just position to the
                // beginning of the declaration.
                // TODO-IG: Position to type part of the declaration.
                return declaringNode.GetFirstToken();                  
            }

            ISharpenSuggestion GetSuggestion(ISymbol symbol)
            {
                // TODO-IG: Just ignoring structs so far. That's why the IsReferenceType checks.
                //          Structs are rarely used compared to classes, so not that much of an issue at the moment.
                //          Still, see what to do with structs.

                // The type surely exists at this point on all the symbols.
                switch (symbol)
                {
                    case IFieldSymbol fieldSymbol:
                        if (fieldSymbol.Type.IsReferenceType)
                            return EnableNullableContextAndDeclareFieldAsNullable.Instance;
                        return null;

                    case IPropertySymbol propertySymbol:
                        if (propertySymbol.Type.IsReferenceType)
                                return EnableNullableContextAndDeclarePropertyAsNullable.Instance;
                        // TODO-IG: See what to do with interfaces. We will need some special handling
                        //          in order to get more realistic suggestions.
                        return null;

                    case IParameterSymbol _:
                        // TODO-IG: Ignoring parameters until we implement the logic for null guards.
                        //          At the moment it is more important to get v0.9.0 out then to
                        //          have support for the parameters.
                        return null;

                    case ILocalSymbol _: return EnableNullableContextAndDeclareLocalVariableAsNullable.Instance;

                    default: return null; 
                }
            }

            SyntaxNode GetSymbolDeclaringNode(ISymbol symbol)
            {
                return symbol.DeclaringSyntaxReferences.Length != 1 
                    ? null
                    : symbol.DeclaringSyntaxReferences[0].GetSyntax();
            }

            ISymbol GetNullableIdentifierSymbol(SyntaxNode node)
            {
                // TODO: Ignore the case where the comparison with null is actually a null guard.
                //       E.g.: if (identifier == null) throw ArgumentNullException(...);
                //       E.g.: identifier ?? throw ArgumentNullException(...);
                // TODO: If the "value" in the property setter is checked for null
                //       we could assume that the property is nullable. Think about it.
                switch (node)
                {
                    case AssignmentExpressionSyntax assignment:
                        return IsSurelyNullable(assignment.Right) &&
                               IsIdentifierOrPropertyAccess(assignment.Left)
                            ? semanticModel.GetSymbolInfo(assignment.Left).Symbol
                            : null;

                    case BinaryExpressionSyntax binaryExpression:
                        switch (binaryExpression.Kind())
                        {
                            case SyntaxKind.EqualsExpression:
                            case SyntaxKind.NotEqualsExpression:
                                if (IsSurelyNullable(binaryExpression.Right) &&
                                    IsIdentifierOrPropertyAccess(binaryExpression.Left))
                                    return semanticModel.GetSymbolInfo(binaryExpression.Left).Symbol;
                                if (IsSurelyNullable(binaryExpression.Left) &&
                                    IsIdentifierOrPropertyAccess(binaryExpression.Right))
                                    return semanticModel.GetSymbolInfo(binaryExpression.Right).Symbol;
                                return null;
                            case SyntaxKind.CoalesceExpression:
                                return IsIdentifierOrPropertyAccess(binaryExpression.Left)
                                    ? semanticModel.GetSymbolInfo(binaryExpression.Left).Symbol
                                    : null;
                            default: return null;
                        }

                    case VariableDeclaratorSyntax variableDeclarator:
                        return IsSurelyNullable(variableDeclarator.Initializer?.Value) &&
                               variableDeclarator.Identifier.IsKind(SyntaxKind.IdentifierToken)
                            ? semanticModel.GetDeclaredSymbol(variableDeclarator)
                            : null;

                    case ConditionalAccessExpressionSyntax conditionalAccess:
                        return IsIdentifierOrPropertyAccess(conditionalAccess.Expression)
                            ? semanticModel.GetSymbolInfo(conditionalAccess.Expression).Symbol
                            : null;

                    default: return null;
                }

                bool IsSurelyNullable(SyntaxNode potentiallyNullableNode)
                {
                    // We do not do any data flow analysis here, of course :-)
                    // Just identifying the obvious cases.

                    return potentiallyNullableNode?.IsKind(SyntaxKind.NullLiteralExpression) == true
                           ||
                           potentiallyNullableNode?.IsKind(SyntaxKind.AsExpression) == true;
                }

                bool IsIdentifierOrPropertyAccess(SyntaxNode syntaxNode)
                {
                    return syntaxNode?.IsAnyOfKinds(SyntaxKind.IdentifierName, SyntaxKind.SimpleMemberAccessExpression) == true;
                }
            }
        }
    }
}