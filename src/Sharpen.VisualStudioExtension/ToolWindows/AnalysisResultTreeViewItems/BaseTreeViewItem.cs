using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    /// <remarks>
    /// The approach to the lazy loading is taken from:
    /// https://www.codeproject.com/Articles/26288/Simplifying-the-WPF-TreeView-by-Using-the-ViewMode
    /// </remarks>
    internal abstract class BaseTreeViewItem : INotifyPropertyChanged
    {
        private class DummyTreeViewItem : BaseTreeViewItem { }

        private static readonly BaseTreeViewItem DummyChild = new DummyTreeViewItem();

        private readonly IAnalysisResultTreeViewBuilder treeViewBuilder;

        // This constructor is used only to create the DummyChild instance.
        private BaseTreeViewItem() { }

        protected BaseTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, bool isLeaf = false)
        {
            this.treeViewBuilder = treeViewBuilder;

            Parent = parent;

            Children = new ObservableCollection<BaseTreeViewItem>();

            if (!isLeaf)
                Children.Add(DummyChild);
        }

        public ObservableCollection<BaseTreeViewItem> Children { get; }

        private bool ChildrenAreNotLoaded => Children.Count == 1 && Children[0] == DummyChild;

        public string Text { get; protected set; }

        private bool isExpanded;
        public bool IsExpanded
        {
            get => isExpanded;
            set
            {
                if (value != isExpanded)
                {
                    isExpanded = value;
                    OnPropertyChanged();
                }

                // Expand all the way up to the root.
                if (isExpanded && Parent != null)
                    Parent.IsExpanded = true;

                // Lazy load the child items, if necessary.
                if (ChildrenAreNotLoaded)
                {
                    Children.Remove(DummyChild);
                    LoadChildren();
                }
            }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        private void LoadChildren()
        {
            foreach (var child in treeViewBuilder.GetChildrenTreeViewItemsOf(this))
            {
                Children.Add(child);
            }
        }

        public BaseTreeViewItem Parent { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}