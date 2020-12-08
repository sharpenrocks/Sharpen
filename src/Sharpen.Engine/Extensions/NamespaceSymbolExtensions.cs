using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Extensions
{
    internal static class NamespaceSymbolExtensions
    {
        public static bool FullNameIsEqualTo(this ITypeSymbol typeSymbol, string namespaceName, string typeName)
        {
            if (typeSymbol == null) return false;

            return typeSymbol.Name == typeName &&
                   typeSymbol.ContainingNamespace.FullNameIsEqualTo(namespaceName);
        }

        // We want to check if the full name of the namespace equals the full name presented as
        // dot-separated string without creating any new strings.
        public static bool FullNameIsEqualTo(this INamespaceSymbol namespaceSymbol, string namespaceName)
        {
            if (namespaceSymbol == null) return false;

            if (namespaceName.Length != GetLengthOfTheNamespaceFullName()) return false;

            return EachNamespacePartEqualsNamespacePartInFullName();

            int GetLengthOfTheNamespaceFullName()
            {
                int numberOfNamespaces = 0;
                int length = 0;
                var currentNamespace = namespaceSymbol;
                while (currentNamespace != null && !currentNamespace.IsGlobalNamespace)
                {
                    length += currentNamespace.Name.Length;
                    numberOfNamespaces++;
                    currentNamespace = currentNamespace.ContainingNamespace;
                }

                return length + (numberOfNamespaces - 1); // Add the number of dots which is the number of namespaces - 1;
            }

            bool EachNamespacePartEqualsNamespacePartInFullName()
            {
                var fullNameStartingIndex = namespaceName.Length;

                var currentNamespace = namespaceSymbol;
                while (currentNamespace != null)
                {
                    fullNameStartingIndex -= currentNamespace.Name.Length;

                    if (string.CompareOrdinal(currentNamespace.Name, 0, namespaceName, fullNameStartingIndex, currentNamespace.Name.Length) != 0) return false;

                    currentNamespace = currentNamespace.ContainingNamespace;

                    // If there are more namespace parts to check.
                    if (fullNameStartingIndex > 0)
                    {
                        // Check for the dot and skip it.
                        fullNameStartingIndex--;
                        if (namespaceName[fullNameStartingIndex] != '.') return false;
                    }
                }

                return true;
            }
        }
    }
}