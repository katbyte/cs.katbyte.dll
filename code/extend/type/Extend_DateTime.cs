//Copyright © 2014 kt@katbyte.me
using System;



namespace katbyte.extend {
   

    /// <summary>
    /// Container class for DateTime Extensions
    /// </summary>
    public static class Extend_DateTime {

        /// <summary>
        /// Converts the DateTime to an ISO formatted string: 1987/07/07 17:17
        /// </summary>
        public static string ToIso (this DateTime dt, string dateSep = "/", string timeSep = ":", string dateTimeSep = " ") {
            return dt.ToString("yyyy" + dateSep + "MM" + dateSep + "dd" + dateTimeSep + "HH" + timeSep + "mm" + timeSep + "ss");
        }

        /// <summary>
        /// Converts the DateTime to an ISO formatted time: 17:17
        /// </summary>
        public static string ToIsoTime (this DateTime dt, string timeSep = ":") {
            return dt.ToString("HH" + timeSep + "mm" + timeSep + "ss");
        }

        /// <summary>
        /// Converts the DateTime to an ISO formatted date: 1987/07/07
        /// </summary>
        public static string ToIsoDate (this DateTime dt, string dateSep = "/") {
            return dt.ToString("yyyy" + dateSep + "MM" + dateSep + "dd");
        }

     

        /// <summary>
        /// truncates the date to the specified timespan
        /// </summary>
        public static DateTime Truncate(this DateTime dateTime, TimeSpan timeSpan) {
            return dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));
        }

        /// <summary>
        /// truncates the date to the seconds: 17:18:19.345 -> 17:18:19
        /// </summary>
        public static DateTime TruncateToSeconds(this DateTime dateTime) {
            return dateTime.Truncate(TimeSpan.FromSeconds(1));
        }

        /// <summary>
        /// truncates the date to the minutes: 17:18:19.345 -> 17:18:00
        /// </summary>
        public static DateTime TruncateToMinutes(this DateTime dateTime) {
            return dateTime.Truncate(TimeSpan.FromMinutes(1));
        }

        /// <summary>
        /// truncates the date to the hours: 17:18:19.345 -> 17:00:00
        /// </summary>
        public static DateTime TruncateToHours(this DateTime dateTime) {
            return dateTime.Truncate(TimeSpan.FromHours(1));
        }
    }
}
