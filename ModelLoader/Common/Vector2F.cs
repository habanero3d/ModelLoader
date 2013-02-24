using System;
using System.IO;

namespace ModelLoader.Common
{
    public class Vector2F : ICloneable
    {
        public float X { get; set; }
        public float Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.Common.Vector2F"/> class.
        /// and reads content from given BinaryReader.
        /// </summary>
        public Vector2F(BinaryReader br)
        {
            Read(br);
        }

        public Vector2F(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            X = br.ReadSingle();
            Y = br.ReadSingle();
        }

        public void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(X);
            binaryWriter.Write(Y);
        }

        public static Vector2F operator -(Vector2F l, Vector2F r)
        {
            return new Vector2F(l.X - r.X, l.Y - r.Y);
        }

        public override string ToString()
        {
            return X + " " + Y;
        }

        public float Length()
        {
            return (float) Math.Sqrt(X*X + Y*Y);
        }

        public bool Equals(Vector2F other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.X.Equals(X) && other.Y.Equals(Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Vector2F)) return false;
            return Equals((Vector2F) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode()*397) ^ Y.GetHashCode();
            }
        }

        public object Clone()
        {
            return new Vector2F(X, Y);
        }
    }
}