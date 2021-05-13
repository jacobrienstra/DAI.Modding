using System;
using System.Collections.Generic;
using System.IO;

namespace DAI.AssetLibrary.Assets.Bases
{
	public class PSKFile
	{
		public struct PSKBone
		{
			public string name;

			public int flags;

			public int childs;

			public int parent;

			public PSKQuad rotation;

			public PSKPoint location;

			public float length;

			public PSKPoint size;

			public int index;
		}

		public struct PSKEdge
		{
			public ushort index;

			public ushort padding1;

			public float U;

			public float V;

			public byte material;

			public byte reserved;

			public ushort padding2;

			public PSKEdge(ushort _index, float _U, float _V, byte _material)
			{
				index = _index;
				padding1 = 0;
				U = _U;
				V = _V;
				material = _material;
				reserved = 0;
				padding2 = 0;
			}

			public PSKEdge(ushort _index, Vector2 _UV, byte _material)
			{
				index = _index;
				padding1 = 0;
				U = _UV.X;
				V = _UV.Y;
				material = _material;
				reserved = 0;
				padding2 = 0;
			}
		}

		public struct PSKExtraUV
		{
			public float U;

			public float V;

			public PSKExtraUV(float _U, float _V)
			{
				U = _U;
				V = _V;
			}
		}

		public struct PSKFace
		{
			public int v0;

			public int v1;

			public int v2;

			public byte material;

			public byte auxmaterial;

			public int smoothgroup;

			public PSKFace(int _v0, int _v1, int _v2, byte _material)
			{
				v0 = _v0;
				v1 = _v1;
				v2 = _v2;
				material = _material;
				auxmaterial = 0;
				smoothgroup = 0;
			}
		}

		public struct PSKHeader
		{
			public string name;

			public int flags;

			public int size;

			public int count;
		}

		public struct PSKMaterial
		{
			public string name;

			public int texture;

			public int polyflags;

			public int auxmaterial;

			public int auxflags;

			public int LODbias;

			public int LODstyle;

			public PSKMaterial(string _name, int _texture)
			{
				name = _name;
				texture = _texture;
				polyflags = 0;
				auxmaterial = 0;
				auxflags = 0;
				LODbias = 0;
				LODstyle = 0;
			}
		}

		public struct PSKPoint
		{
			public float x;

			public float y;

			public float z;

			public PSKPoint(float _x, float _y, float _z)
			{
				x = _x;
				y = _y;
				z = _z;
			}

			public PSKPoint(Vector3 v)
			{
				x = v.X;
				y = v.Y;
				z = v.Z;
			}

			public Vector3 ToVector3()
			{
				return new Vector3(x, y, z);
			}
		}

		public struct PSKQuad
		{
			public float w;

			public float x;

			public float y;

			public float z;

			public PSKQuad(float _w, float _x, float _y, float _z)
			{
				w = _w;
				x = _x;
				y = _y;
				z = _z;
			}

			public PSKQuad(Vector4 v)
			{
				w = v.W;
				x = v.X;
				y = v.Y;
				z = v.Z;
			}

			public Vector4 ToVector4()
			{
				return new Vector4(x, y, z, w);
			}
		}

		public struct PSKWeight
		{
			public float weight;

			public int point;

			public int bone;

			public PSKWeight(float _weight, int _point, int _bone)
			{
				weight = _weight;
				point = _point;
				bone = _bone;
			}
		}

		public List<PSKPoint> points;

		public List<PSKEdge> edges;

		public List<PSKFace> faces;

		public List<PSKMaterial> materials;

		public List<PSKBone> bones;

		public List<PSKWeight> weights;

		public PSKFile()
		{
		}

		public PSKFile(string filename)
		{
			FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
			while (fileStream.Position < fileStream.Length)
			{
				PSKHeader pSKHeader = ReadHeader(fileStream);
				switch (pSKHeader.name)
				{
				case "PNTS0000":
				{
					points = new List<PSKPoint>();
					for (int i = 0; i < pSKHeader.count; i++)
					{
						PSKPoint pSKPoint = new PSKPoint
						{
							x = ReadFloat(fileStream),
							z = ReadFloat(fileStream),
							y = ReadFloat(fileStream)
						};
						points.Add(pSKPoint);
					}
					break;
				}
				case "VTXW0000":
				{
					edges = new List<PSKEdge>();
					for (int j = 0; j < pSKHeader.count; j++)
					{
						PSKEdge pSKEdge = new PSKEdge
						{
							index = ReadUInt16(fileStream)
						};
						ReadUInt16(fileStream);
						pSKEdge.U = ReadFloat(fileStream);
						pSKEdge.V = ReadFloat(fileStream);
						pSKEdge.material = Convert.ToByte(fileStream.ReadByte());
						fileStream.ReadByte();
						ReadUInt16(fileStream);
						edges.Add(pSKEdge);
					}
					break;
				}
				case "FACE0000":
				{
					faces = new List<PSKFace>();
					for (int k = 0; k < pSKHeader.count; k++)
					{
						PSKFace pSKFace = new PSKFace(ReadUInt16(fileStream), ReadUInt16(fileStream), ReadUInt16(fileStream), (byte)fileStream.ReadByte());
						fileStream.ReadByte();
						ReadInt32(fileStream);
						faces.Add(pSKFace);
					}
					break;
				}
				case "MATT0000":
				{
					materials = new List<PSKMaterial>();
					for (int l = 0; l < pSKHeader.count; l++)
					{
						PSKMaterial pSKMaterial = new PSKMaterial
						{
							name = ReadFixedString(fileStream, 64),
							texture = ReadInt32(fileStream)
						};
						ReadInt32(fileStream);
						ReadInt32(fileStream);
						ReadInt32(fileStream);
						ReadInt32(fileStream);
						ReadInt32(fileStream);
						materials.Add(pSKMaterial);
					}
					break;
				}
				case "REFSKELT":
				{
					bones = new List<PSKBone>();
					for (int m = 0; m < pSKHeader.count; m++)
					{
						PSKBone pSKBone = new PSKBone
						{
							name = ReadFixedString(fileStream, 64)
						};
						ReadInt32(fileStream);
						pSKBone.childs = ReadInt32(fileStream);
						pSKBone.parent = ReadInt32(fileStream);
						pSKBone.rotation.x = ReadFloat(fileStream);
						pSKBone.rotation.z = ReadFloat(fileStream);
						pSKBone.rotation.y = ReadFloat(fileStream);
						pSKBone.rotation.w = ReadFloat(fileStream);
						pSKBone.location.x = ReadFloat(fileStream);
						pSKBone.location.z = ReadFloat(fileStream);
						pSKBone.location.y = ReadFloat(fileStream);
						ReadInt32(fileStream);
						ReadInt32(fileStream);
						ReadInt32(fileStream);
						ReadInt32(fileStream);
						bones.Add(pSKBone);
					}
					break;
				}
				case "RAWWEIGHTS":
				{
					weights = new List<PSKWeight>();
					for (int n = 0; n < pSKHeader.count; n++)
					{
						PSKWeight pSKWeight = new PSKWeight(ReadFloat(fileStream), ReadInt32(fileStream), ReadInt32(fileStream));
						weights.Add(pSKWeight);
					}
					break;
				}
				default:
					fileStream.Seek(pSKHeader.size * pSKHeader.count, SeekOrigin.Current);
					break;
				}
			}
			fileStream.Close();
		}

		public string ReadFixedString(FileStream fs, int len)
		{
			string str = "";
			for (int i = 0; i < len; i++)
			{
				byte num1;
				if ((num1 = (byte)fs.ReadByte()) != 0)
				{
					str += (char)num1;
				}
			}
			return str;
		}

		public float ReadFloat(FileStream fs)
		{
			byte[] numArray = new byte[4];
			fs.Read(numArray, 0, 4);
			return BitConverter.ToSingle(numArray, 0);
		}

		private PSKHeader ReadHeader(FileStream fs)
		{
			PSKHeader result = default(PSKHeader);
			result.name = ReadFixedString(fs, 20);
			result.flags = ReadInt32(fs);
			result.size = ReadInt32(fs);
			result.count = ReadInt32(fs);
			return result;
		}

		public int ReadInt32(FileStream fs)
		{
			byte[] numArray = new byte[4];
			fs.Read(numArray, 0, 4);
			return BitConverter.ToInt32(numArray, 0);
		}

		public ushort ReadUInt16(FileStream fs)
		{
			byte[] numArray = new byte[2];
			fs.Read(numArray, 0, 2);
			return BitConverter.ToUInt16(numArray, 0);
		}

		public void Save(string filename)
		{
			FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
			WriteHeader(fileStream, "ACTRHEAD", 1999801, 0, 0);
			WriteHeader(fileStream, "PNTS0000", 1999801, 12, points.Count);
			foreach (PSKPoint point in points)
			{
				WriteFloat(fileStream, point.x);
				WriteFloat(fileStream, point.z);
				WriteFloat(fileStream, point.y);
			}
			WriteHeader(fileStream, "VTXW0000", 1999801, 16, edges.Count);
			foreach (PSKEdge edge in edges)
			{
				WriteUInt16(fileStream, edge.index);
				WriteUInt16(fileStream, 0);
				WriteFloat(fileStream, edge.U);
				WriteFloat(fileStream, edge.V);
				fileStream.WriteByte(edge.material);
				fileStream.WriteByte(0);
				WriteUInt16(fileStream, 0);
			}
			WriteHeader(fileStream, "FACE0000", 1999801, 12, faces.Count);
			foreach (PSKFace face in faces)
			{
				WriteUInt16(fileStream, (ushort)face.v0);
				WriteUInt16(fileStream, (ushort)face.v1);
				WriteUInt16(fileStream, (ushort)face.v2);
				fileStream.WriteByte(face.material);
				fileStream.WriteByte(0);
				WriteInt32(fileStream, 0);
			}
			WriteHeader(fileStream, "MATT0000", 1999801, 88, materials.Count);
			foreach (PSKMaterial material in materials)
			{
				WriteFixedString(fileStream, material.name, 64);
				WriteInt32(fileStream, material.texture);
				WriteInt32(fileStream, 0);
				WriteInt32(fileStream, 0);
				WriteInt32(fileStream, 0);
				WriteInt32(fileStream, 0);
				WriteInt32(fileStream, 0);
			}
			WriteHeader(fileStream, "REFSKELT", 1999801, 120, bones.Count);
			foreach (PSKBone bone in bones)
			{
				WriteFixedString(fileStream, bone.name, 64);
				WriteInt32(fileStream, 0);
				WriteInt32(fileStream, bone.childs);
				WriteInt32(fileStream, bone.parent);
				WriteFloat(fileStream, bone.rotation.x);
				WriteFloat(fileStream, bone.rotation.z);
				WriteFloat(fileStream, bone.rotation.y);
				WriteFloat(fileStream, bone.rotation.w);
				WriteFloat(fileStream, bone.location.x);
				WriteFloat(fileStream, bone.location.z);
				WriteFloat(fileStream, bone.location.y);
				WriteInt32(fileStream, 0);
				WriteInt32(fileStream, 0);
				WriteInt32(fileStream, 0);
				WriteInt32(fileStream, 0);
			}
			WriteHeader(fileStream, "RAWWEIGHTS", 1999801, 12, weights.Count);
			foreach (PSKWeight weight in weights)
			{
				WriteFloat(fileStream, weight.weight);
				WriteInt32(fileStream, weight.point);
				WriteInt32(fileStream, weight.bone);
			}
			fileStream.Close();
		}

		public void WriteFixedString(FileStream fs, string s, int len)
		{
			for (int i = 0; i < len; i++)
			{
				if (i >= s.Length)
				{
					fs.WriteByte(0);
				}
				else
				{
					fs.WriteByte((byte)s[i]);
				}
			}
		}

		public void WriteFloat(FileStream fs, float f)
		{
			fs.Write(BitConverter.GetBytes(f), 0, 4);
		}

		private void WriteHeader(FileStream fs, string name, int flags, int size, int count)
		{
			WriteFixedString(fs, name, 20);
			WriteInt32(fs, flags);
			WriteInt32(fs, size);
			WriteInt32(fs, count);
		}

		public void WriteInt32(FileStream fs, int i)
		{
			fs.Write(BitConverter.GetBytes(i), 0, 4);
		}

		public void WriteUInt16(FileStream fs, ushort u)
		{
			fs.Write(BitConverter.GetBytes(u), 0, 2);
		}
	}
}
