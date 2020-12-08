using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Sharpen.Engine.Extensions;

namespace Sharpen.Engine.SharpenSuggestions.CSharp30.ImplicitlyTypedLocalVariables
{
    internal sealed class UseVarKeywordInVariableDeclarationWithObjectCreation : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        public string MinimumLanguageVersion => CSharpLanguageVersions.CSharp30;

        public ICSharpFeature LanguageFeature => CSharpFeatures.ImplicitlyTypedLocalVariables.Instance;

        public string FriendlyName => "Use var keyword in variable declaration with object creation";

        public SharpenSuggestionType SuggestionType { get; } = SharpenSuggestionType.Recommendation;

        public static readonly UseVarKeywordInVariableDeclarationWithObjectCreation Instance = new UseVarKeywordInVariableDeclarationWithObjectCreation();


        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<VariableDeclarationSyntax>()
                .Where(declaration =>
                    declaration.Parent?.IsAnyOfKinds(SyntaxKind.LocalDeclarationStatement, SyntaxKind.UsingStatement) == true
                    && 
                    DeclarationDoesNotUseVarKeyword(declaration)
                    &&
                    DeclarationDeclaresExactlyOneVariable(declaration)
                    &&
                    InitializationContainsOnlyObjectCreation(declaration)
                    &&
                    LeftSideTypeIsExactlyTheSameAsRightSideType(declaration)
                    // TODO-IG: Check that there is no type named var declared in the scope.
                    // TODO-IG: Check that there is now generic parameter named var in the scope.
                )
                .Select(declaration => new AnalysisResult
                (
                   this,
                   analysisContext,
                   syntaxTree.FilePath,
                   declaration.GetFirstToken(),
                   declaration
                ));

            bool DeclarationDoesNotUseVarKeyword(VariableDeclarationSyntax declaration)
            {
                return declaration.Type?.IsVar == false;
            }

            bool DeclarationDeclaresExactlyOneVariable(VariableDeclarationSyntax declaration)
            {
                return declaration.Variables.Count == 1;
            }

            bool InitializationContainsOnlyObjectCreation(VariableDeclarationSyntax declaration)
            {
                return declaration.Variables[0]
                           .Initializer?.Value?.IsKind(SyntaxKind.ObjectCreationExpression) == true;
            }

            bool LeftSideTypeIsExactlyTheSameAsRightSideType(VariableDeclarationSyntax declaration)
            {
                var leftSideType = semanticModel.GetTypeInfo(declaration.Type).Type;
                if (leftSideType == null || leftSideType is IErrorTypeSymbol) return false;

                var objectCreationExpression = (ObjectCreationExpressionSyntax)declaration.Variables[0].Initializer.Value;
                var rightSideType = semanticModel.GetTypeInfo(objectCreationExpression).Type;
                if (rightSideType == null || rightSideType is IErrorTypeSymbol) return false;

                return leftSideType.Equals(rightSideType);
            }
        }
    }
}