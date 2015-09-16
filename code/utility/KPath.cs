//Copyright © 2015 kt@katbyte.me
using System.IO;



namespace katbyte.utility {

    /// <summary>
    /// katbyte path utility class
    /// </summary>
    public static class KPath {


        /// <summary>
        /// ensures the path is rooted, if root is null current directory is used
        /// </summary>
        public static string EnsureRooted(string path, string root = null) {
            if (Path.IsPathRooted(path)) {
                return path;
            }

            //trim root end and path start to ensure theres only a single \
            return ( root ?? Directory.GetCurrentDirectory() ).TrimEnd('\\') + "\\" + path.TrimStart('\\');
        }
    }
}
