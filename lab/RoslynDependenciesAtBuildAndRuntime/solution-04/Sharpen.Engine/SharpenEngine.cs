using Sharpen.Engine.Abstractions;

namespace Sharpen.Engine
{
    public class SharpenEngine : ISharpenEngine
    {
        public ISomeSharpenEngineInterface SomeSharpenEngineInterface => new SomeSharpenEngineInterfaceImplementation();
    }
}