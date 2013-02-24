using System;
using System.IO;

namespace ModelLoader.Common
{
    public abstract class BoundingVolume
    {
        public enum BoundingVolumeType : byte { AABB = 1, OBB, Sphere}
        public BoundingVolumeType Type { get; protected set; }

        /// <summary>
        /// Factory that reads object data from given BinaryReader
        /// and returns relevant BoundingVolume object.
        /// </summary>
        public static BoundingVolume Read(BinaryReader br)
        {
            var type = (BoundingVolumeType) br.ReadByte();
            switch (type)
            {
                case BoundingVolumeType.AABB:
                    return new AABB(br);
                case BoundingVolumeType.OBB:
                    return new OBB(br);
                case BoundingVolumeType.Sphere:
                    return new Sphere(br);
                default:
                    throw new IndexOutOfRangeException("There is no such Bounding Volume Type");
            }
        }

        public virtual void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write((byte)Type);
        }
    }
}