using System.IO;

namespace ModelLoader.Common
{
    public class OBB : BoundingVolume
    {
        public Vector3F Center { get; set; }
        public Vector3F Ox { get; set; }
        public Vector3F Oy { get; set; }
        public Vector3F Oz { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.Common.OBB"/> class.
        /// and reads content from given BinaryReader.
        /// </summary>
        public OBB(BinaryReader br)
        {
            Type = BoundingVolumeType.OBB;
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public new void Read(BinaryReader br)
        {
            Center = new Vector3F(br);
            Ox = new Vector3F(br);
            Oy = new Vector3F(br);
            Oz = new Vector3F(br);
        }

        public override void Write(BinaryWriter binaryWriter)
        {
            base.Write(binaryWriter);
            Center.Write(binaryWriter);
            Ox.Write(binaryWriter);
            Oy.Write(binaryWriter);
            Oz.Write(binaryWriter);
        }

        public override string ToString()
        {
            return "Bounding Volume: OBB\nCenter\t" + Center + "\nRight\t" + Ox + "\nUp\t" + Oy + "\nDeep\t" + Oz;
        }
    }
}