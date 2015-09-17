//Copyright © 2014 kt@katbyte.me
using System;
using System.Collections.Generic;

using katbyte.data;
using katbyte.extend;
using katbyte.win32;



namespace katbyte.console {

    /// <summary>
    /// Static container class for all Console related methods
    /// </summary>
    public static partial class Konsole {

    //window
        /// <summary>
        /// get a win32 handle to the console window via win32 + p/invoke
        /// </summary>
        /// <returns></returns>
        public static IntPtr WindowHandle() {
            return Win32.Kernel32.GetConsoleWindow();
        }

        /// <summary>
        /// sets the console window position
        /// </summary>
        public static void SetWindowPosistion(int x = 0, int y = 0) {
            var handle = WindowHandle();
            var rect   = new Windef.RECT();
            Win32.User32.GetWindowRect(handle, ref rect);
            Win32.User32.MoveWindow(handle, x, y, rect.right - rect.left, rect.bottom - rect.top, true);
        }


        /// <summary>
        /// tries to set the window size to w and h bounded to the largest window size possible
        /// </summary>
        public static void TrySetWindowSize(int w = 170, int h = 70) {
            Console.SetWindowSize(
                Math.Min(w, Console.LargestWindowWidth),
                Math.Min(h, Console.LargestWindowHeight)
            );
        }

        /// <summary>
        ///tries to set the window size to w and h bounded to the current window width and largest window size possible
        /// </summary>
        public static void TrySetBufferSize(int w = 170, int h = 7770) {
            Console.SetBufferSize(Math.Min(w, Console.WindowWidth), h);
        }




    //color
        /// <summary>
        /// Sets the console colors
        /// </summary>
        public static void Color(ConsoleColor? fore = null, ConsoleColor? back = null) {
            if (fore.HasValue) {
                Console.ForegroundColor = fore.Value;
            }

            if (back.HasValue) {
                Console.BackgroundColor = back.Value;
            }
        }

        /// <summary>
        /// Sets the console colors
        /// </summary>
        public static void Color(ConsoleColors colors) {
            if (colors != null) {
                Color(colors.fore, colors.back);
            }
        }



    //write

        /// <summary>
        /// Writes text to the console, here for completeness only
        /// </summary>
        public static void Write(string text) {
            Console.Write(text);
        }


        /// <summary>
        /// changes the console colors and then writes text to the console
        /// </summary>
        public static void Write(ConsoleColor? fore, ConsoleColor? back, string str, params object[] objects) {
            Color(fore, back);
            Console.Write(str, objects);
        }

        /// <summary>
        /// changes the console colors and then writes text to the console
        /// </summary>
        public static void Write(ConsoleColors colors, string str, params object[] objects) {
            Color(colors);
            Console.Write(str, objects);
        }

        /// <summary>
        /// changes the console colors (forground only) and then writes text to the console
        /// </summary>
        public static void Write(ConsoleColor fore, string str, params object[] objects) {
            Write(fore, (ConsoleColor?)null, str, objects);
        }


        /// <summary>
        /// writes a CT (colored text) object to the console
        /// </summary>
        public static void Write(CT ct) {
            Write(ct.fore, ct.back, ct.text);
        }


        /// <summary>
        /// writes an array of CT (colored text) objects to the console
        /// </summary>
        public static void Write(params CT[] cts) {
            cts.ForEach(Write);
        }

        /// <summary>
        /// writes a IEnumerable of CT (colored text) objects to the console
        /// </summary>
        public static void Write(IEnumerable<CT> cts) {
            cts.ForEach(Write);
        }




    //write line
        /// <summary>
        /// Writes text to the console followed by a line terminator, here for completeness only
        /// </summary>
        public static void WriteLine(string text) {
            Console.WriteLine(text);
        }

        /// <summary>
        /// changes the console colors and then writes text to the console followed by a line terminator
        /// </summary>
        public static void WriteLine(ConsoleColor? fore, ConsoleColor? back, string line, params object[] objects) {
            Write(fore, back, line, objects);
            Console.WriteLine();
        }

        /// <summary>
        /// changes the console colors and then writes text to the console followed by a line terminator
        /// </summary>
        public static void WriteLine(ConsoleColor fore, string line, params object[] objects) {
            WriteLine(fore, (ConsoleColor?)null, line, objects);
        }


        /// <summary>
        /// writes a CT (colored text) object to the console followed by a line terminator
        /// </summary>
        public static void WriteLine(CT ct)                 { WriteLine(ct.fore, ct.back, ct.text); }


        /// <summary>
        /// writes an array of CT (colored text) objects to the console followed by a line terminator
        /// </summary>
        public static void WriteLine(params CT[] cts) {
            WriteLine((IEnumerable<CT>)cts);
        }

        /// <summary>
        /// writes a enumerable of CT (colored text) object to the console followed by a line terminator
        /// </summary>
        public static void WriteLine(IEnumerable<CT> cts)   {
            cts.ForEach(Write);
            Console.WriteLine();
        }



    //readline
        /// <summary>
        /// reads a line of text from the console with the specified text colors
        /// </summary>
        public static string ReadLine(ConsoleColor? fore = null, ConsoleColor? back = null) {
            using (new ColorConsole(fore, back)) {
                return Console.ReadLine();
            }
        }

        /// <summary>
        /// reads a line of text from the console with the specified text colors
        /// </summary>
        public static string ReadLine(ConsoleColors colors = null) {
            using (new ColorConsole(colors)) {
                return Console.ReadLine();
            }
        }



    //cursor
        /// <summary>
        /// gets or sets the cursor
        /// </summary>
        public static KPoint cursor {
            get { return new KPoint(Console.CursorLeft, (Console.CursorTop)); }
            set { Console.SetCursorPosition(value.x, value.y); }
        }

        /// <summary>
        /// adds x/y to the current cursor position
        /// </summary>
        public static void CursorAdd(int x = 0, int y = 0) {
            if ( x != 0 ) {
                Console.CursorLeft = Math.Max(0, Console.CursorLeft + x);
            }

            if ( y != 0 ) {
                Console.CursorTop  = Math.Max(0, Console.CursorTop + y);
            }
        }

        /// <summary>
        /// Sets the cursor, why wrap it? because the regular one is to long.... :D
        /// </summary>
        public static void SetCursor(int x, int y) {
            Console.SetCursorPosition(x, y);
        }

    }
}