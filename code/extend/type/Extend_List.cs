//Copyright © 2015 kt@katbyte.me
using System.Collections.Generic;



namespace katbyte.extend {

    /// <summary>
    /// Container class for List Extensions
    /// </summary>
    public static class Extend_List {

        /// <summary>
        /// returns true if the list is empty
        /// </summary>
        public static bool IsEmpty<T>(this List<T> list)  {
            return list.Count == 0;
        }
    }
}