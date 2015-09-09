//Copyright © 2014 kt@katbyte.me



namespace katbyte.console {

    /// <summary>
    /// represents a set of x and y coordinates for the console
    /// </summary>
    public struct KPoint {

        /// <summary>
        /// x coordinate
        /// </summary>
        public readonly int x;

        /// <summary>
        /// y coordinate
        /// </summary>
        public readonly int y;



        /// <summary>
        /// creates a new Point with the specified values.
        /// </summary>
        public KPoint(int x = 0, int y = 0) {
            this.x = x;
            this.y = y;
        }

    }
}