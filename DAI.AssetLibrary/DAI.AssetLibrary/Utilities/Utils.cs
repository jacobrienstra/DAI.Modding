using System;
using System.Collections.Generic;
using System.IO;

using DAI.AssetLibrary.Utilities.Extensions;

using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

using zlib;

namespace DAI.AssetLibrary.Utilities {
    public static class Utils {

        public static int Hasher(string StrToHash) {
            int num = 5381;
            for (int i = 0; i < StrToHash.Length; i++) {
                byte strToHash = (byte)StrToHash[i];
                num = (num * 33) ^ strToHash;
            }
            return num;
        }

        public static void ToDebugWindow(this TimeSpan ts, string message) {
        }

        public static bool CompareByteArrays(byte[] array1, byte[] array2) {
            if (array1 == null != (array2 == null)) {
                return false;
            }
            if (array1 == null) {
                return true;
            }
            if (array1.Length != array2.Length) {
                return false;
            }
            for (int i = 0; i < array1.Length; i++) {
                if (array1[i] != array2[i]) {
                    return false;
                }
            }
            return true;
        }

        public static byte[] DecodeFile(string Path) {
            List<byte> nums = new List<byte>();
            using (FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader binaryReader = new BinaryReader(fs)) {
                    switch (binaryReader.ReadInt32()) {
                        case 13553920:
                        case 30331136: {
                                binaryReader.BaseStream.Seek(296L, SeekOrigin.Begin);
                                byte[] numArray = new byte[260];
                                for (int i = 0; i < 260; i++) {
                                    numArray[i] = (byte)(binaryReader.ReadByte() ^ 0x7Bu);
                                }
                                int num1 = 0;
                                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length) {
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

        public static byte[] DecompressZlib(byte[] input, int size) {
            byte[] result = new byte[size];
            InflaterInputStream inflaterInputStream = new InflaterInputStream(new MemoryStream(input));
            inflaterInputStream.Read(result, 0, size);
            inflaterInputStream.Flush();
            return result;
        }

        public static void DecompressZlib(byte[] inData, out byte[] outData) {
            try {
                using (MemoryStream memoryStream = new MemoryStream()) {
                    using (ZOutputStream zOutputStream = new ZOutputStream(memoryStream)) {
                        using (Stream stream = new MemoryStream(inData)) {
                            CopyStream(stream, zOutputStream);
                            zOutputStream.finish();
                            outData = memoryStream.ToArray();
                        }
                    }
                }
            } catch (Exception ex) {
                outData = new byte[1];
                throw ex;
            }
        }

        public static void CompressZlib(byte[] inData, out byte[] outData) {
            using (MemoryStream memoryStream = new MemoryStream()) {
                using (ZOutputStream zOutputStream = new ZOutputStream(memoryStream, 1)) {
                    using (Stream stream = new MemoryStream(inData)) {
                        CopyStream(stream, zOutputStream);
                        zOutputStream.finish();
                        outData = memoryStream.ToArray();
                    }
                }
            }
        }

        public static void CopyStream(Stream input, Stream output) {
            try {
                byte[] buffer = new byte[65536];
                int count;
                while ((count = input.Read(buffer, 0, 65536)) > 0) {
                    output.Write(buffer, 0, count);
                }
                output.Flush();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static byte[] CompressData(byte[] InData) {
            using (BinaryReader binaryReader = new BinaryReader(new MemoryStream(InData))) {
                long num = 0L;
                binaryReader.BaseStream.Seek(num, SeekOrigin.Begin);
                byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length - (int)num);
                binaryReader.Close();
                long length = array.Length;
                using (BinaryReader binaryReader2 = new BinaryReader(new MemoryStream(array))) {
                    List<byte> nums = new List<byte>();
                    while (length > 0) {
                        long num2 = ((length > 65536) ? 65536 : length);
                        byte[] inData = binaryReader2.ReadBytes((int)num2);
                        CompressZlib(inData, out var outData);
                        nums.Add(Convert.ToByte((num2 & 0xFF000000u) >> 24));
                        nums.Add(Convert.ToByte((num2 & 0xFF0000) >> 16));
                        nums.Add(Convert.ToByte((num2 & 0xFF00) >> 8));
                        nums.Add(Convert.ToByte(num2 & 0xFF));
                        nums.Add(2);
                        nums.Add(112);
                        nums.Add(Convert.ToByte((outData.Length & 0xFF00) >> 8));
                        nums.Add(Convert.ToByte(outData.Length & 0xFF));
                        nums.AddRange(outData);
                        length -= num2;
                    }
                    return nums.ToArray();
                }
            }
        }

        public static byte[] CompressData(byte[] InData, ref ImportCompressData ImportResults) {
            BinaryReader binaryReader = new BinaryReader(new MemoryStream(InData));
            binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
            byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length - 0);
            binaryReader.Close();
            long length = array.Length;
            BinaryReader binaryReader2 = new BinaryReader(new MemoryStream(array));
            List<byte> nums = new List<byte>();
            while (length > 0) {
                long num2 = ((length > 65536) ? 65536 : length);
                if (binaryReader2.BaseStream.Position == ImportResults.MipSize) {
                    ImportResults.RangeStart = nums.Count;
                } else if (num2 != 65536 && ImportResults.RangeStart == 0 && ImportResults.MipSize != 0) {
                    ImportResults.RangeStart = nums.Count;
                }
                if (binaryReader2.BaseStream.Position == ImportResults.FirstMipSize) {
                    ImportResults.FirstMipEndOffset = nums.Count;
                } else if (binaryReader2.BaseStream.Position == ImportResults.SecondMipSize) {
                    ImportResults.SecondMipEndOffset = nums.Count;
                }
                // From ModManager code; see ImportCompressData Definition
                //long num2 = ((num > 65536) ? 65536 : num);
                //if (binaryReader2.BaseStream.Position == ImportResults.SecondMipOffset) {
                //    ImportResults.RangeStart = list.Count;
                //}
                //if (binaryReader2.BaseStream.Position == ImportResults.FirstMipOffset) {
                //    ImportResults.MipEndOffset = list.Count;
                //}
                byte[] inData = binaryReader.ReadBytes((int)num2);
                CompressZlib(inData, out var outData);
                nums.Add(Convert.ToByte((num2 & 0xFF000000u) >> 24));
                nums.Add(Convert.ToByte((num2 & 0xFF0000) >> 16));
                nums.Add(Convert.ToByte((num2 & 0xFF00) >> 8));
                nums.Add(Convert.ToByte(num2 & 0xFF));
                nums.Add(2);
                nums.Add(112);
                nums.Add(Convert.ToByte((outData.Length & 0xFF00) >> 8));
                nums.Add(Convert.ToByte(outData.Length & 0xFF));
                nums.AddRange(outData);
                length -= num2;
            }
            binaryReader.Close();
            ImportResults.RangeEnd = nums.Count;
            return nums.ToArray();
        }

        public static byte[] DecompressData(byte[] InData, long Size = -1L) {
            using (MemoryStream ms = new MemoryStream(InData)) {
                using (BinaryReader binaryReader = new BinaryReader(ms)) {
                    byte[] result = DecompressData(binaryReader, Size);
                    binaryReader.Close();
                    return result;
                }
            }
        }

        public static byte[] DecompressData(BinaryReader Reader, long Size = -1L) {
            long num = (Size != -1) ? Size : Reader.BaseStream.Length;
            long num2 = (Size == -1) ? 0 : Reader.BaseStream.Position;
            List<byte> nums = new List<byte>();
            while (Reader.BaseStream.Position - num2 < num) {
                uint num3 = Reader.ReadUInt32BE();
                Reader.BaseStream.Position -= 4L;
                if (num3 == 4207808496) {
                    break;
                }
                nums.AddRange(DecompressBlock(Reader));
            }
            return nums.ToArray();
        }

        public static byte[] DecompressBlock(BinaryReader Reader) {
            List<byte> list = new List<byte>();
            try {
                uint num = Reader.ReadUInt32BE();
                uint num2 = Reader.ReadUInt16();
                uint count = Reader.ReadUInt16BE();
                if (num2 == 28674) {
                    byte[] inData = Reader.ReadBytes((int)count);
                    DecompressZlib(inData, out var outData);
                    list.AddRange(outData);
                } else if (num2 == 28672) {
                    list.AddRange(Reader.ReadBytes((int)count));
                } else if (num2 == 28928) {
                    list.AddRange(Reader.ReadBytes((int)num));
                } else if (num2 == 28681) {
                    while (list.Count != num) {
                        byte b = Reader.ReadByte();
                        int num3 = (b & 0xF0) >> 4;
                        if (num3 == 15) {
                            byte b2 = byte.MaxValue;
                            while (b2 == byte.MaxValue) {
                                b2 = Reader.ReadByte();
                                num3 += b2;
                            }
                        }
                        int num4 = b & 0xF;
                        list.AddRange(Reader.ReadBytes(num3));
                        if (list.Count == num) {
                            break;
                        }
                        int num5 = Reader.ReadUInt16();
                        if (num4 == 15) {
                            byte b3 = byte.MaxValue;
                            while (b3 == byte.MaxValue) {
                                b3 = Reader.ReadByte();
                                num4 += b3;
                            }
                        }
                        int num6 = list.Count - num5;
                        int num7 = list.Count - num6;
                        int num8 = 0;
                        int num9 = 0;
                        while (num9 < 4 + num4) {
                            list.Add(list[num6 + num8]);
                            if (num8++ == num7 - 1) {
                                num8 = 0;
                            }
                            int num10 = num9 + 1;
                            num9 = num10;
                        }
                    }
                    list.AddRange(Reader.ReadBytes((int)num - list.Count));
                } else {
                    Reader.ReadBytes((int)count);
                }
                return list.ToArray();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
