//Copyright © 2014 kt@katbyte.me
using System;
using System.Runtime.InteropServices;


namespace katbyte.win32{

    public static partial class Win32 {

        /// <summary>
        /// Container class for all win32 kernel32.dll api calls
        /// </summary>
        public static class Kernel32 {
  
            /// <summary>
            /// Retrieves the window handle used by the console associated with the calling process.
            /// </summary>
            [DllImport("kernel32.dll")]
            public static extern IntPtr GetConsoleWindow();

        }
    }
}