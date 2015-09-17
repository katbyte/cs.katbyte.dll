//Copyright © 2014 kt@katbyte.me
using System;



namespace katbyte.data {

    /// <summary>
    /// container object for width and height
    /// </summary>
    public struct KSize : IEquatable<KSize> {


    //data
        /// <summary>
        /// width
        /// </summary>
        public readonly int w;

        /// <summary>
        /// height
        /// </summary>
        public readonly int h;


    //properties
        /// <summary>
        /// calculates and returns the area
        /// </summary>
        public int area => w * h;

        /// <summary>
        /// true if w and h are 0
        /// </summary>
        public bool empty => w == 0 && h == 0;


    //constructor
        /// <summary>
        /// creates a new KSize with the specified values
        /// </summary>
        public KSize(int w = 0, int h = 0) {
            this.w = w;
            this.h = h;
        }



    //IEquatable
        /// <summary>
        /// returns true if this object is equal to other
        /// </summary>
        public override bool Equals(Object other) {
            return other is KSize && Equals((KSize) other);
        }

        /// <summary>
        /// returns true if this object is equal to other
        /// </summary>
        public bool Equals(KSize other) {
            return w == other.w && h == other.h;
        }

    //hashcode
        /// <summary>
        /// returns the hashcode for this struct
        /// </summary>
        public override int GetHashCode() {
            return (w * 7).GetHashCode() ^ h.GetHashCode();
        }

    }
}