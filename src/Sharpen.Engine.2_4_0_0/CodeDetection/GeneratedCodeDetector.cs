using Microsoft.CodeAnalysis;
using Sharpen.Engine.Extensions.CodeDetection;

namespace Sharpen.Engine.CodeDetection
{
    internal class GeneratedCodeDetector : IGeneratedCodeDetector
    {
        public bool IsGenerated(Document document)
        {
            return document.IsGenerated();
        }

        public bool IsGeneratedAssemblyInfo(Document document)
        {
            return document.IsGeneratedAssemblyInfo();
        }

        public bool IsGeneratedFile(string filePath)
        {
            return GeneratedCodeDetection.IsGeneratedFile(filePath);
        }
    }
}
