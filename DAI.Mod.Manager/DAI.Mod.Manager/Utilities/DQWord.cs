using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace DAI.Mod.Manager.Utilities {

    public static class DQWordExt {
        public static DQWord ReadDQWord(this BinaryReader Reader) {
            DQWord dQWord = new DQWord(0uL, 0uL);
            dQWord.Value1 = Reader.ReadUInt64();
            dQWord.Value2 = Reader.ReadUInt64();
            return dQWord;
        }

        public static void Write(this BinaryWriter Writer, DQWord Value) {
            Writer.Write(Value.Value1);
            Writer.Write(Value.Value2);
        }
    }

    public class DQWord {
        public static DQWord ZeroDQWord = new DQWord(0uL, 0uL);

        public ulong Value1;

        public ulong Value2;

        public DQWord(ulong InVal1, ulong InVal2) {
            Value1 = InVal1;
            Value2 = InVal2;
        }

        public static bool operator ==(DQWord A, DQWord B) {
            if (A.Value1 == B.Value1) {
                return A.Value2 == B.Value2;
            }
            return false;
        }

        public static bool operator !=(DQWord A, DQWord B) {
            if (A.Value1 == B.Value1) {
                return A.Value2 != B.Value2;
            }
            return true;
        }

        public override string ToString() {
            ulong num = 0uL;
            for (int num2 = 56; num2 >= 0; num2 -= 8) {
                num |= ((Value1 >> num2) & 0xFF) << 56 - num2;
            }
            ulong num3 = 0uL;
            for (int num4 = 56; num4 >= 0; num4 -= 8) {
                num3 |= ((Value2 >> num4) & 0xFF) << 56 - num4;
            }
            return num.ToString("X16") + num3.ToString("X16");
        }

        public void ToBig() {
            ulong num = 0uL;
            for (int num2 = 56; num2 >= 0; num2 -= 8) {
                num |= ((Value1 >> num2) & 0xFF) << 56 - num2;
            }
            ulong num3 = 0uL;
            for (int num4 = 56; num4 >= 0; num4 -= 8) {
                num3 |= ((Value2 >> num4) & 0xFF) << 56 - num4;
            }
            Value1 = num;
            Value2 = num3;
        }

        public override bool Equals(object obj) {
            DQWord dQWord = (DQWord)obj;
            if (dQWord.Value1 == Value1) {
                return dQWord.Value2 == Value2;
            }
            return false;
        }

        public override int GetHashCode() {
            return Value1.GetHashCode() + Value2.GetHashCode();
        }

        public static byte[] DQWordToBytes(DQWord Value) {
            byte[] bytes = BitConverter.GetBytes(Value.Value1);
            byte[] bytes2 = BitConverter.GetBytes(Value.Value2);
            List<byte> list = new List<byte>();
            list.AddRange(bytes);
            list.AddRange(bytes2);
            return list.ToArray();
        }

        public static DQWord StringToDQWord(string InStr) {
            DQWord dQWord = new DQWord(ulong.Parse(InStr.Remove(16), NumberStyles.HexNumber), ulong.Parse(InStr.Remove(0, 16), NumberStyles.HexNumber));
            dQWord.ToBig();
            return dQWord;
        }
    }


}
