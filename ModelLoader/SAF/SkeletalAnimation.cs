using System.Collections.Generic;
using System.IO;

namespace ModelLoader.SAF
{
    public class SkeletalAnimation
    {
        public readonly List<SkeletonJointKeyframeSequence> KeyframeSequences;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.SAF.SkeletalAnimation"/> class
        /// and reads content from given BinaryReader. Needs to know number of Joints.
        /// </summary>
        public SkeletalAnimation(BinaryReader br, uint numJoints)
        {
            KeyframeSequences = new List<SkeletonJointKeyframeSequence>();
            Read(br, numJoints);
        }

        /// <summary>
        /// Reads object data from given BinaryReader. Needs to know number of Joints.
        /// </summary>
        public void Read(BinaryReader br, uint numJoints)
        {
            for (var i = 0; i < numJoints; i++)
            {
                KeyframeSequences.Add(new SkeletonJointKeyframeSequence(br));
            }
        }
    }
}