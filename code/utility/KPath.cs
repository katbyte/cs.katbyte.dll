//Copyright © 2015 kt@katbyte.me
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using katbyte.extend;



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

        /// <summary>
        /// returns the paths of all files that can be found in a sequence of files and folder paths
        /// </summary>
        public static IEnumerable<string> GetAllFiles(IEnumerable<string> paths) {
            return paths.SelectMany(p => Directory.Exists(p) ? Directory.GetFiles(p, "*", SearchOption.AllDirectories) : p.Yield());
        }

        /// <summary>
        /// returns the paths of all files that can be found in a sequence of files and folder paths
        /// </summary>
        public static IEnumerable<string> GetAllFiles(params string[] paths) {
            return GetAllFiles((IEnumerable<string>)paths);
        }
    }
}