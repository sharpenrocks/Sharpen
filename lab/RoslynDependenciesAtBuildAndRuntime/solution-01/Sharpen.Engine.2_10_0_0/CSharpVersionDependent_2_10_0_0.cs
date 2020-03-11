using Microsoft.CodeAnalysis;
using Sharpen.Engine.CSharpVersionDependent;

namespace Sharpen.Engine
{
    public class CSharpVersionDependent_2_10_0_0 : ICSharpVersionDependent
    {
        public string DoSomethngWithNullableReferenceTypes(SyntaxTree syntaxTree)
        {
            return
                "This code is compiled on the fly.\n" +
                "In this version nullable reference types also do not exist but it is a version newer then our oldest supported version.";
        }
    }
}
