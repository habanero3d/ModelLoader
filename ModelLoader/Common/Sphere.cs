using System.IO;

namespace ModelLoader.Common
{
    public class Sphere : BoundingVolume
    {
        public Vector3F Center { get; set; }
        public float Radius { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.Common.Sphere"/> class.
        /// and reads content from given BinaryReader.
        /// </summary>
        public Sphere(BinaryReader br)
        {
            Type = BoundingVolumeType.Sphere;
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public new void Read(BinaryReader br)
        {
            Center = new Vector3F(br);
            Radius = br.ReadSingle();
        }

        public override void Write(BinaryWriter binaryWriter)
        {
            base.Write(binaryWriter);
            Center.Write(binaryWriter);
            binaryWriter.Write(Radius);
        }

        public override string ToString()
        {
            return "Bounding Volume: Sphere\nCenter\t" + Center + "\nRadius\t" + Radius;
        }
    }
}