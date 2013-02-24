using System.IO;

namespace ModelLoader.Common
{
    public class Color4F : IWriteable
    {
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.Common.Color4F"/> class
        /// and reads content from given BinaryReader.
        /// </summary>
        public Color4F(BinaryReader br)
        {
            Read(br);
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:ModelLoader.Common.Color4F"/> class.
		/// </summary>
		public Color4F(float r, float g, float b, float a)
		{
			R = r;
			G = g;
			B = b;
			A = a;
		}

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            R = br.ReadSingle();
            G = br.ReadSingle();
            B = br.ReadSingle();
            A = br.ReadSingle();
        }

    	public void Write(BinaryWriter bw)
    	{
    		bw.Write(R);
			bw.Write(G);
			bw.Write(B);
			bw.Write(A);
    	}
    }
}