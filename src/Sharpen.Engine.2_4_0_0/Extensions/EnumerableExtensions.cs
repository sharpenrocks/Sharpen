using System;
using System.Collections.Generic;

namespace Sharpen.Engine.Extensions
{
    internal static class EnumerableExtensions
    {
        public static (int FirstCount, int SecondCount) CountMany<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> firstPredicate, Func<TSource, bool> secondPredicate)
        {
            int firstCount = 0;
            int secondCount = 0;
            foreach (var element in source)
            {
                if (firstPredicate(element)) ++firstCount;
                if (secondPredicate(element)) ++secondCount;
            }

            return (firstCount, secondCount);
        }
    }
}
