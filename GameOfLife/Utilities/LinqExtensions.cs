using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Utilities
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> ReplaceAll<T>(
            this IEnumerable<T> sequence,
            IEnumerable<T> replaceWith,
            Func<T, bool> predicate) where T : IEquatable<T>
        {
            var newValues = replaceWith as T[] ?? replaceWith.ToArray();

            foreach (var value in sequence)
            {
                var replaceCell = newValues.Where(predicate).SingleOrDefault(a => a.Equals(value));
                if (replaceCell != null)
                {
                    yield return replaceCell;
                    continue;
                }
                yield return value;
            }
        }
    }
}