using System;
using System.IO;
using ModelLoader.Common;

namespace ModelLoader.Meshes
{
    public class Vertex : IWriteable, ICloneable
    {
        public Vector3F Position { get; set; }
        public Vector3F Normal { get; set; }
        public Vector2F TexCoord { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vertex"/> class.
        /// This instance is broken until <see cref="Read"/> or <see cref="Init"/> is executed
        /// (or the properties are manually assigned).
        /// </summary>
        public Vertex()
        {
        }

        public Vertex(Vector3F position, Vector3F normal, Vector2F texCoord)
        {
            Init(position, normal, texCoord);
        }

        /// <summary>
        /// Used to initialize the Vertex using according data.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="normal"></param>
        /// <param name="texCoord"></param>
        public void Init(Vector3F position, Vector3F normal, Vector2F texCoord)
        {
            Position = position;
            Normal = normal;
            TexCoord = texCoord;
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public virtual void Read(BinaryReader br)
        {
            Position = new Vector3F(br);
            Normal = new Vector3F(br);
            TexCoord = new Vector2F(br);
        }

        public virtual void Write(BinaryWriter bw)
        {
            Position.Write(bw);
            Normal.Write(bw);
            TexCoord.Write(bw);
        }

        public override string ToString()
        {
            return Position.ToString() + " | " + Normal.ToString() + " | " + TexCoord.ToString();
        }

        public bool Equals(Vertex other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Position, Position) && Equals(other.Normal, Normal) && Equals(other.TexCoord, TexCoord);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Vertex)) return false;
            return Equals((Vertex) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Position != null ? Position.GetHashCode() : 0);
                result = (result*397) ^ (Normal != null ? Normal.GetHashCode() : 0);
                result = (result*397) ^ (TexCoord != null ? TexCoord.GetHashCode() : 0);
                return result;
            }
        }

        public virtual object Clone()
        {
            return new Vertex(Position.Clone() as Vector3F, Normal.Clone() as Vector3F, TexCoord.Clone() as Vector2F);
        }
    }
}