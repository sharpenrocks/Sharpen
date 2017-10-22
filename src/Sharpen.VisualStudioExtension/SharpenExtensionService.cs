using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using Microsoft.VisualStudio.LanguageServices;
using Sharpen.Engine;

namespace Sharpen.VisualStudioExtension
{
    // TODO-IG: Find the best patterns for dependency injection and mediation in VS Extensions. Until then, this is going to be our Singleton God Object. Scarry.
    internal class SharpenExtensionService : INotifyPropertyChanged
    {
        private readonly SharpenEngine sharpenEngine;

        private SharpenExtensionService(SharpenEngine sharpenEngine)
        {
            this.sharpenEngine = sharpenEngine;
            AnalysisResults = CreateAnalysisResultsViewFrom(Enumerable.Empty<AnalysisResult>());
        }

        // TODO-IG: Terrible and truly ugly :-( Mixing view aspects, logic, everything. But let's get the first analysis running and let's put the tool into practice and let's get some real life result :-)
        private CollectionView analysisResults;
        public CollectionView AnalysisResults
        {
            get => analysisResults;
            private set
            {
                analysisResults = value;
                OnPropertyChanged();                
            }
        }

        private CollectionView CreateAnalysisResultsViewFrom(IEnumerable<AnalysisResult> analysisResult)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(analysisResult);
            PropertyGroupDescription languageVersionGroup = new PropertyGroupDescription("Suggestion.MinimumLanguageVersion");
            view.GroupDescriptions.Add(languageVersionGroup);

            PropertyGroupDescription suggestionGroup = new PropertyGroupDescription("Suggestion.FriendlyName");
            view.GroupDescriptions.Add(suggestionGroup);

            return view;
        }

        public static SharpenExtensionService Instance { get; private set; }

        public static void CreateSingleInstance(SharpenEngine sharpenEngine)
        {
            Instance = new SharpenExtensionService(sharpenEngine);
        }

        public void RunSolutionAnalysis(VisualStudioWorkspace visualStudioWorkspace)
        {
            AnalysisResults = CreateAnalysisResultsViewFrom(sharpenEngine.Analyze(visualStudioWorkspace));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}