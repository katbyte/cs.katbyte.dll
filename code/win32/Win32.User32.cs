//Copyright © 2014 kt@katbyte.me
using System;
using System.Runtime.InteropServices;


namespace katbyte.win32 {

    public static partial class Win32 {

        /// <summary>
        /// Container class for all win32 user32.dll api calls
        /// </summary>
        public static class User32 {

            /// <summary>
            /// Retrieves the dimensions of the bounding rectangle of the specified window. The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
            /// </summary>
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
            public static extern bool GetWindowRect(IntPtr hWnd, ref Windef.RECT rect);

            /// <summary>
            /// Changes the position and dimensions of the specified window. For a top-level window, the position and dimensions are relative to the upper-left corner of the screen. For a child window, they are relative to the upper-left corner of the parent window's client area.
            /// </summary>
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        }
    }
}