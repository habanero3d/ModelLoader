using System;
using System.Collections.Generic;
using System.IO;

namespace ModelLoader.Meshes
{
    public class SubMesh : ICloneable, IWriteable
    {
        public uint MaterialId { get; set; }
        public uint NumIndices { get { return (uint) Indices.Count; } }
        public List<uint> Indices { get; protected set; }

        public SubMesh()
        {
            Indices = new List<uint>();
        }

        public SubMesh(uint materialId, List<uint> indices)
        {
            MaterialId = materialId;
            Indices = indices;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubMesh"/> class
        /// and reads content from given BinaryReader.
        /// </summary>
        public SubMesh(BinaryReader br) : this()
        {
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            MaterialId = br.ReadUInt32();
            var numIndices = br.ReadUInt32();
            for (var i = 0; i < numIndices; i++)
            {
                Indices.Add(br.ReadUInt32());
            }
        }

        /// <summary>
        /// Writes object data to given BinaryWriter.
        /// </summary>
        /// <param name="bw"></param>
        public void Write(BinaryWriter bw)
        {
            bw.Write(MaterialId);
            bw.Write(NumIndices);
            for (var i = 0; i < NumIndices; i++)
            {
                bw.Write(Indices[i]);
            }
        }

        #region Implementation of ICloneable
        /// <summary>
        /// Returns deep copy of the object.
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            SubMesh result = new SubMesh();
            result.MaterialId = MaterialId;
            for (int i = 0; i < Indices.Count; i++ )
                result.Indices.Add(Indices[i]);
            return result;
        }
        #endregion
    }
}