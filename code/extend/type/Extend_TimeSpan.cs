//Copyright © 2014 kt@katbyte.me
using System;



namespace katbyte.extend {
   
    /// <summary>
    /// Container class for TimeSpan Extensions
    /// </summary>
    public static class Extensions_TimeSpan {


        /// <summary>
        /// More customizable TimeSpan ToString(), primarily written to hide empty hours.
        /// </summary>
        public static string ToString(this TimeSpan span, bool showSecond10ths = false, bool hideEmptyHours = false) {
             string format = span.Days > 0 ? "{0} days " : "";

            format += (span.Days > 0 || span.Hours > 0 || ! hideEmptyHours ) ? "{1:00}:" : "";
            format += "{2:00}:{3:00}";
            format += showSecond10ths ? ".{4:00}" : "";
            
            return format.FormatIt(span.Days, span.Hours, span.Minutes, span.Seconds, span.Milliseconds / 10);
        }
    }
}
