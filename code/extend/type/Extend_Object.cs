//Copyright © 2014 kt@katbyte.me
using System;



namespace katbyte.extend {

    /// <summary>
    /// Container class for Object Extensions
    /// </summary>
    public static class Extend_Object {


        /// <summary>
        /// performs an action if this object is null and then returns this
        /// </summary>
        public static T IfNull<T>(this T o, Action action) where T : class {
            if(o == null) {
                action();
            }

            return o;
        }


        /// <summary>
        /// if the object is null it calls the function and returns the result, otherwise it returns the object
        /// </summary>
        public static T IfNull<T>(this T o, Func<T> func) where T : class {
            if(o == null) {
                return func();
            }

            return o;
        }


        /// <summary>
        /// Performs the action on the object if it is not null
        /// </summary>
        public static T IfNotNull<T>(this T o,  Action<T> action) where T : class {
            if(o != null) {
                action(o);
            }

            return o;
        }
    }
}
