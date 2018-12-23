using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sharpen.Engine.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharpen.Engine.SharpenSuggestions.CSharp30
{
    class UseVarInsteadOfPredefinedType : ISharpenSuggestion, ISingleSyntaxTreeAnalyzer
    {
        public string MinimumLanguageVersion => CSharpLanguageVersions.CSharp30;

        public ICSharpFeature LanguageFeature => CSharpFeatures.ImplicitlyTypedLocalVaraiables.Instance;

        public string FriendlyName => "Consider declaring variable as var";

        public IEnumerable<AnalysisResult> Analyze(SyntaxTree syntaxTree, SemanticModel semanticModel, SingleSyntaxTreeAnalysisContext analysisContext)
        {
            var analysisResult = new List<AnalysisResult>();
            analysisResult.AddRange(GetVariableAnalysisResult(syntaxTree, analysisContext));
            return analysisResult;
        }

       
        public static readonly UseVarInsteadOfPredefinedType Instance = new UseVarInsteadOfPredefinedType();


        private List<AnalysisResult> GetVariableAnalysisResult(SyntaxTree syntaxTree, SingleSyntaxTreeAnalysisContext analysisContext)
        {

            var analysisResult = new List<AnalysisResult>();

            var variableDeclarations = syntaxTree.GetRoot().DescendantNodes()
                            .OfType<VariableDeclarationSyntax>().ToList();

            foreach (var declaration in variableDeclarations)
            {
                if (declaration.ChildNodes().Any(x => (x is GenericNameSyntax)) || declaration.ChildNodes().Any(x => (x is QualifiedNameSyntax)))
                {
                    var LHSType = declaration.DescendantNodes().OfType<GenericNameSyntax>().FirstOrDefault();
                    if (LHSType != null)
                    {
                        var RHSType = declaration.DescendantNodes().OfType<ObjectCreationExpressionSyntax>()
                                .FirstOrDefault().DescendantNodes().OfType<GenericNameSyntax>().FirstOrDefault();
                        if (RHSType != null && (LHSType.ToString() == RHSType.ToString()))
                        {
                            analysisResult.Add(new AnalysisResult(
                               this,
                               analysisContext,
                               syntaxTree.FilePath,
                               declaration.GetFirstToken(),
                               declaration));
                        }
                    }
                }


                if ((declaration.ChildNodes().Any(x => x is PredefinedTypeSyntax) || declaration.ChildNodes().Any(x => x is IdentifierNameSyntax))
                    && declaration.DescendantNodes().Any(x => x is EqualsValueClauseSyntax))
                {
                    //var LHSType = declaration.ChildNodes().FirstOrDefault(x => x is PredefinedTypeSyntax);
                    //var RHSType = declaration.DescendantNodes().FirstOrDefault(x => x is ObjectCreationExpressionSyntax).ChildNodes().FirstOrDefault(x => x is PredefinedTypeSyntax);
                    //if(LHSType != null && RHSType != null && RHSType.ToString() == LHSType.ToString())
                    //{
                        analysisResult.Add(new AnalysisResult(
                              this,
                              analysisContext,
                              syntaxTree.FilePath,
                              declaration.GetFirstToken(),
                              declaration));

                   // }

                }


            }
            return analysisResult;
        }
    }
}