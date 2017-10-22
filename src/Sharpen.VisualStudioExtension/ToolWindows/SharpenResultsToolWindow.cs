using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Data;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.Shell;
using Sharpen.Engine;
using Sharpen.Engine.SharpenSuggestions.CSharp70;

namespace Sharpen.VisualStudioExtension.ToolWindows
{
    [Guid("65004bcd-32ae-4aef-934f-e82446ae942c")]
    public sealed class SharpenResultsToolWindow : ToolWindowPane
    {
        public SharpenResultsToolWindow() : base(null)
        {
            Caption = "Sharpen Results";

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(CreateDummyResult());
            PropertyGroupDescription languageVersionGroup = new PropertyGroupDescription("Suggestion.MinimumLanguageVersion");
            view.GroupDescriptions.Add(languageVersionGroup);

            PropertyGroupDescription suggestionGroup = new PropertyGroupDescription("Suggestion.FriendlyName");
            view.GroupDescriptions.Add(suggestionGroup);

            var control = new SharpenResultsToolWindowControl { DataContext = view };

            Content = control;
        }

        private IEnumerable<AnalysisResult> CreateDummyResult()
        {
            var random = new Random();
            int numberofAnalysisResults = random.Next(2000);
            for (int i = 0; i < numberofAnalysisResults; i++)
            {
                yield return new AnalysisResult(UseExpressionBodyForConstructors.Instance, "File_" + Guid.NewGuid() + ".cs", TextSpan.FromBounds(random.Next(500), random.Next(501, 2000)));
            }
            numberofAnalysisResults = random.Next(2000);
            for (int i = 0; i < numberofAnalysisResults; i++)
            {
                yield return new AnalysisResult(UseExpressionBodyForFinalizers.Instance, "File_" + Guid.NewGuid() + ".cs", TextSpan.FromBounds(random.Next(500), random.Next(501, 2000)));
            }
        }
    }
}