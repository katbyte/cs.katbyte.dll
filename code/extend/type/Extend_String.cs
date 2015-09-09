//Copyright © 2014 kt@katbyte.me
using System;
using System.Linq;
using System.Collections.Generic;



namespace katbyte.extend {

    /// <summary>
    /// Container class for String Extensions
    /// </summary>
    public static class Extend_String {

        //actually using regions here because this file is going to get lonnnnnng

        #region interning

            /// <summary>
            /// string.Intern() shortcut
            /// </summary>
            public static string Intern (this string str) {
                return string.Intern(str);
            }


            /// <summary>
            /// Interns multiple strings by calling string.Intern() on each and returning the result.
            /// </summary>
            public static IEnumerable<string> InternStrings (this IEnumerable<string> strings) {
                return strings.Select(string.Intern);
            }

        #endregion



        #region checks

            /// <summary>
            /// Checks if this string is null or empty.
            /// </summary>
            public static bool IsNullOrEmpty(this string s) {
                return string.IsNullOrEmpty(s);
            }

            /// <summary>
            /// Checks if this string is null or empty or whitespace.
            /// </summary>
            public static bool IsNullOrEmptyOrWhiteSpace(this string s) {
                #if DOTNET_35
                    return string.IsNullOrEmpty(s.Trim());
                #else
                    return string.IsNullOrWhiteSpace(s);
                #endif
            }


            /// <summary>
            /// Returns the string except if its null or empty, then the replacement is returned.
            /// </summary>
            public static string IfNullOrEmpty(this string s, string replacement) {
                return s.IsNullOrEmpty() ? replacement : s;
            }

            /// <summary>
            /// Returns the string except if its null or empty, then the replacement is returned
            /// </summary>
            public static string IfNullOrEmptyOrWhiteSpace(this string s, string replacement) {
                return s.IsNullOrEmptyOrWhiteSpace() ? replacement : s;
            }

        #endregion



        #region string formatting

            /// <summary>
            /// formats the string with the provided arguments
            /// </summary>
            public static string FormatIt(this string s, params object[] objs) {
                return string.Format(s, objs);
            }

        #endregion


        #region remove string

            /// <summary>
            /// returns str with all occurrences of 'pattern' removed. equates to str.Replace(pattern, "");
            /// </summary>
            public static string Remove(this string str, string pattern) {
                return str.Replace(pattern, "");
            }

            /// <summary>
            /// returns str with the pattern removed from the end if it is there
            /// </summary>
            public static string RemoveFromEnd(this string str, string pattern) {
                return str.EndsWith(pattern) ? str.Substring(0, str.LastIndexOf(pattern)) : str;
            }

            /// <summary>
            /// returns str with the pattern removed from the end if it is there
            /// </summary>
            public static string RemoveFromStart(this string str, string pattern) {
                return str.StartsWith(pattern) ? str.Remove(0, pattern.Length) : str;
            }

        #endregion

        /// <summary>
        /// Joins a collection of strings together using a string separator (" " as the default
        /// </summary>
        /// <remarks>
        /// created because it looks nicer then String.Join() and can be used on enumerables
        /// </remarks>
        public static string Join(this IEnumerable<string> strings, string sep = " ") {
            return String.Join(sep, strings.ToArray()); //.ToArray() is required for 3.5
        }


    }
}