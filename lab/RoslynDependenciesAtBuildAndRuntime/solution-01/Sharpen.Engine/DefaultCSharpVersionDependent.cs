using Microsoft.CodeAnalysis;
using Sharpen.Engine.CSharpVersionDependent;

namespace Sharpen.Engine
{
    internal class DefaultCSharpVersionDependent : ICSharpVersionDependent
    {
        public string DoSomethngWithNullableReferenceTypes(SyntaxTree syntaxTree)
        {
            return "In this version nullable reference types do not exist.";
        }
    }
}
