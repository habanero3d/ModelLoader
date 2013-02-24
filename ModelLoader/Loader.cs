using System;
using System.IO;

namespace ModelLoader
{
    /// <summary>
    /// Factory class for loading files.
    /// </summary>
    public class Loader
    {
        /// <summary>
        /// Reads TMF file at given location.
        /// </summary>
        /// <param name="path">File location</param>
        /// <returns>TMF object representing read file.</returns>
        public static TMF.TMF GetTMF(String path)
        {
            using (var br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                return new TMF.TMF(br);
            }
        }

        /// <summary>
        /// Reads SMF file at given location.
        /// </summary>
        /// <param name="path">File location</param>
        /// <returns>SMF object representing read file.</returns>
        public static SMF.SMF GetSMF(String path)
        {
            using (var br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                return new SMF.SMF(br);
            }
        }

        /// <summary>
        /// Reads SAF file at given location.
        /// </summary>
        /// <param name="path">File location</param>
        /// <returns>SAF object representing read file.</returns>
        public static SAF.SAF GetSAF(String path)
        {
            using (var br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                return new SAF.SAF(br);
            }
        }

        /// <summary>
        /// Reads MTF file at given location.
        /// </summary>
        /// <param name="path">File location</param>
        /// <returns>MTF object representing read file.</returns>
        public static MTF.MTF GetMTF(String path)
        {
            using (var br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                return new MTF.MTF(br);
            }
        }

		/// <summary>
		/// Reads I2N file at given location.
		/// </summary>
		/// <param name="path">File location</param>
		/// <returns>I2N object representing read file.</returns>
		public static I2N.I2N GetI2N(String path)
		{
			using (var tr = new StreamReader(File.Open(path, FileMode.Open)))
			{
				return new I2N.I2N(tr);
			}
		}
    }
}
