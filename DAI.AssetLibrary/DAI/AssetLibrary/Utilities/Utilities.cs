using System;
using System.Collections.Generic;
using System.IO;
using DAI.AssetLibrary.Utilities.Extensions;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using zlib;

namespace DAI.AssetLibrary.Utilities
{
	public static class Utilities
	{
		public static void ToDebugWindow(this TimeSpan ts, string message)
		{
		}

		public static bool CompareByteArrays(byte[] array1, byte[] array2)
		{
			if (array1 == null != (array2 == null))
			{
				return false;
			}
			if (array1 == null)
			{
				return true;
			}
			if (array1.Length != array2.Length)
			{
				return false;
			}
			for (int i = 0; i < array1.Length; i++)
			{
				if (array1[i] != array2[i])
				{
					return false;
				}
			}
			return true;
		}

		public static byte[] DecodeFile(string Path)
		{
			List<byte> nums = new List<byte>();
			using (FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
			{
				using (BinaryReader binaryReader = new BinaryReader(fs))
				{
					switch (binaryReader.ReadInt32())
					{
					case 13553920:
					case 30331136:
					{
						binaryReader.BaseStream.Seek(296L, SeekOrigin.Begin);
						byte[] numArray = new byte[260];
						for (int i = 0; i < 260; i++)
						{
							numArray[i] = (byte)(binaryReader.ReadByte() ^ 0x7Bu);
						}
						int num1 = 0;
						while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
						{
							byte num2 = numArray[num1 % 257];
							nums.Add((byte)(num2 ^ binaryReader.ReadByte()));
						}
						break;
					}
					default:
						binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
						nums.AddRange(binaryReader.ReadBytes((int)binaryReader.BaseStream.Length));
						break;
					case 63885568:
						binaryReader.BaseStream.Seek(556L, SeekOrigin.Begin);
						nums.AddRange(binaryReader.ReadBytes((int)binaryReader.BaseStream.Length - 556));
						break;
					}
				}
			}
			return nums.ToArray();
		}

		public static byte[] DecompressZlib(byte[] input, int size)
		{
			byte[] result = new byte[size];
			InflaterInputStream inflaterInputStream = new InflaterInputStream(new MemoryStream(input));
			inflaterInputStream.Read(result, 0, size);
			inflaterInputStream.Flush();
			return result;
		}

		public static void DecompressZlib(byte[] inData, out byte[] outData)
		{
			try
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (ZOutputStream zOutputStream = new ZOutputStream(memoryStream))
					{
						using (Stream stream = new MemoryStream(inData))
						{
							CopyStream(stream, zOutputStream);
							zOutputStream.finish();
							outData = memoryStream.ToArray();
						}
					}
				}
			}
			catch (Exception ex)
			{
				outData = new byte[1];
				throw ex;
			}
		}

		public static void CompressZlib(byte[] inData, out byte[] outData)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (ZOutputStream zOutputStream = new ZOutputStream(memoryStream, 1))
				{
					using (Stream stream = new MemoryStream(inData))
					{
						CopyStream(stream, zOutputStream);
						zOutputStream.finish();
						outData = memoryStream.ToArray();
					}
				}
			}
		}

		public static void CopyStream(Stream input, Stream output)
		{
			try
			{
				byte[] numArray = new byte[65536];
				while (true)
				{
					int num = input.Read(numArray, 0, 65536);
					if (num <= 0)
					{
						break;
					}
					output.Write(numArray, 0, num);
				}
				output.Flush();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static byte[] CompressData(byte[] InData)
		{
			using (BinaryReader binaryReader = new BinaryReader(new MemoryStream(InData)))
			{
				long num = 0L;
				binaryReader.BaseStream.Seek(num, SeekOrigin.Begin);
				_ = new byte[binaryReader.BaseStream.Length - num];
				byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length - (int)num);
				binaryReader.Close();
				long length = array.Length;
				using (BinaryReader binaryReader2 = new BinaryReader(new MemoryStream(array)))
				{
					List<byte> nums = new List<byte>();
					while (length > 0)
					{
						long num2 = ((length > 65536) ? 65536 : length);
						_ = new byte[num2];
						byte[] inData = binaryReader2.ReadBytes((int)num2);
						byte[] numArray2 = null;
						CompressZlib(inData, out numArray2);
						nums.Add(Convert.ToByte((num2 & -16777216) >> 24));
						nums.Add(Convert.ToByte((num2 & 0xFF0000) >> 16));
						nums.Add(Convert.ToByte((num2 & 0xFF00) >> 8));
						nums.Add(Convert.ToByte(num2 & 0xFF));
						nums.Add(2);
						nums.Add(112);
						nums.Add(Convert.ToByte((numArray2.Length & 0xFF00) >> 8));
						nums.Add(Convert.ToByte(numArray2.Length & 0xFF));
						nums.AddRange(numArray2);
						length -= num2;
					}
					return nums.ToArray();
				}
			}
		}

		public static byte[] CompressData(byte[] InData, ref ImportCompressData ImportResults)
		{
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(InData));
			long num = 0L;
			binaryReader.BaseStream.Seek(num, SeekOrigin.Begin);
			_ = new byte[binaryReader.BaseStream.Length - num];
			BinaryReader binaryReader2 = binaryReader;
			byte[] array = binaryReader2.ReadBytes((int)binaryReader2.BaseStream.Length - (int)num);
			binaryReader.Close();
			long length = array.Length;
			binaryReader = new BinaryReader(new MemoryStream(array));
			List<byte> nums = new List<byte>();
			while (length > 0)
			{
				long num2 = ((length > 65536) ? 65536 : length);
				if (binaryReader.BaseStream.Position == ImportResults.MipSize)
				{
					ImportResults.RangeStart = nums.Count;
				}
				else if (num2 != 65536 && ImportResults.RangeStart == 0 && ImportResults.MipSize != 0)
				{
					ImportResults.RangeStart = nums.Count;
				}
				if (binaryReader.BaseStream.Position == ImportResults.FirstMipSize)
				{
					ImportResults.FirstMipEndOffset = nums.Count;
				}
				else if (binaryReader.BaseStream.Position == ImportResults.SecondMipSize)
				{
					ImportResults.SecondMipEndOffset = nums.Count;
				}
				_ = new byte[num2];
				byte[] inData = binaryReader.ReadBytes((int)num2);
				byte[] numArray2 = null;
				CompressZlib(inData, out numArray2);
				nums.Add(Convert.ToByte((num2 & -16777216) >> 24));
				nums.Add(Convert.ToByte((num2 & 0xFF0000) >> 16));
				nums.Add(Convert.ToByte((num2 & 0xFF00) >> 8));
				nums.Add(Convert.ToByte(num2 & 0xFF));
				nums.Add(2);
				nums.Add(112);
				nums.Add(Convert.ToByte((numArray2.Length & 0xFF00) >> 8));
				nums.Add(Convert.ToByte(numArray2.Length & 0xFF));
				nums.AddRange(numArray2);
				length -= num2;
			}
			binaryReader.Close();
			ImportResults.RangeEnd = nums.Count;
			return nums.ToArray();
		}

		public static byte[] DecompressData(byte[] InData, long Size = -1L)
		{
			using (MemoryStream ms = new MemoryStream(InData))
			{
				using (BinaryReader binaryReader = new BinaryReader(ms))
				{
					byte[] result = DecompressData(binaryReader, Size);
					binaryReader.Close();
					return result;
				}
			}
		}

		public static byte[] DecompressData(BinaryReader Reader, long Size = -1L)
		{
			long num = ((Size != -1) ? Size : Reader.BaseStream.Length);
			long num2 = ((Size == -1) ? 0 : Reader.BaseStream.Position);
			List<byte> nums = new List<byte>();
			while (Reader.BaseStream.Position - num2 < num)
			{
				uint num3 = Reader.ReadUInt32BE();
				Reader.BaseStream.Position -= 4L;
				if (num3 == 4207808496)
				{
					break;
				}
				nums.AddRange(DecompressBlock(Reader));
			}
			return nums.ToArray();
		}

		public static byte[] DecompressBlock(BinaryReader Reader)
		{
			uint num = 0u;
			List<byte> nums = new List<byte>();
			num = Reader.ReadUInt32BE();
			uint num2 = Reader.ReadUInt16();
			uint num3 = Reader.ReadUInt16BE();
			if (num2 <= 28674)
			{
				if (num2 != 28672)
				{
					if (num2 != 28674)
					{
						goto IL_01a1;
					}
					_ = new byte[num3];
					byte[] inData = Reader.ReadBytes((int)num3);
					byte[] numArray1 = new byte[num];
					DecompressZlib(inData, out numArray1);
					nums.AddRange(numArray1);
				}
				else
				{
					nums.AddRange(Reader.ReadBytes((int)num3));
				}
			}
			else if (num2 != 28681)
			{
				if (num2 != 28928)
				{
					goto IL_01a1;
				}
				nums.AddRange(Reader.ReadBytes((int)num));
			}
			else
			{
				while (nums.Count != num)
				{
					byte num4 = Reader.ReadByte();
					int num5 = (num4 & 0xF0) >> 4;
					if (num5 == 15)
					{
						byte num6 = byte.MaxValue;
						while (num6 == byte.MaxValue)
						{
							num6 = Reader.ReadByte();
							num5 += num6;
						}
					}
					int num7 = num4 & 0xF;
					nums.AddRange(Reader.ReadBytes(num5));
					if (nums.Count == num)
					{
						break;
					}
					int num8 = Reader.ReadUInt16();
					if (num7 == 15)
					{
						byte num9 = byte.MaxValue;
						while (num9 == byte.MaxValue)
						{
							num9 = Reader.ReadByte();
							num7 += num9;
						}
					}
					int count = nums.Count - num8;
					int count2 = nums.Count - count;
					int num10 = 0;
					for (int i = 0; i < 4 + num7; i++)
					{
						nums.Add(nums[count + num10]);
						if (num10++ == count2 - 1)
						{
							num10 = 0;
						}
					}
				}
				nums.AddRange(Reader.ReadBytes((int)(num - nums.Count)));
			}
			goto IL_01a9;
			IL_01a1:
			Reader.ReadBytes((int)num3);
			goto IL_01a9;
			IL_01a9:
			return nums.ToArray();
		}
	}
}
