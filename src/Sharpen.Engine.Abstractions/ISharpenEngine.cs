using Sharpen.Engine.Analysis;
using Sharpen.Engine.CodeDetection;

namespace Sharpen.Engine
{
    public interface ISharpenEngine
    {
        IScopeAnalyzerCreator ScopeAnalyzerCreator { get; }
        IGeneratedCodeDetector GeneratedCodeDetector { get; }
    }
}
