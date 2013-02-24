using System;
using System.IO;

namespace ModelLoader.Common
{
    public class AABB : BoundingVolume
    {
        public float Xmin { get; set; }
        public float Ymin { get; set; }
        public float Zmin { get; set; }
        public float Xmax { get; set; }
        public float Ymax { get; set; }
        public float Zmax { get; set; }

        public AABB(params float[] coords)
        {
            if(coords.Length != 6)
                throw new Exception();

            Type = BoundingVolumeType.AABB;

            Xmin = coords[0];
            Ymin = coords[1];
            Zmin = coords[2];
            Xmax = coords[3];
            Ymax = coords[4];
            Zmax = coords[5];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.Common.AABB"/> class.
        /// and reads content from given BinaryReader.
        /// </summary>
        public AABB(BinaryReader br)
        {
            Type = BoundingVolumeType.AABB;
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public new void Read(BinaryReader br)
        {
            Xmin = br.ReadSingle();
            Ymin = br.ReadSingle();
            Zmin = br.ReadSingle();
            Xmax = br.ReadSingle();
            Ymax = br.ReadSingle();
            Zmax = br.ReadSingle();
        }

        public override void Write(BinaryWriter binaryWriter)
        {
            base.Write(binaryWriter);
            binaryWriter.Write(Xmin);
            binaryWriter.Write(Ymin);
            binaryWriter.Write(Zmin);
            binaryWriter.Write(Xmax);
            binaryWriter.Write(Ymax);
            binaryWriter.Write(Zmax);
        }

        public override string ToString()
        {
            return "Bounding Volume: AABB\nmin: " + Xmin + ", " + Ymin + ", " + Zmin + "\nmax: " + Xmax + ", " + Ymax + ", " + Zmax;
        }

    }
}