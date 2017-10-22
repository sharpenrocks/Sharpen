using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Sharpen.VisualStudioExtension.ToolWindows
{
    /// <summary>
    /// Handles UI commands that are results of the user interaction with the result list.
    /// </summary>
    /// <remarks>
    /// It was much quicker to introduce this interface then to go for a more "classical" approach of
    /// exposing events.
    /// </remarks>
    internal interface ISharpenResultsCommandHandler
    {
        void OpenResultFile(string filePath, FileLinePositionSpan position);
    }
}