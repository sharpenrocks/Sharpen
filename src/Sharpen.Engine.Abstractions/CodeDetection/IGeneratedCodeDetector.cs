using System;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Sharpen.Engine.CodeDetection
{
    /// <summary>
    /// Detects generated code.
    /// </summary>
    public interface IGeneratedCodeDetector
    {
        bool IsGenerated(Document document);

        bool IsGeneratedAssemblyInfo(Document document);

        bool IsGeneratedFile(string filePath);
    }
}