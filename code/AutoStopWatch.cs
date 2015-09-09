//Copyright © 2014 kt@katbyte.me
using System;
using System.Diagnostics;



namespace katbyte {

    /// <summary>
    /// encapsulates a StopWAtch and automatically starts it on construction and stops it on dispose.
    /// </summary>
    public class AutoStopWatch : Stopwatch, IDisposable {

        /// <summary>
        /// AutoStopWatch's Constructor, calls StopWatch.Start()
        /// </summary>
        public AutoStopWatch() {
            Start();
        }

        /// <summary>
        /// AutoStopWatch's Dispose Method, calls StopWatch.Stop()
        /// </summary>
        public virtual void Dispose() {
            Stop();
        }
    }
}
