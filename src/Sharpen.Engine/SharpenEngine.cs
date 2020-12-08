using Sharpen.Engine.Analysis;
using Sharpen.Engine.CodeDetection;

namespace Sharpen.Engine
{
    public class SharpenEngine : ISharpenEngine
    {
        public IScopeAnalyzerCreator ScopeAnalyzerCreator { get; } = new ScopeAnalyzerCreator();

        public IGeneratedCodeDetector GeneratedCodeDetector { get; } = new GeneratedCodeDetector();
    }
}
