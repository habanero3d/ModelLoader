using System.IO;

namespace ModelLoader.HMF
{
	public class HeightMap : IWriteable
	{
		public uint MaterialId { get; set; }
		public uint TextureId { get; set; }
		public float MaxHeight { get; set; }
		public uint Width { get; set; }
		public uint Height { get; set; }
		public float TexRepX { get; set; }
		public float TexRepY { get; set; }

		public HeightMap(uint materialId, uint textureId, float maxHeight, uint width, uint height, float texRepX, float texRepY)
		{
			MaterialId = materialId;
			TextureId = textureId;
			MaxHeight = maxHeight;
			Width = width;
			Height = height;
			TexRepX = texRepX;
			TexRepY = texRepY;
		}

		/// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.HMF.HMF"/> class.
        /// and reads content from given BinaryReader.
        /// </summary>
        public HeightMap(BinaryReader br)
        {
            Read(br);
        }

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
        	MaterialId = br.ReadUInt32();
			TextureId = br.ReadUInt32();
			MaxHeight = br.ReadSingle();
        	Width = br.ReadUInt32();
        	Height = br.ReadUInt32();
        	TexRepX = br.ReadSingle();
        	TexRepY = br.ReadSingle();
        }

		public void Write(BinaryWriter bw)
		{
			bw.Write(MaterialId);
			bw.Write(TextureId);
			bw.Write(MaxHeight);
			bw.Write(Width);
			bw.Write(Height);
			bw.Write(TexRepX);
			bw.Write(TexRepY);
		}
	}
}