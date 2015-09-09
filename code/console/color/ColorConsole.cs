//Copyright © 2014 kt@katbyte.me
using System;


namespace katbyte.console {


    /// <summary>
    /// a class that saves / sets the console colors and then upon disposal reverts it
    /// </summary>
    public class ColorConsole : IDisposable {

    //data
        /// <summary>
        /// to prevent multiple reverts
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// old console colors
        /// </summary>
        private readonly ConsoleColors  old;



    //constructors
        /// <summary>
        /// save current console color and set it to the provided values if they are provided
        /// </summary>
        public ColorConsole(ConsoleColor? fore = null, ConsoleColor? back = null) : this (new ConsoleColors(fore, back)) { }

        /// <summary>
        /// save current console color and set it to the provided values if they are provided
        /// </summary>
        public ColorConsole(ConsoleColors colors = null)  {
            old = ConsoleColors.current;

            Konsole.Color(colors);
        }



    //dispose
        /// <summary>
        /// reverts console colors
        /// </summary>
        public void Dispose() {
            Dispose(true);
        }


        /// <summary>
        /// reverts console colors
        /// </summary>
        public virtual void Dispose(bool disposing) {
            if (disposed || !disposing) {
                return;
            }

            Konsole.Color(old);
            disposed = true;
        }
    }
}