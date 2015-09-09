//Copyright © 2014 kt@katbyte.me
using System;
using System.Collections.Generic;
using System.Linq;
using katbyte.extend;

namespace katbyte.console {


    /// <summary>
    /// A container for a string and console fore and back colors.
    /// </summary>
    public class CT {

    //data
        /// <summary>
        /// The text.
        /// </summary>
        protected string _text;

        /// <summary>
        /// The colors (can be null for plain ol text)
        /// </summary>
        protected ConsoleColors _colors;



    //accessors
        /// <summary>
        /// The text.
        /// </summary>
        public virtual string text => _text;


        /// <summary>
        /// The colours.
        /// </summary>
        public virtual ConsoleColors colors => _colors;


        /// <summary>
        /// The forground color
        /// </summary>
        public virtual ConsoleColor? fore => _colors == null ? null : colors.fore;


        /// <summary>
        /// The background color
        /// </summary>
        public virtual ConsoleColor? back => _colors == null ? null : colors.back;



    //constructor
        /// <summary>
        /// Constructor to just assigns values.
        /// </summary>
        public CT(string text, ConsoleColor? fore = null, ConsoleColor? back = null) {
            _text = text;
            _colors = new ConsoleColors(fore, back);
        }


    //static helper function
        /// <summary>
        /// static healper function for creating new CTs
        /// </summary>
        public static CT N(string text, ConsoleColor? fore = null, ConsoleColor? back = null) {
            return new CT(text, fore, back);
        }
    }




    /// <summary>
    /// extension methods for CT objects
    /// </summary>
    public static class Extend_CT {

        /// <summary>
        /// returns the text for a set of CT objects
        /// </summary>
        public static string Text(this IEnumerable<CT> cts, string seperator ="") {
            return cts.Select(ct => ct.text).Join(seperator);
        }

    }
}