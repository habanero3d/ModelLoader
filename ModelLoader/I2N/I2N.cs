using System;
using System.Collections.Generic;
using System.IO;

namespace ModelLoader.I2N
{
	public class I2N
	{
		public Dictionary<uint, string> Materials { get; private set; }
		public Dictionary<uint, string> Textures { get; private set; }
		public Dictionary<uint, string> Skeleton { get; private set; }
		public Dictionary<uint, string> Joints { get; private set; }
		public Dictionary<uint, string> Animations { get; private set; }

		public I2N()
		{
			Materials = new Dictionary<uint, string>();
			Textures = new Dictionary<uint, string>();
			Skeleton = new Dictionary<uint, string>();
			Joints = new Dictionary<uint, string>();
			Animations = new Dictionary<uint, string>();
		}

		public I2N(TextReader tr) : this()
		{
			Read(tr);
		}

		public void Read(TextReader tr)
		{
			string line;
			Dictionary<uint, string> context = null;
			while ((line = tr.ReadLine()) != null) 
			{
				switch (line)
				{
					case "#materials":
						context = Materials;
						break;
					case "#textures":
						context = Textures;
						break;
					case "#skeleton":
						context = Skeleton;
						break;
					case "#joints":
						context = Joints;
						break;
					case "#animations":
						context = Animations;
						break;
					default:
						if (context == null)
							throw new FormatException(string.Format("Section start expected, but {0} found.", line));
						var words = line.Split(new[] { ". " }, StringSplitOptions.None);
						if (words.Length != 2)
							throw new FormatException(string.Format("Cannot read line {0}.", line));
						var number = uint.Parse(words[0]);
						context[number] = words[1];
						break;
				}
			}
		}

		public void Write(TextWriter tw)
		{
			if (Materials.Count > 0)
			{
				tw.WriteLine("#materials");
				foreach (var material in Materials)
				{
					tw.WriteLine(string.Format("{0}. {1}", material.Key, material.Value));
				}
			}
			if (Textures.Count > 0)
			{
				tw.WriteLine("#textures");
				foreach (var texture in Textures)
				{
					tw.WriteLine(string.Format("{0}. {1}", texture.Key, texture.Value));
				}
			}
			if (Skeleton.Count > 0)
			{
				tw.WriteLine("#skeleton");
				foreach (var skeleton in Skeleton)
				{
					tw.WriteLine(string.Format("{0}. {1}", skeleton.Key, skeleton.Value));
				}
			}
			if (Joints.Count > 0)
			{
				tw.WriteLine("#joints");
				foreach (var joints in Joints)
				{
					tw.WriteLine(string.Format("{0}. {1}", joints.Key, joints.Value));
				}
			}
			if (Animations.Count > 0)
			{
				tw.WriteLine("#animations");
				foreach (var animation in Animations)
				{
					tw.WriteLine(string.Format("{0}. {1}", animation.Key, animation.Value));
				}
			}
		}
	}
}