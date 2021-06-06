
using System.Globalization;

namespace DAI.Utilities {
    public static class Meta {

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

        public static byte[] StringToMeta(string InStr) {
            byte[] array = new byte[InStr.Length / 2];
            int num = 0;
            while (num < array.Length) {
                string s = InStr.Substring(0, 2);
                InStr = InStr.Remove(0, 2);
                array[num] = byte.Parse(s, NumberStyles.HexNumber);
                int num2 = num + 1;
                num = num2;
            }
            return array;
        }
    }
}
