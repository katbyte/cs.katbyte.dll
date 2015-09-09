//Copyright © 2014 kt@katbyte.me
using System;
using System.Timers;



namespace katbyte.console {

    /// <summary>
    /// writes dots to the screen while it in existence
    /// </summary>
    public class ConsoleDots : IDisposable {

    //private data

        private bool disposed = false;

        /// <summary>
        /// timer used to time the dots
        /// </summary>
        private readonly Timer timer;


    //public data
        /// <summary>
        /// the dot charater used
        /// </summary>
        public readonly char dot;

        /// <summary>
        /// starting text
        /// </summary>
        public readonly CT start;

        /// <summary>
        /// finished text
        /// </summary>
        public readonly CT finish;

        /// <summary>
        /// color of the dot
        /// </summary>
        public readonly ConsoleColors dotColor;



    //constructors
        /// <summary>
        /// Creates a new console dot object with the specified parameters
        /// </summary>
        public ConsoleDots(int interval, ConsoleColor? fore = null, ConsoleColor? back = null, char dot = '.', CT start = null, CT finish = null, bool autostart = true) {
            this.dot = dot;

            dotColor = new ConsoleColors(fore, back);

            this.start  = start;
            this.finish = finish;


            timer = new Timer(interval);
            timer.Elapsed += Dot;

            if (autostart) {
                Start();
            }
        }



    //methods
        /// <summary>
        /// Starts the dots
        /// </summary>
        public void Start() {
            if (start != null) {
                Konsole.Write(start);
            }

            timer.Enabled = true;
            Dot();
        }


        /// <summary>
        /// writes a dot to the screen
        /// </summary>
        public void Dot(object source = null, ElapsedEventArgs e = null) {
            Konsole.Write(dotColor, ""+dot);
        }



    //disposing
        /// <summary>
        /// disposes the timer and stops the dots
        /// </summary>
        public void Dispose() {
            Dispose(true);
        }

        /// <summary>
        /// disposes the timer and stops the dots
        /// </summary>
        public virtual void Dispose(bool disposing) {
            if (disposed || !disposing) {
                return;
            }

            timer.Dispose();

            if (finish != null) {
                Konsole.Write(finish);
            }
        }
    }
}
