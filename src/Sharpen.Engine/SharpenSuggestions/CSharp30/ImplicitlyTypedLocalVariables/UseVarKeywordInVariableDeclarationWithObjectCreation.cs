using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using System.Collections.Generic;
using System.Linq;

namespace Sharpen.Engine.SharpenSuggestions.CSharp30.ImplicitlyTypedLocalVariables
{
    internal sealed class UseVarKeywordInVariableDeclarationWithObjectCreation : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        public string MinimumLanguageVersion => CSharpLanguageVersions.CSharp30;

        public ICSharpFeature LanguageFeature => CSharpFeatures.ImplicitlyTypedLocalVariables.Instance;

        public string FriendlyName => "Use var keyword in variable declaration with object creation";


        public static readonly UseVarKeywordInVariableDeclarationWithObjectCreation Instance = new UseVarKeywordInVariableDeclarationWithObjectCreation();


        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<VariableDeclarationSyntax>()
                .Where(VarShouldBeUsed)
                .Select(declaration => new AnalysisResult
                (
                   this,
                   analysisContext,
                   syntaxTree.FilePath,
                   declaration.GetFirstToken(),
                   declaration
                ));

            bool VarShouldBeUsed(VariableDeclarationSyntax declaration)
            {
                var leftHandSideType = semanticModel.GetTypeInfo(declaration.ChildNodes()?
                                    .FirstOrDefault(syntax => 
                                        syntax is PredefinedTypeSyntax 
                                        || syntax is GenericNameSyntax 
                                        || syntax is QualifiedNameSyntax 
                                        || syntax is IdentifierNameSyntax)).Type;

                int totalDeclarationsInLine = declaration.DescendantNodes().Count(x => x is VariableDeclaratorSyntax);
                var rightHandSideType = totalDeclarationsInLine > 1 ? null : 
                    semanticModel.GetTypeInfo(
                        declaration.DescendantNodes()
                        .FirstOrDefault(node => 
                        node is ObjectCreationExpressionSyntax).ChildNodes()?
                            .FirstOrDefault( syntax =>
                            syntax is QualifiedNameSyntax 
                            || syntax is GenericNameSyntax 
                            || syntax is PredefinedTypeSyntax 
                            || syntax is IdentifierNameSyntax
                          ).Parent
                    ).Type;

                return (leftHandSideType != null && rightHandSideType != null) && (leftHandSideType.Equals(rightHandSideType));
            }
        }
    }
}