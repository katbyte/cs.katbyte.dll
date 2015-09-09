//Copyright © 2015 kt@katbyte.me
using System;
using System.IO;



namespace katbyte.extend {

    /// <summary>
    /// katbyte path utility ckass
    /// </summary>
    public static class KPath {


        /// <summary>
        /// ensures the path is rooted, if root is null current directory is used
        /// </summary>
        public static string EnsureRoot(string path, string root = null) {
            if (Path.IsPathRooted(path)) {
                return path;
            }

            //trim root end and path start to ensure theres only a single \
            return ( root ?? Directory.GetCurrentDirectory() ).TrimEnd('\\') + "\\" + path.TrimStart('\\');
        }
    }
}
