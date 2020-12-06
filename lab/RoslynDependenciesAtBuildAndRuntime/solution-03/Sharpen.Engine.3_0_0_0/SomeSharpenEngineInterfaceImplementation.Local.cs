using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;
using System.Reflection;

namespace Sharpen.Engine
{
    public partial class SomeSharpenEngineInterfaceImplementation
    {
        private string DoSomethingWithNullableReferenceTypes(SyntaxTree syntaxTree)
        {
            var count = syntaxTree.GetRoot()
                .DescendantNodes()
                .Where(node => node.IsKind(SyntaxKind.NullableDirectiveTrivia) || node.IsKind(SyntaxKind.NullableKeyword) || node.IsKind(SyntaxKind.SuppressNullableWarningExpression))
                .Count();

            return
                $"This code is dynamically loaded from the assembly {Assembly.GetExecutingAssembly().FullName}.\n" + 
                $"Found {count} nodes that have something to do with nullable reference types.";
        }
    }
}
