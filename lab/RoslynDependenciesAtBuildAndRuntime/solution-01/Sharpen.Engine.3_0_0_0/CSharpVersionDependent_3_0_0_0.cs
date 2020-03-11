using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Sharpen.Engine.CSharpVersionDependent;

namespace Sharpen.Engine
{
    public class CSharpVersionDependent_3_0_0_0 : ICSharpVersionDependent
    {
        public string DoSomethngWithNullableReferenceTypes(SyntaxTree syntaxTree)
        {
            var count = syntaxTree.GetRoot()
                .DescendantNodes()
                .Where(node => node.IsKind(SyntaxKind.NullableDirectiveTrivia) || node.IsKind(SyntaxKind.NullableKeyword) || node.IsKind(SyntaxKind.SuppressNullableWarningExpression))
                .Count();

            return
                "This code is compiled on the fly.\n" + 
                $"Found {count} nodes that have something to do with nullable reference types.";
        }
    }
}
