using System;
using System.Collections.Generic;
using System.IO;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary.Assets.Bases
{
	public class LODLevel
	{
		public long Size;

		public long Offset;

		public int BoneDataCount;

		public int Unknown02;

		public int NumSubObjects;

		public List<LODSubObject> SubObjects;

		public int Unknown03;

		public long[] DataOffsets;

		public int[] DataValues;

		public byte[] DataActualValues;

		public int Unknown04;

		public int IndexBufferSize;

		public int VertexBufferSize;

		public int Unknown05;

		public Guid ChunkID;

		public int InlineDataOffset;

		public int Unknown07;

		public int Unknown08;

		public string String01;

		public string String02;

		public string String03;

		public int NameHash;

		public int Unknown10;

		public int Unknown11;

		public int BoneCount;

		public int Unknown13;

		public List<long> BoneData;

		public List<byte[]> BoneDataValues;

		private Mesh ParentMesh;

		internal void Serialize(BinaryReader Reader, Mesh InMesh)
		{
			ParentMesh = InMesh;
			Offset = Reader.BaseStream.Position;
			BoneDataCount = Reader.ReadInt32();
			Unknown02 = Reader.ReadInt32();
			NumSubObjects = Reader.ReadInt32();
			long num = Reader.ReadInt64();
			Unknown03 = Reader.ReadInt32();
			DataOffsets = new long[4];
			DataValues = new int[4];
			for (int i = 0; i < 4; i++)
			{
				DataOffsets[i] = Reader.ReadInt64();
				DataValues[i] = Reader.ReadInt32();
			}
			Unknown04 = Reader.ReadInt32();
			IndexBufferSize = Reader.ReadInt32();
			VertexBufferSize = Reader.ReadInt32();
			Unknown05 = Reader.ReadInt32();
			ChunkID = Reader.ReadGuid();
			InlineDataOffset = Reader.ReadInt32();
			Unknown07 = Reader.ReadInt32();
			Unknown08 = Reader.ReadInt32();
			String01 = SerializeString(Reader);
			String02 = SerializeString(Reader);
			String03 = SerializeString(Reader);
			NameHash = Reader.ReadInt32();
			Unknown10 = Reader.ReadInt32();
			Unknown11 = Reader.ReadInt32();
			BoneCount = Reader.ReadInt32();
			BoneData = new List<long>();
			BoneDataValues = new List<byte[]>();
			for (int j = 0; j < BoneDataCount; j++)
			{
				BoneData.Add(Reader.ReadInt64());
				BoneData.Add(Reader.ReadInt64());
			}
			Unknown13 = Reader.ReadInt32();
			SubObjects = new List<LODSubObject>();
			byte[] chunkData = PayloadProvider.GetAssetPayload(Library.GetChunkById(ChunkID));
			if (chunkData != null)
			{
				using (MemoryStream ms = new MemoryStream(chunkData))
				{
					using (BinaryReader binaryReader = new BinaryReader(ms))
					{
						if (NumSubObjects > 0)
						{
							Reader.BaseStream.Seek(num, SeekOrigin.Begin);
							for (int k = 0; k < NumSubObjects; k++)
							{
								LODSubObject dAISubObject = new LODSubObject();
								dAISubObject.Serialize(Reader, binaryReader, this);
								SubObjects.Add(dAISubObject);
							}
						}
						binaryReader.Close();
					}
				}
			}
			for (int l = 0; l < NumSubObjects && l < SubObjects.Count; l++)
			{
				if (SubObjects[l].Unknown05 > 0)
				{
					int unknown4 = SubObjects[l].Unknown04 >> 24;
					SubObjects[l].SubBoneList = new ushort[unknown4];
					Reader.BaseStream.Seek(SubObjects[l].Unknown05, SeekOrigin.Begin);
					for (int m = 0; m < unknown4; m++)
					{
						SubObjects[l].SubBoneList[m] = Reader.ReadUInt16();
					}
				}
			}
		}

		public string SerializeString(BinaryReader Reader)
		{
			long num = Reader.ReadInt64();
			long position = Reader.BaseStream.Position;
			Reader.BaseStream.Seek(num, SeekOrigin.Begin);
			string result = Reader.ReadNullTerminatedString();
			Reader.BaseStream.Seek(position, SeekOrigin.Begin);
			return result;
		}
	}
}
