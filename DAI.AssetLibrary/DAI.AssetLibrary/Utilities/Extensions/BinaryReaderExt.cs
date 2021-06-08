using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using DAI.AssetLibrary.Assets.Bases;

namespace DAI.AssetLibrary.Utilities.Extensions {
    public static class BinaryReaderExt {
        public static ulong ReadEncodedSize(this BinaryReader reader) {
            ulong result = 0uL;
            byte shift = 0;
            while (true) {
                int i = reader.ReadByte();
                if (i == -1) {
                    return result;
                }
                byte b = (byte)i;
                result |= (ulong)(uint)((b & 0x7F) << shift);
                if (b >> 7 == 0) {
                    break;
                }
                shift = (byte)(shift + 7);
            }
            return result;
        }

        public static short ReadLEInt16(this BinaryReader reader) {
            return BitConverter.ToInt16(reader.ReadBytes(2).Reverse().ToArray(), 0);
        }

        public static int ReadLEInt(this BinaryReader reader) {
            return BitConverter.ToInt32(reader.ReadBytes(4).Reverse().ToArray(), 0);
        }

        public static long ReadLEInt64(this BinaryReader reader) {
            return BitConverter.ToInt64(reader.ReadBytes(8).Reverse().ToArray(), 0);
        }

        public static uint ReadLEUInt(this BinaryReader reader) {
            return BitConverter.ToUInt32(reader.ReadBytes(4).Reverse().ToArray(), 0);
        }

        public static ushort ReadLEUInt16(this BinaryReader reader) {
            return BitConverter.ToUInt16(reader.ReadBytes(2).Reverse().ToArray(), 0);
        }

        public static ulong ReadLEUInt64(this BinaryReader reader) {
            return BitConverter.ToUInt64(reader.ReadBytes(8).Reverse().ToArray(), 0);
        }

        public static string ReadTerminatedString(this BinaryReader Reader, byte Terminater) {
            string str = "";
            char chr = ' ';
            do {
                chr = (char)Reader.ReadByte();
                str += chr;
            }
            while (chr != Terminater);
            string text = str;
            return text.Remove(text.Length - 1);
        }

        public static string ReadNullTerminatedString(this BinaryReader Reader) {
            StringBuilder sb = new StringBuilder();
            while (Reader.BaseStream.Position < Reader.BaseStream.Length) {
                char chr = (char)Reader.ReadByte();
                if (chr == '\0') {
                    break;
                }
                sb.Append(chr);
            }
            return sb.ToString();
        }

        public static byte[] ReadSha1ToBytes(this BinaryReader reader) {
            return reader.ReadBytes(20);
        }
        
        public static string ReadSha1ToHexStr(this BinaryReader reader) {
            return reader.ReadBytes(20).ToHex();
        }

        public static string ToHex(this byte[] bytes) {
            char[] c = new char[bytes.Length * 2];
            int bx = 0;
            int cx = 0;
            while (bx < bytes.Length) {
                byte b = (byte)(bytes[bx] >> 4);
                c[cx] = (char)((b > 9) ? (b + 55) : (b + 48));
                b = (byte)(bytes[bx] & 0xFu);
                c[++cx] = (char)((b > 9) ? (b + 55) : (b + 48));
                bx++;
                cx++;
            }
            return new string(c);
        }

        public static string ReadGuidAsString(this BinaryReader reader) {
            return reader.ReadGuid().ToString();
        }

        public static Guid ReadGuid(this BinaryReader reader) {
            byte[] values = reader.ReadBytes(16);
            return new Guid(values);
        }

        internal static string ReadStringField(this BinaryReader reader) {
            int size = (int)reader.ReadEncodedSize() - 1;
            return new string(reader.ReadChars(size));
        }

        internal static byte[] ReadByteArrayField(this BinaryReader reader) {
            int size = (int)reader.ReadEncodedSize();
            return reader.ReadBytes(size);
        }

        public static byte[] DecompressData(this BinaryReader Reader, long Size = -1L) {
            long num = ((Size != -1) ? Size : Reader.BaseStream.Length);
            long num2 = ((Size == -1) ? 0 : Reader.BaseStream.Position);
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

        public static uint ReadUInt16BE(this BinaryReader Reader) {
            return 0u | (uint)(Reader.ReadByte() << 8) | Reader.ReadByte();
        }

        public static byte[] DecompressBlock(BinaryReader Reader) {
            uint num = 0u;
            List<byte> nums = new List<byte>();
            try {
                num = Reader.ReadUInt32BE();
                uint num2 = Reader.ReadUInt16();
                uint num3 = Reader.ReadUInt16BE();
                if (num2 == 28674) {
                    _ = new byte[num3];
                    byte[] inData = Reader.ReadBytes((int)num3);
                    byte[] numArray1 = new byte[num];
                    Utils.DecompressZlib(inData, out numArray1);
                    nums.AddRange(numArray1);
                } else if (num2 == 28672) {
                    nums.AddRange(Reader.ReadBytes((int)num3));
                } else if (num2 == 28928) {
                    nums.AddRange(Reader.ReadBytes((int)num));
                } else if (num2 != 28681) {
                    Reader.ReadBytes((int)num3);
                } else {
                    while (nums.Count != num) {
                        byte num4 = Reader.ReadByte();
                        int num5 = (num4 & 0xF0) >> 4;
                        if (num5 == 15) {
                            byte num6 = byte.MaxValue;
                            while (num6 == byte.MaxValue) {
                                num6 = Reader.ReadByte();
                                num5 += num6;
                            }
                        }
                        int num7 = num4 & 0xF;
                        nums.AddRange(Reader.ReadBytes(num5));
                        if (nums.Count == num) {
                            break;
                        }
                        int num8 = Reader.ReadUInt16();
                        if (num7 == 15) {
                            byte num9 = byte.MaxValue;
                            while (num9 == byte.MaxValue) {
                                num9 = Reader.ReadByte();
                                num7 += num9;
                            }
                        }
                        int count = nums.Count - num8;
                        int count2 = nums.Count - count;
                        int num10 = 0;
                        for (int i = 0; i < 4 + num7; i++) {
                            nums.Add(nums[count + num10]);
                            if (num10++ == count2 - 1) {
                                num10 = 0;
                            }
                        }
                    }
                    nums.AddRange(Reader.ReadBytes((int)(num - nums.Count)));
                }
                return nums.ToArray();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static uint ReadUInt32BE(this BinaryReader Reader) {
            return 0u | (uint)(Reader.ReadByte() << 24) | (uint)(Reader.ReadByte() << 16) | (uint)(Reader.ReadByte() << 8) | Reader.ReadByte();
        }

        public static Vector3 ReadVector(this BinaryReader Reader) {
            return new Vector3 {
                X = Reader.ReadSingle(),
                Y = Reader.ReadSingle(),
                Z = Reader.ReadSingle()
            };
        }
    }
}
