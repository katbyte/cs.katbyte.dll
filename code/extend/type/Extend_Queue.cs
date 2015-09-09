//Copyright © 2015 kt@katbyte.me
using System.Collections.Generic;



namespace katbyte.extend {

    /// <summary>
    /// Container class for Queue Extensions
    /// </summary>
    public static class Extend_Queue {


        /// <summary>
        /// returns a queue for the enumerable
        /// </summary>
        public static Queue<T> ToQueue<T>(this IEnumerable<T> objects)  {
            return new Queue<T>(objects);
        }

        /// <summary>
        /// returns true if the queue is empty
        /// </summary>
        public static bool IsEmpty<T>(this Queue<T> q)  {
            return q.Count == 0;
        }
    }
}
