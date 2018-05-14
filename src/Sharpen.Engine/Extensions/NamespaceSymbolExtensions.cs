using Microsoft.CodeAnalysis;

namespace Sharpen.Engine.Extensions
{
    internal static class NamespaceSymbolExtensions
    {
        // We want to check if the full name of the namespace equals the full name presented as
        // dot-separated string without creating any new strings.
        public static bool FullNameIsEqualTo(this INamespaceSymbol namespaceSymbol, string fullName)
        {
            if (fullName.Length != GetLengthOfTheNamespaceFullName()) return false;

            return EachNamespacePartEqualsNamespacePartInFullName();

            int GetLengthOfTheNamespaceFullName()
            {
                int numberOfNamespaces = 0;
                int length = 0;
                var currentNamespace = namespaceSymbol;
                while (!currentNamespace.IsGlobalNamespace && currentNamespace != null)
                {
                    length += currentNamespace.Name.Length;
                    numberOfNamespaces++;
                    currentNamespace = currentNamespace.ContainingNamespace;
                }

                return length + (numberOfNamespaces - 1); // Add the number of dots which is the number of namespaces - 1;
            }

            bool EachNamespacePartEqualsNamespacePartInFullName()
            {
                var fullNameStartingIndex = fullName.Length;

                var currentNamespace = namespaceSymbol;
                while (currentNamespace != null)
                {
                    fullNameStartingIndex -= currentNamespace.Name.Length;

                    if (string.CompareOrdinal(currentNamespace.Name, 0, fullName, fullNameStartingIndex, currentNamespace.Name.Length) != 0) return false;

                    currentNamespace = currentNamespace.ContainingNamespace;

                    // If there are more namespace parts to check.
                    if (fullNameStartingIndex > 0)
                    {
                        // Check for the dot and skip it.
                        fullNameStartingIndex--;
                        if (fullName[fullNameStartingIndex] != '.') return false;
                    }
                }

                return true;
            }
        }
    }
}