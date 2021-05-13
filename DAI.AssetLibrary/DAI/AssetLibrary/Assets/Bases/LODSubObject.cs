using System.Collections.Generic;
using System.IO;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary.Assets.Bases
{
	public class LODSubObject
	{
		public long Offset;

		public int Unknown01;

		public int Unknown02;

		public string SubObjectName;

		public int Unknown03;

		public int TriangleCount;

		public int StartIndex;

		public int VertexBufferOffset;

		public int VertexCount;

		public int VertexStride;

		public int Unknown04;

		public int Unknown05;

		public int Unknown06;

		public int[] Unknowns2;

		public ushort[] SubBoneList;

		public MeshBuffer MeshBuffer;

		public List<VertexEntry> VertexEntries;

		public Dictionary<int, string> VertexTypes = new Dictionary<int, string>
		{
			{ 769, "Position (Full Precision)" },
			{ 1793, "Position (Half Precision)" },
			{ 2054, "Normals" },
			{ 2055, "Tangents" },
			{ 2056, "Bitangents" },
			{ 1569, "Texture Coordinates" },
			{ 3074, "Bone Indices" },
			{ 3332, "Bone Weights" },
			{ 3358, "Vertex Colors" }
		};

		private void ReadChunk(BinaryReader ChunkReader, int IndexBufferOffset, float ScaleOverride = 1f)
		{
			MeshBuffer = new MeshBuffer();
			ChunkReader.BaseStream.Seek(VertexBufferOffset, SeekOrigin.Begin);
			for (int i = 0; i < VertexCount; i++)
			{
				long position = ChunkReader.BaseStream.Position;
				Vertex dAIVertex = new Vertex();
				foreach (VertexEntry vertexEntry in VertexEntries)
				{
					ChunkReader.BaseStream.Seek(position + vertexEntry.Offset, SeekOrigin.Begin);
					if (vertexEntry.VertexType == 769)
					{
						dAIVertex.Position.X = ChunkReader.ReadSingle() * ScaleOverride;
						dAIVertex.Position.Y = ChunkReader.ReadSingle() * ScaleOverride;
						dAIVertex.Position.Z = ChunkReader.ReadSingle() * ScaleOverride;
					}
					else if (vertexEntry.VertexType == 1793)
					{
						dAIVertex.Position.X = HalfUtils.Unpack(ChunkReader.ReadUInt16()) * ScaleOverride;
						dAIVertex.Position.Y = HalfUtils.Unpack(ChunkReader.ReadUInt16()) * ScaleOverride;
						dAIVertex.Position.Z = HalfUtils.Unpack(ChunkReader.ReadUInt16()) * ScaleOverride;
					}
					else if (vertexEntry.VertexType == 2054)
					{
						dAIVertex.Normals.X = HalfUtils.Unpack(ChunkReader.ReadUInt16());
						dAIVertex.Normals.Y = HalfUtils.Unpack(ChunkReader.ReadUInt16());
						dAIVertex.Normals.Z = HalfUtils.Unpack(ChunkReader.ReadUInt16());
					}
					else if (vertexEntry.VertexType == 2055)
					{
						dAIVertex.Tangents.X = HalfUtils.Unpack(ChunkReader.ReadUInt16());
						dAIVertex.Tangents.Y = HalfUtils.Unpack(ChunkReader.ReadUInt16());
						dAIVertex.Tangents.Z = HalfUtils.Unpack(ChunkReader.ReadUInt16());
					}
					else if (vertexEntry.VertexType == 2056)
					{
						dAIVertex.Bitangents.X = HalfUtils.Unpack(ChunkReader.ReadUInt16());
						dAIVertex.Bitangents.Y = HalfUtils.Unpack(ChunkReader.ReadUInt16());
						dAIVertex.Bitangents.Z = HalfUtils.Unpack(ChunkReader.ReadUInt16());
					}
					else if (vertexEntry.VertexType == 1569)
					{
						dAIVertex.TexCoords.X = HalfUtils.Unpack(ChunkReader.ReadUInt16());
						dAIVertex.TexCoords.Y = HalfUtils.Unpack(ChunkReader.ReadUInt16());
					}
					else if (vertexEntry.VertexType != 3074)
					{
						if (vertexEntry.VertexType == 3332)
						{
							dAIVertex.BoneWeights = new float[4];
							for (int j = 0; j < 4; j++)
							{
								dAIVertex.BoneWeights[j] = (float)(int)ChunkReader.ReadByte() / 255f;
							}
						}
					}
					else
					{
						dAIVertex.BoneIndices = new int[4];
						for (int k = 0; k < 4; k++)
						{
							dAIVertex.BoneIndices[k] = ChunkReader.ReadByte();
						}
					}
				}
				MeshBuffer.VertexBuffer.Add(dAIVertex);
				ChunkReader.BaseStream.Seek(position + VertexStride, SeekOrigin.Begin);
			}
			ChunkReader.BaseStream.Seek(IndexBufferOffset + StartIndex * 2, SeekOrigin.Begin);
			for (int l = 0; l < TriangleCount; l++)
			{
				FaceElement dAIFace = new FaceElement
				{
					V1 = ChunkReader.ReadUInt16(),
					V2 = ChunkReader.ReadUInt16(),
					V3 = ChunkReader.ReadUInt16()
				};
				MeshBuffer.IndexBuffer.Add(dAIFace);
			}
		}

		public void Serialize(BinaryReader Reader, BinaryReader ChunkReader, LODLevel LOD)
		{
			Offset = Reader.BaseStream.Position;
			Unknown01 = Reader.ReadInt32();
			Unknown02 = Reader.ReadInt32();
			SubObjectName = SerializeString(Reader);
			Unknown03 = Reader.ReadInt32();
			TriangleCount = Reader.ReadInt32();
			StartIndex = Reader.ReadInt32();
			VertexBufferOffset = Reader.ReadInt32();
			VertexCount = Reader.ReadInt32();
			Unknown04 = Reader.ReadInt32();
			Unknown05 = Reader.ReadInt32();
			Unknown06 = Reader.ReadInt32();
			VertexEntries = new List<VertexEntry>();
			for (int i = 0; i < 16; i++)
			{
				VertexEntry dAIVertexEntry = new VertexEntry
				{
					VertexType = Reader.ReadInt16(),
					Offset = Reader.ReadByte(),
					Unknown01 = Reader.ReadByte()
				};
				if (dAIVertexEntry.Offset != 255)
				{
					VertexEntries.Add(dAIVertexEntry);
				}
			}
			VertexStride = Reader.ReadInt32();
			Unknowns2 = new int[19];
			for (int j = 0; j < 19; j++)
			{
				Unknowns2[j] = Reader.ReadInt32();
			}
			ReadChunk(ChunkReader, LOD.VertexBufferSize);
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
