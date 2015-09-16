//Copyright © 2015 kt@katbyte.me
using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Text.RegularExpressions;



namespace katbyte.extend {


    /// <summary>
    /// Container class for Exception Extensions
    /// </summary>
    public static class Extend_Exception {

        //regex for removing paths from line numbers
        private readonly static Regex           regexReplaceFolder      = new Regex(@"\) in [a-zA-Z]:\\.*\\", RegexOptions.Compiled);
        private readonly static MatchEvaluator  regexReplaceFolderEval  = match =>  ") @ ";


        /// <summary>
        /// unrolls and converts an exception to a string with an optional message
        /// </summary>
        public static string ToStringUnrolled(this Exception ex) {

            //if ex is null, throw
            if (ex == null) {
                throw new ArgumentNullException(nameof(ex));
            }

            //setup newline string
            string nl = "\r\n";

            //start with unrolled inner exceptions
            string msg = UnrollInnnerExceptions(ex, "", nl) + nl + "########## EXCEPTION LOGGED HERE ##############" + nl;


            //add current stack
            string prefix = "";
            StackFrame[] frames = new StackTrace().GetFrames();
            if ( frames != null ) {
                foreach ( var frame in frames.Skip(1) ) {
                    MethodBase m = frame.GetMethod();

                    //ignore methods we can't load
                    if ( m == null || m.DeclaringType == null || m.DeclaringType.FullName == null ) {
                        msg = msg + "Unknown method" + nl;
                        continue;
                    }


                    msg = msg + "   " + m.DeclaringType.FullName + "." + m.Name + "(" + string.Join(",", m.GetParameters().Select(p => p.ParameterType.Name + " " + p.Name).ToArray()) + ")" + nl;
                }
            }

            //create full message
            msg = prefix + msg;

            return msg;
        }


        /// <summary>
        /// private function for unrolling nested exceptions
        /// </summary>
        private static string UnrollInnnerExceptions(Exception ex, string indent, string nl, int depth = 0) {
            if ( depth > 10 ) {
                throw new Exception("FormatExceptions Max Depth reached");
            }

            string exceptions = "";
            for ( Exception e = ex; e != null; e = e.InnerException ) {

                #if !DOTNET_35
                    //handle .net 4.0 and higher AggregateException type
                    var ae = e as AggregateException;

                    if (ae != null) {
                        foreach (var aie in ae.InnerExceptions) {
                            var aestack  = UnrollInnnerExceptions(aie, "    " + indent, nl, depth + 1);
                            exceptions = nl + indent + "#### " + e.GetType().Name + " => " + e.Message.Trim() + aestack + exceptions;
                        }

                        break;
                    }
                #endif


                string stack = regexReplaceFolder.Replace( e.StackTrace ?? "", regexReplaceFolderEval).Replace("at ", "" + indent).Replace(":line ", ":");
                exceptions = nl + indent + "#### " + e.GetType().Name + " => " + e.Message.Trim() + nl + stack + exceptions;

            }

            return exceptions;
        }
    }
}