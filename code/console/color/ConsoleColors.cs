//Copyright © 2014 kt@katbyte.me
using System;



namespace katbyte.console {


    /// <summary>
    /// container for the console's foreground and background colors
    /// </summary>
    public class ConsoleColors  {

    //data
        /// <summary>
        /// the foreground color
        /// </summary>
        public readonly ConsoleColor? fore;

        /// <summary>
        /// the background color
        /// </summary>
        public readonly ConsoleColor? back;



    //constructor
        /// <summary>
        /// sets the foreground and background to the specified colors.
        /// </summary>
        public ConsoleColors(ConsoleColor? fore = null, ConsoleColor? back = null) {
            this.fore = fore;
            this.back = back;
        }



    //static helpers
        /// <summary>
        /// returns a ConsoleColors representing the current console colors
        /// </summary>
        public static ConsoleColors current => new ConsoleColors(Console.ForegroundColor, Console.BackgroundColor);
    }
}