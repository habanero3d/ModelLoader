using System;
using System.Text;
using ModelLoader.Common;
using System.IO;
using ModelLoader.Meshes;

namespace ModelLoader.TMF
{
    public class TMF
    {
        public uint Signature { get; set; }
        public static readonly uint TMFSignature = BitConverter.ToUInt32((new ASCIIEncoding()).GetBytes("TMF2"), 0);
        public Mesh<Vertex> Mesh { get; set; }
        public BoundingVolume.BoundingVolumeType Type { get { return Bv.Type; } }
        public BoundingVolume Bv { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.TMF.TMF"/> class.
        /// and reads content from given BinaryReader.
        /// </summary>
        public TMF(BinaryReader br)
        {
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            Signature = br.ReadUInt32();
            if (Signature != TMFSignature)
                throw new FileLoadException("Bad signature");
            Mesh = new Mesh<Vertex>(br);
            Bv = BoundingVolume.Read(br);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("TMF file {\n").Append(Mesh).AppendLine().Append(Bv).AppendLine().Append("}");
            return sb.ToString();
        }
    }
}