using Microsoft.CodeAnalysis.Text;

namespace Sharpen.Engine.Extensions
{
    internal static class TextSpanExtensions
    {
        public static bool IsBetween(this TextSpan textSpan, TextSpan startTextSpan, TextSpan endTextSpan)
        {
            return textSpan.CompareTo(startTextSpan) > 0 && textSpan.CompareTo(endTextSpan) < 0;
        }

        public static bool IsAfter(this TextSpan textSpan, TextSpan otherTextSpan)
        {
            return textSpan.CompareTo(otherTextSpan) > 0;
        }
    }
}