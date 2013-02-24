using System;
using System.IO;
using System.Text;

namespace ModelLoader.SAF
{
    public class SAF
    {
        public uint Signature { get; set; }
        public static readonly uint SAFSignature = BitConverter.ToUInt32((new ASCIIEncoding()).GetBytes("SAF2"), 0);
        public Skeleton Skeleton { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.SAF.SAF"/> class
        /// and reads content from given BinaryReader.
        /// </summary>
        public SAF(BinaryReader br)
        {
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            Signature = br.ReadUInt32();
            if (Signature != SAFSignature)
                throw new FileLoadException("Bad signature");
            Skeleton = new Skeleton(br);
        }
    }
}