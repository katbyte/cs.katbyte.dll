//Copyright © 2014 kt@katbyte.me
using System;



namespace katbyte.data {

    /// <summary>
    /// represents a set of x and y coordinates
    /// </summary>
    public struct KPoint : IEquatable<KPoint> {

        /// <summary>
        /// x coordinate
        /// </summary>
        public readonly int x;

        /// <summary>
        /// y coordinate
        /// </summary>
        public readonly int y;



        /// <summary>
        /// creates a new KPoint with the specified values.
        /// </summary>
        public KPoint(int x = 0, int y = 0) {
            this.x = x;
            this.y = y;
        }


    //IEquatable
        /// <summary>
        /// returns true if this object is equal to other
        /// </summary>
        public override bool Equals(Object other) {
            return other is KPoint && Equals((KPoint) other);
        }

        /// <summary>
        /// returns true if this object is equal to other
        /// </summary>
        public bool Equals(KPoint other) {
            return x == other.x && y == other.y;
        }

    //hashcode
        /// <summary>
        /// returns the hashcode for this struct
        /// </summary>
        public override int GetHashCode() {
            return (x * 7).GetHashCode() ^ y.GetHashCode();
        }
    }
}