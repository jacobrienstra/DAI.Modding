using System;
using System.IO;
using System.Text;

namespace DAI.AssetLibrary.Utilities.Extensions {
    public static class GuidExt {
        public static Guid GetGuidFromDoubleULong(ulong l1, ulong l2) {
            using (MemoryStream ms = new MemoryStream()) {
                using (BinaryWriter writer = new BinaryWriter(ms)) {
                    writer.Write(l1);
                    writer.Write(l2);
                }
                return new Guid(ms.ToArray());
            }
        }

        public static Guid GetGuidFromDoubleLong(long l1, long l2) {
            using (MemoryStream ms = new MemoryStream()) {
                using (BinaryWriter writer = new BinaryWriter(ms)) {
                    writer.Write(l1);
                    writer.Write(l2);
                }
                return new Guid(ms.ToArray());
            }
        }

        public static long[] AsDoubleLong(this Guid g) {
            using (MemoryStream ms = new MemoryStream(g.ToByteArray())) {
                using (BinaryReader reader = new BinaryReader(ms)) {
                    return new long[2]
                    {
                        reader.ReadInt64(),
                        reader.ReadInt64()
                    };
                }
            }
        }

        public static ulong[] AsDoubleULong(this Guid g) {
            using (MemoryStream ms = new MemoryStream(g.ToByteArray())) {
                using (BinaryReader reader = new BinaryReader(ms)) {
                    return new ulong[2]
                    {
                        reader.ReadUInt64(),
                        reader.ReadUInt64()
                    };
                }
            }
        }

        public static Guid ToBig(this Guid g) {
            byte[] bytes = g.ToByteArray();
            byte[] reversed = new byte[16];
            for (int j = 7; j >= 0; j--) {
                reversed[j] = bytes[7 - j];
            }
            for (int i = 15; i >= 8; i--) {
                reversed[i] = bytes[15 - i + 8];
            }
            return new Guid(reversed);
        }

        public static string ToSha1HexStr(this Guid g) {
            ulong[] values = g.AsDoubleULong();
            ulong value1 = 0uL;
            for (int i = 56; i >= 0; i -= 8) {
                value1 |= ((values[0] >> i) & 0xFF) << 56 - i;
            }
            ulong value2 = 0uL;
            for (int j = 56; j >= 0; j -= 8) {
                value2 |= ((values[1] >> j) & 0xFF) << 56 - j;
            }
            return value1.ToString("X16") + value2.ToString("X16");
        }

        public static string ToString(this Guid g, bool inverted) {
            if (!inverted) {
                return g.ToString();
            }
            string[] parts = g.ToString().Split('-');
            StringBuilder b = new StringBuilder();
            for (int j = 0; j < 3; j++) {
                for (int i = parts[j].Length - 2; i >= 0; i -= 2) {
                    b.Append(parts[j].Substring(i, 2));
                }
            }
            b.Append(parts[3]);
            b.Append(parts[4]);
            return b.ToString();
        }
    }
}
