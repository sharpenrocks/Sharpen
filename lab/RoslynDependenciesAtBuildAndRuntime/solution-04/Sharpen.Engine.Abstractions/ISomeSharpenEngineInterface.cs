using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Abstractions
{
    public interface ISomeSharpenEngineInterface
    {
        string DoSomethingWithTheSyntaxTree(SyntaxTree syntaxTree);
    }
}