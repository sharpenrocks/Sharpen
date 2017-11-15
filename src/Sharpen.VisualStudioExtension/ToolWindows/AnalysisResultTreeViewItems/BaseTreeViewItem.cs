using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        private class UnloadedChildrenTreeViewItem : BaseTreeViewItem { }
        
        private static readonly BaseTreeViewItem[] UnloadedChildrenMarker = { new UnloadedChildrenTreeViewItem() };

        private readonly IAnalysisResultTreeViewBuilder treeViewBuilder;

        // This constructor is used only to create the single UnloadedChildrenTreeViewItem instance.
        private BaseTreeViewItem() {}

        protected BaseTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, bool isLeaf = false)
        {
            this.treeViewBuilder = treeViewBuilder;

            Parent = parent;

            children = isLeaf ? Enumerable.Empty<BaseTreeViewItem>() : UnloadedChildrenMarker;
        }

        private bool ChildrenAreNotLoaded => ReferenceEquals(Children, UnloadedChildrenMarker);

        private IEnumerable<BaseTreeViewItem> children;
        public IEnumerable<BaseTreeViewItem> Children
        {
            get => children;
            set
            {
                children = value;
                OnPropertyChanged();
            }
        }

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
                    Children = treeViewBuilder.BuildChildrenTreeViewItemsOf(this);
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

        public BaseTreeViewItem Parent { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}