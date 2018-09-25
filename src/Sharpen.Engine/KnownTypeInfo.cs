using Microsoft.CodeAnalysis;
using Sharpen.Engine.Extensions;

namespace Sharpen.Engine
{
    internal abstract class KnownTypeInfo
    {
        public string TypeName { get; }
        public string TypeNamespace { get; }

        protected KnownTypeInfo(string typeName, string typeNamespace)
        {
            TypeName = typeName;
            TypeNamespace = typeNamespace;
        }

        public bool RepresentsType(ITypeSymbol type) => type.FullNameIsEqualTo(TypeNamespace, TypeName);
    }
}