//Copyright © 2014 kt@katbyte.me
using System;
using System.Collections.Generic;



namespace katbyte.extend {

    /// <summary>
    /// Container class for IEnumerable Extensions
    /// </summary>
    public static class Extend_IEnumerable {


        /// <summary>
        /// enumerates the enumerable performing the action on each element
        /// </summary>
        public static void ForEach<TSource> (this IEnumerable<TSource> source, Action<TSource> action) {
            foreach (var o in source) {
                action(o);
            }
        }

        /// <summary>
        /// Performs an action on each element of the enumerable
        /// </summary>
        public static IEnumerable<TSource> OnEach<TSource> (this IEnumerable<TSource> source, Action<TSource> action) {
            foreach (var o in source) {
                action(o);
                yield return o;
            }
        }

        /// <summary>
        /// forces an enumeration of the enumerable
        /// </summary>
        public static void Enumerate<TSource>(this IEnumerable<TSource> source) {
            // ReSharper disable once EmptyEmbeddedStatement
            foreach (var o in source) ;
        }

        /// <summary>
        /// takes a single item and returns an enumerable for it
        /// </summary>
        public static IEnumerable<T> Yield<T>(this T item) {
            yield return item;
        }


        /// <summary>
        /// returns the object with the maximum value determined via a selector
        /// </summary>
        public static TSource MaxBy<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector, IComparer<TValue> comparer = null) {
            using (IEnumerator<TSource> enumerator = source.GetEnumerator()) {
                if (!enumerator.MoveNext()) {
                    throw new InvalidOperationException("sequence is empty");
                }

                if (comparer == null) {
                    comparer = Comparer<TValue>.Default;
                }

                TSource max      = enumerator.Current;
                TValue  maxValue = selector(max);
                while (enumerator.MoveNext()) {
                    TSource o = enumerator.Current;
                    TValue  v = selector(o);
                    if (comparer.Compare(v, maxValue) > 0) {
                        max      = o;
                        maxValue = v;
                    }
                }

                return max;
            }
        }


        /// <summary>
        /// returns the object with the minimum value determined via a selector
        /// </summary>
        public static TSource MinBy<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector, IComparer<TValue> comparer = null) {
            using (IEnumerator<TSource> enumerator = source.GetEnumerator()) {
                if (!enumerator.MoveNext()) {
                    throw new InvalidOperationException("sequence is empty");
                }

                if (comparer == null) {
                    comparer = Comparer<TValue>.Default;
                }

                TSource min      = enumerator.Current;
                TValue  minValue = selector(min);
                while (enumerator.MoveNext()) {
                    TSource o = enumerator.Current;
                    TValue  v = selector(o);
                    if (comparer.Compare(v, minValue) < 0) {
                        min      = o;
                        minValue = v;
                    }
                }

                return min;
            }
        }

    }
}
