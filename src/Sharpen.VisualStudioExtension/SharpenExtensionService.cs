using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using Microsoft.VisualStudio.LanguageServices;
using Sharpen.Engine;
using Task = System.Threading.Tasks.Task;

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

        // TODO-IG: Terrible and truly ugly :-( Mixing view aspects, logic, everything. But let's get the first analysis running and let's put the tool into practice and let's get some real-life results :-)
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

        private bool analysisIsRunning;
        public bool AnalysisIsRunning
        {
            get => analysisIsRunning;
            private set
            {
                analysisIsRunning = value;
                OnPropertyChanged();
            }
        }

        private CollectionView CreateAnalysisResultsViewFrom(IEnumerable<AnalysisResult> analysisResult)
        {
            var view = (CollectionView)CollectionViewSource.GetDefaultView(analysisResult);

            var groupByLanguageVersion = new PropertyGroupDescription("Suggestion.MinimumLanguageVersion");
            view.GroupDescriptions.Add(groupByLanguageVersion);

            var groupBySuggestion = new PropertyGroupDescription("Suggestion.FriendlyName");
            view.GroupDescriptions.Add(groupBySuggestion);

            var sortByLanguageVersion = new SortDescription("Suggestion.MinimumLanguageVersion", ListSortDirection.Ascending);
            view.SortDescriptions.Add(sortByLanguageVersion);

            var sortBySuggestion = new SortDescription("Suggestion.FriendlyName", ListSortDirection.Ascending);
            view.SortDescriptions.Add(sortBySuggestion);

            var sortByFilePath = new SortDescription("FilePath", ListSortDirection.Ascending);
            view.SortDescriptions.Add(sortByFilePath);

            var sortByLine = new SortDescription("Position.StartLinePosition.Line", ListSortDirection.Ascending);
            view.SortDescriptions.Add(sortByLine);

            var sortByCharacter = new SortDescription("Position.StartLinePosition.Character", ListSortDirection.Ascending);
            view.SortDescriptions.Add(sortByCharacter);

            return view;
        }

        public static SharpenExtensionService Instance { get; private set; }

        public static void CreateSingleInstance(SharpenEngine sharpenEngine)
        {
            Instance = new SharpenExtensionService(sharpenEngine);
        }

        public async Task RunSolutionAnalysisAsync(VisualStudioWorkspace visualStudioWorkspace)
        {
            if (AnalysisIsRunning)
                throw new InvalidOperationException("An analysis is already running. You cannot run a new analysis until the current one is not finished.");

            AnalysisResults = CreateAnalysisResultsViewFrom(Enumerable.Empty<AnalysisResult>());

            AnalysisIsRunning = true;

            var analysisResult = await sharpenEngine.AnalyzeAsync(visualStudioWorkspace);
            AnalysisResults = CreateAnalysisResultsViewFrom(analysisResult);

            AnalysisIsRunning = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}