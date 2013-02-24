using System;
using System.IO;
using System.Text;

namespace ModelLoader.HMF
{
	public class HMF : IWriteable
	{
		public uint Signature { get; set; }
		public static readonly uint HMFSignature = BitConverter.ToUInt32((new ASCIIEncoding()).GetBytes("HMF2"), 0);

		public HeightMap Mesh { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:ModelLoader.HMF.HMF"/> class.
		/// and reads content from given BinaryReader.
		/// </summary>
		public HMF(BinaryReader br)
		{
			Read(br);
		}

		public HMF(HeightMap hm)
		{
			Mesh = hm;
		}

		/// <summary>
		/// Reads object data from given BinaryReader.
		/// </summary>
		public void Read(BinaryReader br)
		{
			Signature = br.ReadUInt32();
			if (Signature != HMFSignature)
				throw new FileLoadException("Bad signature");
			Mesh = new HeightMap(br);
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(HMFSignature);
			Mesh.Write(bw);
		}
	}
}