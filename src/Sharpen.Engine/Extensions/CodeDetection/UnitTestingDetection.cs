using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sharpen.Engine.Extensions.CodeDetection
{
    // TODO-SETTINGS: E.g. possibility to define additional namespaces etc.

    /// <summary>
    /// Contains extension methods related to the detection
    /// of unit testing code.
    /// </summary>
    internal static class UnitTestingDetection
    {
        // This is the simplest heuristics possible. We just check for the
        // existence of the well known using directives. In like 99% of the cases
        // this will actually be enough.
        // We can in addition check for well known unit testing attributes just in
        // case somebody does a very unusual construct like omitting e.g.
        //     using NUnit.Framework;
        // an writing directly
        //     [NUnit.Framework.TextFixture]
        // This is very unlikely to occur in real-life code.
        // Therefore let's stick so far to this trivial yet sufficient heuristics.
        private static readonly HashSet<string> KnownUnitTestingUsingDirectives = new HashSet<string>
        {
            "NUnit.Framework",
            "Xunit",
            "Microsoft.VisualStudio.TestTools.UnitTesting",
            "csUnit"
            // TODO: Add additional testing frameworks from: https://github.com/dariusz-wozniak/List-of-Testing-Tools-and-Frameworks-for-.NET/blob/master/README.md
        };

        public static bool ContainsUnitTestingCode(this SyntaxTree syntaxTree)
        {
            return syntaxTree.GetRoot()
                .DescendantNodes()
                .ContainUnitTestingCode();
        }

        /// <summary>
        /// Returns true if <paramref name="syntaxNodes"/> contain unit testing code.
        /// The heuristics for the detection of unit testing code will be executed
        /// exactly on the provided <see cref="syntaxNodes"/>. Their descendant nodes
        /// will not be separately retrieved and analyzed. When calling this method
        /// make sure to provide all the relevant <see cref="SyntaxNode"/>s that have
        /// to be analyzed.
        /// In practices, these are usually syntaxTree.GetRoot().DescendantNodes().
        /// </summary>
        /// <remarks>
        /// The method has been introduced because of performance reasons.
        /// This also justifies the way it is used.
        /// By using it, we want to avoid the need of creating duplicate versions of
        /// all descendent nodes of a <see cref="SyntaxTree"/>.
        /// </remarks>
        public static bool ContainUnitTestingCode(this IEnumerable<SyntaxNode> syntaxNodes)
        {
            return syntaxNodes
                .OfType<UsingDirectiveSyntax>()
                .Any(usingDirective => KnownUnitTestingUsingDirectives.Contains(usingDirective.Name.ToString()));
            // TODO-PERF: Implement this without creating new strings.
        }
    }
}