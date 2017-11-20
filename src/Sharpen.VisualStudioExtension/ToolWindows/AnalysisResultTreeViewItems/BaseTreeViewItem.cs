using System;
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
        private string text;

        // This constructor is used only to create the single UnloadedChildrenTreeViewItem instance.
        private BaseTreeViewItem() {}

        // TODO-DESIGN: Refactor the constructor parameters once when we see which need the upcoming builders have.
        // Only the leaf nodes will have the analysis result set.
        protected BaseTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, int numberOfItems, /* See [1]. */ string text)
        {
            this.treeViewBuilder = treeViewBuilder;
            this.text = text;

            Parent = parent;
            NumberOfItems = numberOfItems == 0 ? null : numberOfItems == 1 ? $"({numberOfItems} item)" : $"({numberOfItems} items)";

            children = numberOfItems == 0 ? Enumerable.Empty<BaseTreeViewItem>() : UnloadedChildrenMarker;
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

        public string Text => text ?? (text = GetText());

        protected virtual string GetText()
        {
            // See [1].
            throw new InvalidOperationException($"The virtual {nameof(GetText)}() method should never be called on the {nameof(BaseTreeViewItem)}." +
                                                $"This method must be overriden by the derived class if the derived class is setting the text parameter to null when calling the base constructor of the {nameof(BaseTreeViewItem)} class." +
                                                $"The derived class {GetType().Name} sets the text parameter to null but does not override the {nameof(GetText)}() method.");
        }

        public string NumberOfItems { get; protected set; }

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

/* 
    [1] Derived class must either set the text in the constructor or override the GetText() method.
        This is a slight optimization.
        We have two different kinds of derived classes (concrete tree view items) when it comes to their Text property.
        Some of them display strings that are already available in the system (e.g. Project name).
        In other words, they do not create new strings.
        Other create new strings just for the purpose of having a nice textual representation.
        In the second case, we want to have lazy load, for which the GetText() method is provided.
        In the first case, we do not want to force the derived class object to potentially unnecessary store reference to 
        this already known string just to be able to use it in the GetText() method.
        We also want to save the virtual call to the GetText() method.
        Therefor these two options. If the textual representation is already known in the system, just pass it to the base constructor.
        If it has to be calculated, pass null to the base constructor and implement the GetText() method.
*/
