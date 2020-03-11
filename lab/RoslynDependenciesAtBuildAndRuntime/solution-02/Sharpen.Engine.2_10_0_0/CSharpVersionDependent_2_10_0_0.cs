using Microsoft.CodeAnalysis;
using Sharpen.Engine.CSharpVersionDependent;
using System.Reflection;

namespace Sharpen.Engine
{
    public class CSharpVersionDependent_2_10_0_0 : ICSharpVersionDependent
    {
        public string DoSomethngWithNullableReferenceTypes(SyntaxTree syntaxTree)
        {
            return
                $"This code is dynamically loaded from the assembly {Assembly.GetExecutingAssembly().FullName}.\n" +
                "In this version nullable reference types do not exist, but it is a version newer then our oldest supported version.";
        }
    }
}
