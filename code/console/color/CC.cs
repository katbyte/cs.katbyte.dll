//Copyright © 2014 kt@katbyte.me
using System;


namespace katbyte.console {


    /// <summary>
    /// A static class to make referring to console colors cleaner/shorter, and brings back all caps for the constants
    /// 
    /// ie CC.BLACK vs ConsoleColor.Black
    /// </summary>
    public static class CC {

        //disable CS1591: Missing XML comment for publicly visible type or member 
        //    TODO: actually comment these
        #pragma warning disable 1591
        public const ConsoleColor White       = ConsoleColor.White;
        public const ConsoleColor Black       = ConsoleColor.Black;
        public const ConsoleColor Gray        = ConsoleColor.Gray;
        public const ConsoleColor DarkGray    = ConsoleColor.DarkGray;
        public const ConsoleColor Blue        = ConsoleColor.Blue;
        public const ConsoleColor DarkBlue    = ConsoleColor.DarkBlue;
        public const ConsoleColor Green       = ConsoleColor.Green;
        public const ConsoleColor DarkGreen   = ConsoleColor.DarkGreen;
        public const ConsoleColor Cyan        = ConsoleColor.Cyan;
        public const ConsoleColor DarkCyan    = ConsoleColor.DarkCyan;
        public const ConsoleColor Red         = ConsoleColor.Red;
        public const ConsoleColor DarkRed     = ConsoleColor.DarkRed;
        public const ConsoleColor Magenta     = ConsoleColor.Magenta;
        public const ConsoleColor DarkMagenta = ConsoleColor.DarkMagenta;
        public const ConsoleColor Yellow      = ConsoleColor.Yellow;
        public const ConsoleColor DarkYellow  = ConsoleColor.DarkYellow;
        

        public const ConsoleColor WHITE       = ConsoleColor.White;
        public const ConsoleColor BLACK       = ConsoleColor.Black;
        public const ConsoleColor GRAY        = ConsoleColor.Gray;
        public const ConsoleColor DARKGRAY    = ConsoleColor.DarkGray;
        public const ConsoleColor BLUE        = ConsoleColor.Blue;
        public const ConsoleColor DARKBLUE    = ConsoleColor.DarkBlue;
        public const ConsoleColor GREEN       = ConsoleColor.Green;
        public const ConsoleColor DARKGREEN   = ConsoleColor.DarkGreen;
        public const ConsoleColor CYAN        = ConsoleColor.Cyan;
        public const ConsoleColor DARKCYAN    = ConsoleColor.DarkCyan;
        public const ConsoleColor RED         = ConsoleColor.Red;
        public const ConsoleColor DARKRED     = ConsoleColor.DarkRed;
        public const ConsoleColor MAGENTA     = ConsoleColor.Magenta;
        public const ConsoleColor DARKMAGENTA = ConsoleColor.DarkMagenta;
        public const ConsoleColor YELLOW      = ConsoleColor.Yellow;
        public const ConsoleColor DARKYELLOW  = ConsoleColor.DarkYellow;
     
    }
}