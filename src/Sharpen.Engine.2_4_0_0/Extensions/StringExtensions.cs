using System.Linq;

namespace Sharpen.Engine.Extensions
{
    internal static class StringExtensions
    {
        public static bool CouldBePotentialParameterName(this string text)
        {
            // So far a **very** simple check.
            return !text.Any(character => char.IsPunctuation(character) || char.IsWhiteSpace(character));
        }
    }
}
