using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Sharpen.Engine
{
    public class SomeSharpenEngineClass
    {
        public string DoSomethingWithTheSyntaxTree(SyntaxTree syntaxTree)
        {
            return
                "Assembly location:" +
                    Environment.NewLine +
                        syntaxTree.GetType().Assembly.Location +
                    Environment.NewLine +
                "Assembly name and version:" +
                    Environment.NewLine +
                        syntaxTree.GetType().Assembly +
                    Environment.NewLine +
                $"Number of {nameof(SyntaxNode)} types:" +
                    Environment.NewLine +
                        syntaxTree.GetType().Assembly
                            .ExportedTypes
                            .Count(type => typeof(SyntaxNode).IsAssignableFrom(type)) +
                    Environment.NewLine +
                $"Number of {nameof(SyntaxKind)} entries:" +
                    Environment.NewLine +
                        Enum.GetValues(typeof(SyntaxKind)).Length +
                    Environment.NewLine;
        }
    }
}