using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ModelLoader.Meshes
{
    public class Mesh<T> : ICloneable where T : Vertex, new()
    {
        public uint NumVertices { get { return (uint) Vertices.Count; } }
        public uint NumSubMeshes { get { return (uint) SubMeshes.Count; } }
        public readonly List<T> Vertices;
        public readonly List<SubMesh> SubMeshes;

        public Mesh()
        {
            Vertices = new List<T>();
            SubMeshes = new List<SubMesh>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.TMF.StaticMesh"/> class.
        /// and reads content from given BinaryReader.
        /// </summary>
        public Mesh(BinaryReader br)
        {
            Vertices = new List<T>();
            SubMeshes = new List<SubMesh>();
            Read(br);
        }

        public Mesh(List<T> vertices, List<SubMesh> subMeshes)
        {
            Vertices = new List<T>(vertices);
            SubMeshes = new List<SubMesh>(subMeshes.Count);
            foreach (var staticSubMesh in subMeshes)
                SubMeshes.Add(staticSubMesh.Clone() as SubMesh);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            var numVertices = br.ReadUInt32();
            var numSubMeshes = br.ReadUInt32();
            for (var i = 0; i < numVertices; i++)
            {
                T read = new T();
                read.Read(br);
                Vertices.Add(read);
            }
            for (var i = 0; i < numSubMeshes; i++)
            {
                SubMeshes.Add(new SubMesh(br));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Static Mesh\nNumVertices\t").Append(NumVertices)
                .Append("\nNumSubMeshes\t").Append(NumSubMeshes).AppendLine();
            for (int i = 0; i < NumSubMeshes; i++)
                sb.Append(SubMeshes[i]).Append("\n");
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        /// <summary>
        /// Clones the object.
        /// The SubMeshes will be deep-cloned, the contents of Vertices list will be shared (but not the list itself).
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Mesh<T>(Vertices, SubMeshes);
        }
    }
}