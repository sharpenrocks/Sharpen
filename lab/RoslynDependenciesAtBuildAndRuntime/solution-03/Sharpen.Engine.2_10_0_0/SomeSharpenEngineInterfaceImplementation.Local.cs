using Microsoft.CodeAnalysis;
using System.Reflection;

namespace Sharpen.Engine
{
    public partial class SomeSharpenEngineInterfaceImplementation
    {
        private string DoSomethingWithNullableReferenceTypes(SyntaxTree syntaxTree)
        {
            return
                $"This code is dynamically loaded from the assembly {Assembly.GetExecutingAssembly().FullName}.\n" +
                "In this version nullable reference types do not exist, but it is a version newer then our oldest supported version.";
        }
    }
}
