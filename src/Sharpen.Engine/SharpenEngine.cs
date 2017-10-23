using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.LanguageServices;
using Sharpen.Engine.SharpenSuggestions.CSharp70;

namespace Sharpen.Engine
{
    public class SharpenEngine
    {
        public IEnumerable<AnalysisResult> Analyze(VisualStudioWorkspace visualStudioWorkspace)
        {
            var suggestions = new ISharpenSuggestion[]
            {
                UseExpressionBodyForConstructors.Instance,
                UseExpressionBodyForDestructors.Instance,
                UseExpressionBodyForGetAccessors.Instance
            };

            return AnalyzeSingleSyntaxTrees(visualStudioWorkspace, suggestions.OfType<ISingleSyntaxTreeAnalyzer>().ToArray());
        }

        private IEnumerable<AnalysisResult> AnalyzeSingleSyntaxTrees(VisualStudioWorkspace visualStudioWorkspace, ISingleSyntaxTreeAnalyzer[] syntaxTreeAnalyzers)
        {
            foreach (var project in visualStudioWorkspace.CurrentSolution.Projects.Where(project => project.Language == "C#"))
            { 
                foreach (var document in project.Documents.Where(document => document.SupportsSyntaxTree))
                {
                    var syntaxTree = document.GetSyntaxTreeAsync().Result;

                    foreach (var analyzer in syntaxTreeAnalyzers)
                    {
                        foreach (var analysisResult in analyzer.Analyze(syntaxTree))
                        {
                            yield return analysisResult;
                        }
                    }
                }
            }
        }
    }
}
