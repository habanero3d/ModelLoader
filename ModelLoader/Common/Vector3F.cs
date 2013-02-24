using System;
using System.IO;

namespace ModelLoader.Common
{
    public class Vector3F : ICloneable
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.Common.Vector3F"/> class.
        /// and reads content from given BinaryReader.
        /// </summary>
        public Vector3F(BinaryReader br)
        {
            Read(br);
        }

        public Vector3F(params float[] coords)
        {
            X = coords[0];
            Y = coords[1];
            Z = coords[2];
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            X = br.ReadSingle();
            Y = br.ReadSingle();
            Z = br.ReadSingle();
        }

        public void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(X);
            binaryWriter.Write(Y);
            binaryWriter.Write(Z);
        }

        public override string ToString()
        {
            return X + ", " + Y + ", " + Z;
        }

        public static Vector3F operator -(Vector3F other)
        {
            return new Vector3F(-other.X, -other.Y, -other.Z);
        }

        public static Vector3F operator -(Vector3F l, Vector3F r)
        {
            return new Vector3F(l.X - r.X, l.Y - r.Y, l.Z - r.Z);
        }

        public float Length()
        {
            return (float) System.Math.Sqrt(X * X + Y * Y + Z*Z);
        }

        public static float Dot(Vector3F l, Vector3F r)
        {
            return r.X * l.X + r.Y * l.Y + r.Z * l.Z;
        }

        public static Vector3F Cross(Vector3F l, Vector3F r)
        {
            return new Vector3F(
                l.Y * r.Z - l.Z * r.Y,
                l.Z * r.X - l.X * r.Z,
                l.X * r.Y - l.Y * r.X);
        }

        public static Vector3F Min(Vector3F l, Vector3F r)
        {
            return new Vector3F(
                l.X < r.X ? l.X : r.X,
                l.Y < r.Y ? l.Y : r.Y,
                l.Z < r.Z ? l.Z : r.Z
            );
        }

        public static Vector3F Max(Vector3F l, Vector3F r)
        {
            return new Vector3F(
                l.X > r.X ? l.X : r.X,
                l.Y > r.Y ? l.Y : r.Y,
                l.Z > r.Z ? l.Z : r.Z
            );
        }

        public Vector3F Normalized()
        {
            float l = Length();
            return new Vector3F(X / l, Y / l, Z / l);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Vector3F o = (Vector3F)obj;

            return (Equals(X, o.X) && Equals(Y, o.Y) && Equals(Z, o.Z));
        }

        public override int GetHashCode()
        {
            return 11*X.GetHashCode() + 13*Y.GetHashCode() + 17*Z.GetHashCode();
        }

        /// <summary>
        /// Returns deep copy of the Vector.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Vector3F(X, Y, Z);
        }
    }
}