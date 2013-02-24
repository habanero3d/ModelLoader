using System.Collections.Generic;
using System.IO;

namespace ModelLoader.SAF
{
    public class SkeletonJointKeyframeSequence
    {
        public uint NumFrames { get { return (uint) Frames.Count; } }
        public readonly List<SkeletonJointKeyframe> Frames;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.SAF.SkeletonJointKeyframeSequence"/> class
        /// and reads content from given BinaryReader.
        /// </summary>
        public SkeletonJointKeyframeSequence(BinaryReader br)
        {
            Frames = new List<SkeletonJointKeyframe>();
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            var numFrames = br.ReadUInt32();
            for (var i = 0; i < numFrames; i++)
            {
                Frames.Add(new SkeletonJointKeyframe(br));
            }
        }
    }
}