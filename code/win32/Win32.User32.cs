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






            /// <summary>
            ///Changes the size, position, and Z order of a child, pop-up, or top-level window.
            /// </summary>
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);


             /// <summary>
            /// Places the window at the top of the Z order.
            /// </summary>
            static readonly IntPtr HWND_TOP = new IntPtr(0);

            /// <summary>
            /// Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.
            /// </summary>
            static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

            /// <summary>
            /// Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.
            /// </summary>
            static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

            /// <summary>
            /// Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window is already a non-topmost window.
            /// </summary>
            static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);


            /// <summary>
            /// Retains the current size (ignores the cx and cy parameters).
            /// </summary>
            const UInt32 SWP_NOSIZE = 0x0001;

            /// <summary>
            /// Retains the current position (ignores the X and Y parameters).
            /// </summary>
            const UInt32 SWP_NOMOVE = 0x0002;


            /// <summary>
            /// sets the current window to be topmost
            /// </summary>
            public static bool SetWindowTopMost(IntPtr hWnd, bool @is = true) {
                return SetWindowPos(hWnd, @is ? HWND_TOPMOST : HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
            }


            /// <summary>
            /// sets the current window to be topmost
            /// </summary>
            public static bool SetWindowNotTopMost(IntPtr hWnd) {
                return SetWindowTopMost(hWnd, false);
            }


        }
    }
}