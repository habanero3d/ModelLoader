using System;
using System.IO;
using System.Text;
using ModelLoader.Common;
using ModelLoader.Meshes;

namespace ModelLoader.SMF
{
    public class SMF
    {
        public uint Signature { get; set; }
        public static readonly uint SMFSignature = BitConverter.ToUInt32((new ASCIIEncoding()).GetBytes("SMF2"), 0);
        public uint SkeletonId { get; set; }
        public Mesh<SkinVertex> Mesh { get; set; }
        public BoundingVolume.BoundingVolumeType Type { get { return Bv.Type; } }
        public BoundingVolume Bv { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.SMF.SMF"/> class.
        /// and reads content from given BinaryReader.
        /// </summary>
        public SMF(BinaryReader br)
        {
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            Signature = br.ReadUInt32();
            if (Signature != SMFSignature)
                throw new FileLoadException("Bad signature");
            SkeletonId = br.ReadUInt32();
            Mesh = new Mesh<SkinVertex>(br);
            Bv = BoundingVolume.Read(br);
        }
    }
}