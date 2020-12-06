using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Sharpen.Engine.Abstractions;

namespace Sharpen.Engine
{
    public partial class SomeSharpenEngineInterfaceImplementation : ISomeSharpenEngineInterface
    {
        public string DoSomethingWithTheSyntaxTree(SyntaxTree syntaxTree)
        {
            var versionDependentOutput = DoSomethingWithNullableReferenceTypes(syntaxTree);

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
                    Environment.NewLine +
                $"Doing something with nullable reference types:" +
                    Environment.NewLine +
                        versionDependentOutput +
                    Environment.NewLine;
        }
    }
}