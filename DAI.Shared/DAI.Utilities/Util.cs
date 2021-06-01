using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

using zlib;

namespace DAI.ModManager.Utils {
    public class Util {

      

        public static Sha1 CalculateSha1(byte[] InData) {
            byte[] values;
            using (SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider()) {
                values = sHA1CryptoServiceProvider.ComputeHash(InData);
            }
            return new Sha1(values);
        }

        public static Sha1 CalculateStringSha1(string InData) {
            return CalculateSha1(Encoding.UTF8.GetBytes(InData));
        }

        public static string MetaToString(byte[] InMeta) {
            string text = "";
            int num = 0;
            while (num < InMeta.Length) {
                text += InMeta[num].ToString("X2");
                int num2 = num + 1;
                num = num2;
            }
            return text;
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

        public static DQWord StringToDQWord(string InStr) {
            DQWord dQWord = new DQWord(ulong.Parse(InStr.Remove(16), NumberStyles.HexNumber), ulong.Parse(InStr.Remove(0, 16), NumberStyles.HexNumber));
            dQWord.ToBig();
            return dQWord;
        }


    }
}
