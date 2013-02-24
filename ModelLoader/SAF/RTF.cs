using System.IO;
using ModelLoader.Common;

namespace ModelLoader.SAF
{
    public class RTF
    {
        public QuaternionF Rotation { get; set; }
        public Vector3F Translation { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.SAF.RTF"/> class
        /// and reads content from given BinaryReader.
        /// </summary>
        public RTF(BinaryReader br)
        {
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            Rotation = new QuaternionF(br);
            Translation = new Vector3F(br);
        }
    }
}