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
        /// takes a single item and returns an enumerable of it
        /// </summary>
        public static IEnumerable<T> Yield<T>(this T item) {
            yield return item;
        }

    }
}
