//Copyright © 2014 kt@katbyte.me
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Reflection;

using katbyte.extend;



namespace katbyte.console {


    /// <summary>
    /// a handy object for console programs to derive from
    /// </summary>
    abstract public class KonsoleProgram {


        /// <summary>
        /// true if PROGRAM WAS started in a command prompt (or cygwin)
        /// </summary>
        public static bool inPrompt =   !(     Environment.UserInteractive
                                            && ( Debugger.IsAttached || Environment.GetCommandLineArgs()[0] == Assembly.GetEntryAssembly().Location)
                                            && ( Debugger.IsAttached || Console.Title == Environment.GetCommandLineArgs()[0])
                                           // && Environment.CurrentDirectory == Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)
                                           // ^^ breaks on drag on drop
                                            && Console.CursorTop  == 0
                                            && Console.CursorLeft == 0
                                            #if !DOTNET_35
                                                && !Console.IsOutputRedirected
                                                && !Console.IsInputRedirected
                                                && !Console.IsErrorRedirected
                                            #endif
                                        );


    //title
        /// <summary>
        /// set window title to this if its not null
        /// </summary>
        public virtual string title => null;

        /// <summary>
        /// console title on program start
        /// </summary>
        public readonly string originalTitle = Console.Title;


    //old colors
        /// <summary>
        /// console colors on program start
        /// </summary>
        public readonly ConsoleColors originalColors = ConsoleColors.current;


    //set default window position
        /// <summary>
        /// true to set the console window's position
        /// </summary>
        public virtual bool positionWindow => !inPrompt;

        /// <summary>
        /// horizontal position of the console window
        /// </summary>
        public virtual int xPos => 0;

        /// <summary>
        /// veritical position of the console window
        /// </summary>
        public virtual int yPos => 0;


    //default window size
        /// <summary>
        /// true to set the console window's size
        /// </summary>
        public virtual bool sizeWindow => !inPrompt;

        /// <summary>
        /// the console window's horizontal size (is limited by the maximum possible width)
        /// </summary>
        public virtual int xSize => 177;

        /// <summary>
        /// the console window's vertical size
        /// </summary>
        public virtual int ySize => 77;

        /// <summary>
        /// the console window's horizontal buffer size
        /// </summary>
        public virtual int xBuffer => xSize;

        /// <summary>
        /// the console window's vertical buffer size
        /// </summary>
        public virtual int yBuffer => 10000;


    //clear
        /// <summary>
        /// true to clear the screen before the program runs
        /// </summary>
        public virtual bool clear => ! inPrompt;


    //program runtime
        /// <summary>
        /// true to show the runtime in the title
        /// </summary>
        public  virtual bool  showRuntimeInTitle => true;

        /// <summary>
        /// how long the program has been running for
        /// </summary>
        public readonly AutoStopWatch runtime = new AutoStopWatch();

        //title runtime update timer
        private          Timer         titleUpdateTimer;



    //program
        /// <summary>
        /// override and put program code here
        /// </summary>
        public abstract int Code(string[] args);



    //setup
        /// <summary>
        /// does setup, then runs the program code
        /// </summary>
        public int Start(string[] args) {

            if (title != null) {
                Console.Title = "(Initializing...) " + title;
            }

            //save colors to revert to on exit



            if (clear) {
                Console.Clear();
            }


            //setup window
            if (positionWindow) {
                Konsole.SetWindowPosistion(xPos, yPos);
            }
            if (sizeWindow) {
                Konsole.TrySetWindowSize(xSize, ySize);
                Konsole.TrySetBufferSize(xBuffer, yBuffer);
            }


            //change title if desired
            if (title != null) {
                Console.Title = title;
            }


            //setup runtime counter in title if desired
            if (showRuntimeInTitle) {
                //update ever .777 seconds for a smooth second
                titleUpdateTimer = new Timer(UpdateTitleRuntime, null, 0, 777);
            }



            runtime.Start();

            //try and run program code
            int rc = 1; //default to error
            try {
                rc = Code(args);
            } catch (Exception ex) {
                Konsole.WriteLine(CC.RED, "\r\n\r\n" + ex.ToStringUnrolled());
            }

            runtime.Stop();

            //dispose title runtime timer
            titleUpdateTimer.IfNotNull(t => {
                t.Change(7777777, 7777777);
                t.Dispose();
            });


            // prevent window from closing TODO add as option
            if (!inPrompt) {
                Console.WriteLine();
                Console.WriteLine();

                Konsole.Write(CC.DARKGRAY, "Press any key to exit...");
                Console.ReadKey();
            }


            //revert title and colors
            Console.Title = originalTitle;
            Konsole.Color(originalColors);

            return rc;
        }

        private void UpdateTitleRuntime(object state) {
            Console.Title = "(" + runtime.Elapsed.ToString(hideEmptyHours:true) + ") " +  title;
        }

    }
}