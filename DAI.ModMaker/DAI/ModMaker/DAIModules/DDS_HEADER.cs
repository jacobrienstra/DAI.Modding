using System.IO;

namespace DAI.ModMaker.DAIModules
{
	public struct DDS_HEADER
	{
		public struct DDS_PIXELFORMAT
		{
			public int dwSize;

			public int dwFlags;

			public int dwFourCC;

			public int dwRGBBitCount;

			public uint dwRBitMask;

			public uint dwGBitMask;

			public uint dwBBitMask;

			public int dwABitMask;
		}

		public int dwSize;

		public int dwFlags;

		public int dwHeight;

		public int dwWidth;

		public int dwPitchOrLinearSize;

		public int dwDepth;

		public int dwMipMapCount;

		public int[] dwReserved1;

		public DDS_PIXELFORMAT ddspf;

		public int dwCaps;

		public int dwCaps2;

		public int dwCaps3;

		public int dwCaps4;

		public int dwReserved2;

		public void Read(Stream s)
		{
			BinaryReader binaryReader = new BinaryReader(s);
			binaryReader.ReadInt32();
			dwSize = binaryReader.ReadInt32();
			dwFlags = binaryReader.ReadInt32();
			dwHeight = binaryReader.ReadInt32();
			dwWidth = binaryReader.ReadInt32();
			dwPitchOrLinearSize = binaryReader.ReadInt32();
			dwDepth = binaryReader.ReadInt32();
			dwMipMapCount = binaryReader.ReadInt32();
			dwReserved1 = new int[11];
			for (int i = 0; i < 11; i++)
			{
				dwReserved1[i] = binaryReader.ReadInt32();
			}
			ddspf = new DDS_PIXELFORMAT
			{
				dwSize = binaryReader.ReadInt32(),
				dwFlags = binaryReader.ReadInt32(),
				dwFourCC = binaryReader.ReadInt32(),
				dwRGBBitCount = binaryReader.ReadInt32(),
				dwRBitMask = binaryReader.ReadUInt32(),
				dwGBitMask = binaryReader.ReadUInt32(),
				dwBBitMask = binaryReader.ReadUInt32(),
				dwABitMask = binaryReader.ReadInt32()
			};
			dwCaps = binaryReader.ReadInt32();
			dwCaps2 = binaryReader.ReadInt32();
			dwCaps3 = binaryReader.ReadInt32();
			dwCaps4 = binaryReader.ReadInt32();
			dwReserved2 = binaryReader.ReadInt32();
		}

		public void Write(Stream s)
		{
			BinaryWriter binaryWriter = new BinaryWriter(s);
			binaryWriter.Write(542327876);
			binaryWriter.Write(dwSize);
			binaryWriter.Write(dwFlags);
			binaryWriter.Write(dwHeight);
			binaryWriter.Write(dwWidth);
			binaryWriter.Write(dwPitchOrLinearSize);
			binaryWriter.Write(dwDepth);
			binaryWriter.Write(dwMipMapCount);
			for (int i = 0; i < 11; i++)
			{
				binaryWriter.Write(dwReserved1[i]);
			}
			binaryWriter.Write(ddspf.dwSize);
			binaryWriter.Write(ddspf.dwFlags);
			binaryWriter.Write(ddspf.dwFourCC);
			binaryWriter.Write(ddspf.dwRGBBitCount);
			binaryWriter.Write(ddspf.dwRBitMask);
			binaryWriter.Write(ddspf.dwGBitMask);
			binaryWriter.Write(ddspf.dwBBitMask);
			binaryWriter.Write(ddspf.dwABitMask);
			binaryWriter.Write(dwCaps);
			binaryWriter.Write(dwCaps2);
			binaryWriter.Write(dwCaps3);
			binaryWriter.Write(dwCaps4);
			binaryWriter.Write(dwReserved2);
		}
	}
}
