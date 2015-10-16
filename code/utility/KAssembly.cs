//Copyright © 2015 kt@katbyte.me
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

using katbyte.extend;



namespace katbyte.utility {

    /// <summary>
    /// class to get ALL possible information about an assembly
    /// </summary>
    public class KAssembly : IEquatable<KAssembly> {

    //properties
        /// <summary>
        /// path to the actual assembly
        /// </summary>
        public readonly string path;

        /// <summary>
        /// assemblies file name
        /// </summary>
        public readonly string file;

        /// <summary>
        /// the name of the assembly
        /// </summary>
        public readonly string name;

        /// <summary>
        /// the assemblies version, ie what is set by [assembly: AssemblyVersion("1.9.8.4")]
        /// </summary>
        public readonly string version;

        /// <summary>
        /// the assemblies file version, ie what is set by [assembly: AssemblyFileVersion("1.9.8.4")]
        /// </summary>
        public readonly string fileVersion;

        /// <summary>
        /// the assemblies product version, ie what is set by [assembly: AssemblyInformationalVersion("1.9.4.4 @ master (77777777)")]
        /// </summary>
        public readonly string productVersion;

        /// <summary>
        /// the date and time the assembly was built and linked
        /// </summary>
        public                DateTime   linkDate => _linkDate.Value;
        private readonly Lazy<DateTime> _linkDate; //lazy load because it opens the file and reads the PE header

        /// <summary>
        /// Assembly object for this assembly
        /// </summary>
        public                Assembly   assebmly => _assembly.Value;
        private readonly Lazy<Assembly> _assembly;

        /// <summary>
        /// assemblies configuration, ie debug vs release
        /// </summary>
        public                string   config => _config.Value;
        private readonly Lazy<string> _config;

        /// <summary>
        /// strong name for this assembly (string name if it has one)
        /// </summary>
        public                string   fullname => _fullname.Value;
        private readonly Lazy<string> _fullname;



    //constructors
        /// <summary>
        /// creates an KAssembly object from the assembly located at path
        /// </summary>
        public KAssembly (string path) {
            this.path = path;

            var fv = FileVersionInfo.GetVersionInfo(path);

            file           = fv.InternalName;
            name           = fv.InternalName.Replace(".dll", "");
            version        = AssemblyName.GetAssemblyName(path).Version.ToString();
            fileVersion    = fv.FileVersion;
            productVersion = fv.ProductVersion;


            _linkDate = new Lazy<DateTime>(GetLinkerTimestamp);
            _assembly = new Lazy<Assembly>(() => Assembly.LoadFrom(path));
            _fullname = new Lazy<string>(() => assebmly.FullName);
            _config   = new Lazy<string>(() => {
                var a = assebmly.GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false).OfType<AssemblyConfigurationAttribute>().FirstOrDefault();
                return a != null ? a.Configuration : "N/A";
            });
        }

        /// <summary>
        /// creates an KAssembly object from the given Assebmly object
        /// </summary>
        public KAssembly(Assembly a) : this(a.Location) {
            _assembly = new Lazy<Assembly>(() => a);
        }



    //helpers
        /// <summary>
        /// retrieving the build date by extracting the linker timestamp from the PE header embedded in the executable file
        /// </summary>
        private DateTime GetLinkerTimestamp () {

            //uses code from https://stackoverflow.com/questions/1600962/displaying-the-build-date

            const int peHeaderOffset        = 60;
            const int linkerTimestampOffset = 8;

            byte[] b = new byte[2048];
            Stream s = null;

            try {
                s = new FileStream(path, FileMode.Open, FileAccess.Read);
                s.Read(b, 0, 2048);
            } finally {
                if (s != null) {
                    s.Close();
                }
            }

            int secondsSince1970 = BitConverter.ToInt32(b, BitConverter.ToInt32(b, peHeaderOffset) + linkerTimestampOffset);

            return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(secondsSince1970).ToLocalTime();
        }




    //IEquatable

         /// <summary>
        /// returns true if this object is equal to other
        /// </summary>
        public override bool Equals(Object other) {
            return other is KAssembly && Equals((KAssembly) other);
        }

        /// <summary>
        /// returns true if this assemblies path matches the other
        /// </summary>
        public bool Equals(KAssembly other) {
            return path == other.path;
        }


        /// <summary>
        /// Returns a hashcode generated from the assemblies path
        /// </summary>
        public override int GetHashCode () {
            return path.GetHashCode(); //same assembly in different paths wont' match...
        }

    }
}