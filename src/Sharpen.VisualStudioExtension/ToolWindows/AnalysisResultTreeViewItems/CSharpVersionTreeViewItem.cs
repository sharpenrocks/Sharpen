using Sharpen.Engine;
using Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewBuilders;

namespace Sharpen.VisualStudioExtension.ToolWindows.AnalysisResultTreeViewItems
{
    internal sealed class CSharpVersionTreeViewItem : BaseTreeViewItem
    {
        public string CSharpVersion { get; }

        public CSharpVersionTreeViewItem(BaseTreeViewItem parent, IAnalysisResultTreeViewBuilder treeViewBuilder, int numberOfItems, string cSharpVersion)
            : base(parent, treeViewBuilder, numberOfItems, "C# " + cSharpVersion, CSharpLanguageVersions.GetWhatIsNewUrlFor(cSharpVersion), GetLearnMoreDisplayTextFor(cSharpVersion)) // TODO: Replace the string creation once the abstraction for the C# version is fully implemented.
        {
            CSharpVersion = cSharpVersion;
        }

        private static string GetLearnMoreDisplayTextFor(string cSharpVersion)
        {
            return $"What {(cSharpVersion == CSharpLanguageVersions.Latest ? "is" : "was")} new in C# {cSharpVersion}?";
        }
    }
}