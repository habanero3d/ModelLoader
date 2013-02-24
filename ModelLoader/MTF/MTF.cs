using System;
using System.IO;
using System.Text;
using ModelLoader.Common;

namespace ModelLoader.MTF
{
    public class MTF : IWriteable
    {
        public uint Signature { get; set; }
        public static readonly uint MTFSignature = BitConverter.ToUInt32((new ASCIIEncoding()).GetBytes("MTF2"), 0);
        private Flags _flags;
        [Flags]
        private enum Flags : uint
        {
            ColorAmbient =    1 << 0,
            ColorDiffuse =    1 << 1,
            ColorSpecular =   1 << 2,
            ColorEmissive =   1 << 3,
            Transparency =    1 << 4,
            TexNormal =       1 << 5,
            TexDisplacement = 1 << 6,
            TexMystery =   1 << 7
        }

        private bool GetFlag(Flags flag)
        {
            return (_flags & flag) == flag;
        }

        private void SetFlag(Flags flag, bool value)
        {
            if (value)
            {
                _flags |= flag;
            }
            else
            {
                _flags &= ~flag;
            }
        }

        public bool UseColorAmbient { get { return GetFlag(Flags.ColorAmbient); } set { SetFlag(Flags.ColorAmbient, value); } }
        public bool UseColorDiffuse { get { return GetFlag(Flags.ColorDiffuse); } set { SetFlag(Flags.ColorDiffuse, value); } }
        public bool UseColorSpecular { get { return GetFlag(Flags.ColorSpecular); } set { SetFlag(Flags.ColorSpecular, value); } }
        public bool UseColorEmissive { get { return GetFlag(Flags.ColorEmissive); } set { SetFlag(Flags.ColorEmissive, value); } }
        public bool UseTransparency { get { return GetFlag(Flags.Transparency); } set { SetFlag(Flags.Transparency, value); } }
        public bool UseTexNormal { get { return GetFlag(Flags.TexNormal); } set { SetFlag(Flags.TexNormal, value); } }
        public bool UseTexDisplacement { get { return GetFlag(Flags.TexDisplacement); } set { SetFlag(Flags.TexDisplacement, value); } }
        public bool UseTexMystery { get { return GetFlag(Flags.TexMystery); } set { SetFlag(Flags.TexMystery, value); } }
        public Color4F ColorAmbient { get; set; }
        public Color4F ColorDiffuse { get; set; }
        public Color4F ColorSpecular { get; set; }
        public Color4F ColorEmissive { get; set; }
        public float Transparency { get; set; }
        public uint TexAmbient { get; set; }
        public uint TexDiffuse{ get; set; }
        public uint TexSpecular { get; set; }
        public uint TexNormal { get; set; }
        public uint TexDisplacement { get; set; }
        public uint TexTransparency { get; set; }
        public uint TexMystery { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ModelLoader.MTF.MTF"/> class
        /// and reads content from given BinaryReader.
        /// </summary>
        public MTF(BinaryReader br)
        {
            _flags = 0;
            Read(br);
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:ModelLoader.MTF.MTF"/> class.
		/// </summary>
		public MTF()
		{
			_flags = 0;
		}

        /// <summary>
        /// Reads object data from given BinaryReader.
        /// </summary>
        public void Read(BinaryReader br)
        {
            Signature = br.ReadUInt32();
            if (Signature != MTFSignature)
                throw new FileLoadException("Bad signature");
            _flags = (Flags) br.ReadUInt32();
            if (UseColorAmbient)
                ColorAmbient = new Color4F(br);
            else
                TexAmbient = br.ReadUInt32();
            if (UseColorDiffuse)
                ColorDiffuse = new Color4F(br);
            else
                TexDiffuse = br.ReadUInt32();
            if (UseColorSpecular)
                ColorSpecular = new Color4F(br);
            else
                TexSpecular = br.ReadUInt32();
            if (UseColorEmissive)
                ColorEmissive = new Color4F(br);
            if (UseTransparency)
                Transparency = br.ReadSingle();
            else
                TexTransparency = br.ReadUInt32();
            if (UseTexNormal)
                TexNormal = br.ReadUInt32();
            if (UseTexDisplacement)
                TexDisplacement = br.ReadUInt32();
            if (UseTexMystery)
                TexMystery = br.ReadUInt32();
        }

    	public void Write(BinaryWriter bw)
    	{
    		bw.Write(MTFSignature);
			bw.Write((uint) _flags);
			if (UseColorAmbient)
				ColorAmbient.Write(bw);
			else
				bw.Write(TexAmbient);
			if (UseColorDiffuse)
				ColorDiffuse.Write(bw);
			else
				bw.Write(TexDiffuse);
			if (UseColorSpecular)
				ColorSpecular.Write(bw);
			else
				bw.Write(TexSpecular);
			if (UseColorEmissive)
				ColorEmissive.Write(bw);
			if (UseTransparency)
				bw.Write(Transparency);
			else
				bw.Write(TexTransparency);
			if (UseTexNormal)
				bw.Write(TexNormal);
			if (UseTexDisplacement)
				bw.Write(TexDisplacement);
			if (UseTexMystery)
				bw.Write(TexMystery);
    	}
    }
}