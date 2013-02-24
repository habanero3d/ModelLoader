using System.IO;

namespace ModelLoader.SAF
{
    public class SkeletonJointKeyframe
    {
        public float BeginTime { get; set; }
        public RTF Pose { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.SAF.SkeletonJointKeyframe"/> class
        /// and reads content from given BinaryReader.
        /// </summary>
        public SkeletonJointKeyframe(BinaryReader br)
        {
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            BeginTime = br.ReadSingle();
            Pose = new RTF(br);
        }
    }
}