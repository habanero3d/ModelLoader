using System.IO;

namespace ModelLoader.Common
{
    public class QuaternionF
    {
        public float W { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.Common.QuaternionF"/> class
        /// and reads content from given BinaryReader.
        /// </summary>
        public QuaternionF(BinaryReader br)
        {
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            W = br.ReadSingle();
            X = br.ReadSingle();
            Y = br.ReadSingle();
            Z = br.ReadSingle();
        }
    }
}