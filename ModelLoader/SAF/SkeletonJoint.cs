using System.IO;

namespace ModelLoader.SAF
{
    public class SkeletonJoint
    {
        public uint ParentIndex { get; set; }
        public static uint NoParent = 0xFFFFFFFF;
        public RTF BindPose { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.SAF.SkeletonJoint"/> class
        /// and reads content from given BinaryReader.
        /// </summary>
        public SkeletonJoint(BinaryReader br)
        {
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            ParentIndex = br.ReadUInt32();
            BindPose = new RTF(br);
        }
    }
}