//Copyright © 2015 kt@katbyte.me
using System.Collections.Generic;



namespace katbyte.extend {

    /// <summary>
    /// Container class for Array Extensions
    /// </summary>
    public static class Extend_Array {


        /// <summary>
        /// returns true if the queue is empty
        /// </summary>
        public static bool IsEmpty<T>(this T[] a)  {
            return a.Length == 0;
        }

    }
}
