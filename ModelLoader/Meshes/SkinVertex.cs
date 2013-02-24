using System;
using System.IO;
using ModelLoader.Common;

namespace ModelLoader.Meshes
{
    public class SkinVertex : Vertex
    {
        public readonly uint[] JointIndices;
        public readonly float[] JointWeights;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkinVertex"/> class.
        /// This instance is broken until <see cref="Read"/> method is executed.
        /// </summary>
        public SkinVertex()
        {
            JointIndices = new uint[4];
            JointWeights = new float[4];
        }

        /// <summary>
        /// Creates new instance of SkinVertex.
        /// Does not clone given classes and arrays.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="normal"></param>
        /// <param name="texCoord"></param>
        /// <param name="jointIndices"></param>
        /// <param name="jointWeights"></param>
        public SkinVertex(Vector3F position, Vector3F normal, Vector2F texCoord, uint[] jointIndices, float[] jointWeights) : base(position, normal, texCoord)
        {
            if(jointIndices.Length != 4 || jointWeights.Length != 4)
                throw new Exception("Incorrect length of jointIndices or jointWeights");
            JointIndices = jointIndices;
            JointWeights = jointWeights;
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public override void Read(BinaryReader br)
        {
            base.Read(br);
            for (var i = 0; i < 4; i++)
            {
                JointIndices[i] = br.ReadUInt32();
            }
            for (var i = 0; i < 4; i++)
            {
                JointWeights[i] = br.ReadSingle();
            }
        }

        public override void Write(BinaryWriter bw)
        {
            base.Write(bw);
            for(var i = 0; i < 4; i++)
                bw.Write(JointIndices[i]);
            for (var i = 0; i < 4; i++)
                bw.Write(JointWeights[i]);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            SkinVertex o = (SkinVertex)obj;

            if (!base.Equals(obj))
                return false;

            if (JointIndices.Length != o.JointIndices.Length || JointWeights.Length != o.JointWeights.Length)
                return false;

            for (int i = 0; i < JointIndices.Length; i++)
                if (JointIndices[i] != o.JointIndices[i])
                    return false;

            for (int i = 0; i < JointWeights.Length; i++)
                if (JointWeights[i] != o.JointWeights[i])
                    return false;
            return true;
        }

        public override object Clone()
        {
            return new SkinVertex(Position.Clone() as Vector3F,
                Normal.Clone() as Vector3F,
                TexCoord.Clone() as Vector2F,
                JointIndices.Clone() as uint[],
                JointWeights.Clone() as float[]);
        }
    }
}