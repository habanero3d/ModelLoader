using System.IO;
using ModelLoader.Common;

namespace ModelLoader.SMF
{
    public class SkinVertex4
    {
        public Vector3F Position { get; set; }
        public Vector3F Normal { get; set; }
        public Vector2F TexCoord { get; set; }
        public readonly uint[] JointIndices;
        public readonly float[] JointWeights;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.SMF.SkinVertex4"/> class.
        /// and reads content from given BinaryReader.
        /// </summary>
        public SkinVertex4(BinaryReader br)
        {
            JointIndices = new uint[4];
            JointWeights = new float[4];
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            Position = new Vector3F(br);
            Normal = new Vector3F(br);
            TexCoord = new Vector2F(br);
            for (var i = 0; i < 4; i++)
            {
                JointIndices[i] = br.ReadUInt32();
            }
            for (var i = 0; i < 4; i++)
            {
                JointWeights[i] = br.ReadSingle();
            }
        }
    }
}