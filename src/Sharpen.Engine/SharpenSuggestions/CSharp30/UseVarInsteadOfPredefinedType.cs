using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Sharpen.Engine.SharpenSuggestions.CSharp30
{
    class UseVarInsteadOfPredefinedType : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        public string MinimumLanguageVersion => CSharpLanguageVersions.CSharp30;

        public ICSharpFeature LanguageFeature => CSharpFeatures.ImplicitlyTypedLocalVaraiables.Instance;

        public string FriendlyName => "Use var keyword in variable declaration with object creation";

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            var analysisResult = new List<AnalysisResult>();

            var variableDeclarations = syntaxTree.GetRoot().DescendantNodes()
                            .OfType<VariableDeclarationSyntax>().ToList();

            foreach (var declaration in variableDeclarations)
            {

                var LHSType = GetLeftSideCLRType(declaration)?.ToLower();
                var RHSType = GetRightSideCLRType(declaration)?.ToLower();

                if ((LHSType != null && RHSType != null) && (RHSType.Contains(LHSType) || LHSType.Contains(RHSType)))
                {
                    analysisResult.Add(new AnalysisResult(
                            this,
                            analysisContext,
                            syntaxTree.FilePath,
                            declaration.GetFirstToken(),
                            declaration));
                }
            }
            return analysisResult;
        }

       
        public static readonly UseVarInsteadOfPredefinedType Instance = new UseVarInsteadOfPredefinedType();


      

        private string GetRightSideCLRType(VariableDeclarationSyntax declaration)
        {
            int totalDeclarationsInLine =  declaration.DescendantNodes().Count(x => x is VariableDeclaratorSyntax);

            if(totalDeclarationsInLine > 1)
            {
                return null;
            }

            return declaration.DescendantNodes().FirstOrDefault(x => x is ObjectCreationExpressionSyntax).ChildNodes()?
                                       .FirstOrDefault(x => x is QualifiedNameSyntax || x is GenericNameSyntax || x is PredefinedTypeSyntax || x is IdentifierNameSyntax)?
                                       .DescendantTokens()?.Select(x => x.ValueText)?
                                       .Aggregate((i,j) => i + j);

            


        }

        private string GetLeftSideCLRType(VariableDeclarationSyntax declaration)
        {
            return declaration.ChildNodes()?
                .FirstOrDefault(x => x is PredefinedTypeSyntax || x is GenericNameSyntax || x is QualifiedNameSyntax || x is IdentifierNameSyntax)?
                .DescendantTokens()?.Select(x => x.ValueText)?
                .Aggregate((i, j) => i + j);
        }
    }




   
}