using System.Collections.Generic;
using System.IO;

namespace ModelLoader.SAF
{
    public class Skeleton
    {
        public uint NumJoints { get { return (uint) Joints.Count; } }
        public uint NumAnimations { get { return (uint) Animations.Count; } }
        public uint SkeletonId { get; set; }
        public readonly List<SkeletonJoint> Joints;
        public readonly List<SkeletalAnimation> Animations;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.SAF.Skeleton"/> class
        /// and reads content from given BinaryReader.
        /// </summary>
        public Skeleton(BinaryReader br)
        {
            Joints = new List<SkeletonJoint>();
            Animations = new List<SkeletalAnimation>();
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            var numJoints = br.ReadUInt32();
            var numAnimations = br.ReadUInt32();
            SkeletonId = br.ReadUInt32();
            for (var i = 0; i < numJoints; i++)
            {
                Joints.Add(new SkeletonJoint(br));
            }
            for (var i = 0; i < numAnimations; i++)
            {
                Animations.Add(new SkeletalAnimation(br, numJoints));
            }
        }
    }
}