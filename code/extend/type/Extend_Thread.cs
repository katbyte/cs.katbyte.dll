//Copyright © 2015 kt@katbyte.me
using System.Threading;



namespace katbyte.extend {

    /// <summary>
    /// Container class for Thread Extensions
    /// </summary>
    public static class Extend_Thread {

        /// <summary>
        /// returns true if the list is empty
        /// </summary>
        public static bool IsNotNullAndAlive(this Thread thread)  {
            return thread != null && thread.IsAlive;
        }
    }
}