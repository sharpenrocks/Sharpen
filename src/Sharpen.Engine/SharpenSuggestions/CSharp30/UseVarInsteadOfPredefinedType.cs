using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using System.Collections.Generic;
using System.Linq;

namespace Sharpen.Engine.SharpenSuggestions.CSharp30
{
    class UseVarInsteadOfPredefinedType : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        public string MinimumLanguageVersion => CSharpLanguageVersions.CSharp30;

        public ICSharpFeature LanguageFeature => CSharpFeatures.ImplicitlyTypedLocalVaraiables.Instance;

        public string FriendlyName => "Use var keyword in variable declaration with object creation";


        public static readonly UseVarInsteadOfPredefinedType Instance = new UseVarInsteadOfPredefinedType();


        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {

            bool shouldVarBeUsed(VariableDeclarationSyntax declaration)
            {
                var LHSType = semanticModel.GetTypeInfo(declaration.ChildNodes()?
                                    .FirstOrDefault(syntax =>
                                        syntax is PredefinedTypeSyntax
                                        || syntax is GenericNameSyntax
                                        || syntax is QualifiedNameSyntax
                                        || syntax is IdentifierNameSyntax)).Type;

                int totalDeclarationsInLine = declaration.DescendantNodes().Count(x => x is VariableDeclaratorSyntax);
                var RHSType = totalDeclarationsInLine > 1 ? null :
                    GetRHSType(declaration, semanticModel);


                return (LHSType != null && RHSType != null) && (LHSType.Equals(RHSType));

            }

            return syntaxTree.GetRoot().DescendantNodes().OfType<VariableDeclarationSyntax>()
                .Where(shouldVarBeUsed)
                .Select(declaration => new AnalysisResult(
                                           this,
                                           analysisContext,
                                           syntaxTree.FilePath,
                                           declaration.GetFirstToken(),
                                           declaration));

        }

        private ITypeSymbol GetRHSType(VariableDeclarationSyntax declaration, SemanticModel semanticModel)
        {
            var objectCreationNodes = declaration.DescendantNodes().FirstOrDefault(
                                        node => node is ObjectCreationExpressionSyntax
                                    );
           return  objectCreationNodes == null ? null :
                                   semanticModel.GetTypeInfo( objectCreationNodes?.ChildNodes()?
                                        .FirstOrDefault(
                                            syntax =>
                                            syntax is QualifiedNameSyntax
                                            || syntax is GenericNameSyntax
                                            || syntax is PredefinedTypeSyntax
                                            || syntax is IdentifierNameSyntax
                                      ).Parent).Type;
        }
    }

}