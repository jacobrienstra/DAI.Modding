using System;
using System.Collections.Generic;
using System.Globalization;


namespace DAI.Utilities {
    public class String {

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

        public static string MetaToString(byte[] InMeta) {
            if (InMeta == null) {
                return string.Empty;
            }
            string str = "";
            for (int i = 0; i < InMeta.Length; i++) {
                str += InMeta[i].ToString("X2");
            }
            return str;
        }

       
    }
}
