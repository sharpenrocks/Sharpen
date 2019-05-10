using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.Extensions;
using Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Suggestions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp80.NullableReferenceTypes.Analyzers
{
    internal sealed class EnableNullableContextAndDeclareReferenceIdentifierAsNullableAnalyzer : ISingleSyntaxTreeAnalyzer
    {
        private EnableNullableContextAndDeclareReferenceIdentifierAsNullableAnalyzer() { }

        public static readonly EnableNullableContextAndDeclareReferenceIdentifierAsNullableAnalyzer Instance = new EnableNullableContextAndDeclareReferenceIdentifierAsNullableAnalyzer();

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            // TODO: What to do when a variable is declared by using the var keyword?
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .Where(node => node.IsAnyOfKinds
                (
                    // TODO: Parameter declaration with null as default value: string parameter = null.
                    // TODO: Variable declaration with initialization to null: string variable = null.
                    // TODO: Field declaration with initialization to null: private string _field = null.
                    // TODO: Property declaration with initialization to null: public string Property { get; } = null.
                    // TODO: Usage of ??: x = identifier ?? something.
                    // TODO: Usage of ?.: identifier?.Something.
                    // TODO: Usage of as: identifier = something as Something.
                    SyntaxKind.SimpleAssignmentExpression, 
                    SyntaxKind.EqualsExpression,
                    SyntaxKind.NotEqualsExpression
                ))
                .Select(GetNullableIdentifierNode)
                .Where(identifier => identifier != null)
                .Select(identifier => semanticModel.GetSymbolInfo(identifier).Symbol)
                .Where(symbol => symbol?.IsImplicitlyDeclared == false)
                .Distinct()
                .Select(symbol => (symbol, declaringNode: GetSymbolDeclaringNode(symbol)))
                .Where(symbolAndDeclaringNode => !string.IsNullOrEmpty(symbolAndDeclaringNode.declaringNode?.SyntaxTree?.FilePath))
                .Select(symbolAndDeclaringNode =>
                {
                    var (startingToken, displayTextNode) = GetStartingTokenAndDisplayTextNode(symbolAndDeclaringNode.declaringNode);
                    
                    return new AnalysisResult
                    (
                        GetSuggestion(symbolAndDeclaringNode.symbol),
                        analysisContext,
                        symbolAndDeclaringNode.declaringNode.SyntaxTree.FilePath,
                        startingToken,
                        displayTextNode 
                    );
                });

            (SyntaxToken startingToken, SyntaxNode displayTextNode) GetStartingTokenAndDisplayTextNode(SyntaxNode symbolDeclaringNode)
            {
                return (symbolDeclaringNode.GetFirstToken(), symbolDeclaringNode);
            }

            ISharpenSuggestion GetSuggestion(ISymbol symbol)
            {
                switch (symbol)
                {
                    case IFieldSymbol _: return EnableNullableContextAndDeclareReferenceFieldAsNullable.Instance;
                    case IPropertySymbol _: return EnableNullableContextAndDeclareReferencePropertyAsNullable.Instance;
                    case IParameterSymbol _: return EnableNullableContextAndDeclareReferenceParameterAsNullable.Instance;
                    case ILocalSymbol _: return EnableNullableContextAndDeclareReferenceVariableAsNullable.Instance;
                    // TODO: The default case should never happen. See what to return.
                    default: return EnableNullableContextAndDeclareReferenceFieldAsNullable.Instance; 
                }
            }

            SyntaxNode GetSymbolDeclaringNode(ISymbol symbol)
            {
                return symbol.DeclaringSyntaxReferences.Length != 1 
                    ? null
                    : symbol.DeclaringSyntaxReferences[0].GetSyntax();
            }

            SyntaxNode GetNullableIdentifierNode(SyntaxNode node)
            {
                // TODO: Ignore the case where the comparison with null is actually a null guard.
                //       E.g.: if (identifier == null) throw ArgumentNullException(...);
                //       E.g.: identifier ?? throw ArgumentNullException(...);
                // TODO: If the "value" in the property setter is checked for null
                //       we could assume that the property is nullable. Think about it.
                switch (node)
                {
                    case AssignmentExpressionSyntax assignment:
                        return assignment.Right?.IsKind(SyntaxKind.NullLiteralExpression) == true &&
                               assignment.Left?.IsAnyOfKinds(SyntaxKind.IdentifierName, SyntaxKind.SimpleMemberAccessExpression) == true
                            ? assignment.Left
                            : null;

                    case BinaryExpressionSyntax comparison:
                        return comparison.Right?.IsKind(SyntaxKind.NullLiteralExpression) == true &&
                               comparison.Left?.IsAnyOfKinds(SyntaxKind.IdentifierName, SyntaxKind.SimpleMemberAccessExpression) == true
                            ? comparison.Left
                            : null;

                    default: return null;
                }
            }
        }
    }
}