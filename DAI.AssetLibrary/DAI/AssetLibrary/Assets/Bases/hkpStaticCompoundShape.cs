using System.Collections.Generic;
using System.IO;

namespace DAI.AssetLibrary.Assets.Bases
{
	public class hkpStaticCompoundShape : hkObject
	{
		public class hkpDomain
		{
			public Vector4 Max { get; set; }

			public Vector4 Min { get; set; }

			public void Serialize(BinaryReader Reader)
			{
				Min = new Vector4();
				Max = new Vector4();
				Min.X = Reader.ReadSingle();
				Min.Y = Reader.ReadSingle();
				Min.Z = Reader.ReadSingle();
				Min.W = Reader.ReadSingle();
				Max.X = Reader.ReadSingle();
				Max.Y = Reader.ReadSingle();
				Max.Z = Reader.ReadSingle();
				Max.W = Reader.ReadSingle();
			}
		}

		public class hkpInstance
		{
			public uint ChildFilterInfoMask { get; set; }

			public uint FilterInfo { get; set; }

			public Vector4 Rotation { get; set; }

			public Vector4 Scale { get; set; }

			public Vector4 Translation { get; set; }

			public uint UserData { get; set; }

			public void Serialize(BinaryReader Reader)
			{
				Translation = new Vector4
				{
					X = Reader.ReadSingle(),
					Y = Reader.ReadSingle(),
					Z = Reader.ReadSingle(),
					W = Reader.ReadSingle()
				};
				Rotation = new Vector4
				{
					X = Reader.ReadSingle(),
					Y = Reader.ReadSingle(),
					Z = Reader.ReadSingle(),
					W = Reader.ReadSingle()
				};
				Scale = new Vector4
				{
					X = Reader.ReadSingle(),
					Y = Reader.ReadSingle(),
					Z = Reader.ReadSingle(),
					W = Reader.ReadSingle()
				};
				Reader.ReadUInt32();
				FilterInfo = Reader.ReadUInt32();
				ChildFilterInfoMask = Reader.ReadUInt32();
				UserData = Reader.ReadUInt32();
			}
		}

		public class hkpTree
		{
			public hkpDomain Domain { get; set; }

			public List<hkpTreeNode> Nodes { get; set; }

			public void Serialize(BinaryReader Reader)
			{
				Nodes = new List<hkpTreeNode>();
				Domain = new hkpDomain();
				Reader.ReadInt32();
				Reader.BaseStream.Seek(8L, SeekOrigin.Current);
				Domain.Serialize(Reader);
			}
		}

		public class hkpTreeNode
		{
			public int HiData { get; set; }

			public int LoData { get; set; }

			public List<int> XYZ { get; set; }
		}

		public byte BitsPerKey { get; set; }

		public byte BvTreeType { get; set; }

		public byte DispatchType { get; set; }

		public List<hkpInstance> Instances { get; set; }

		public byte NumBitsForChildShapeKey { get; set; }

		public byte ShapeInfoCodecType { get; set; }

		public hkpTree Tree { get; set; }

		public uint UserData { get; set; }

		public override void Serialize(BinaryReader Reader)
		{
			Reader.BaseStream.Seek(9L, SeekOrigin.Current);
			DispatchType = Reader.ReadByte();
			BitsPerKey = Reader.ReadByte();
			ShapeInfoCodecType = Reader.ReadByte();
			UserData = Reader.ReadUInt32();
			BvTreeType = Reader.ReadByte();
			Reader.BaseStream.Seek(7L, SeekOrigin.Current);
			NumBitsForChildShapeKey = Reader.ReadByte();
			Reader.BaseStream.Seek(11L, SeekOrigin.Current);
			int num = Reader.ReadInt32();
			Reader.BaseStream.Seek(28L, SeekOrigin.Current);
			Tree = new hkpTree();
			Tree.Serialize(Reader);
			Reader.BaseStream.Seek(16L, SeekOrigin.Current);
			Instances = new List<hkpInstance>();
			for (int i = 0; i < num; i++)
			{
				hkpInstance _hkpInstance = new hkpInstance();
				_hkpInstance.Serialize(Reader);
				Instances.Add(_hkpInstance);
			}
		}
	}
}
