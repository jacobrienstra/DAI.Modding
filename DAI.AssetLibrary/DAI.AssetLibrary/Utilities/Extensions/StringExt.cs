using System.Security.Cryptography;
using System.Text;

namespace DAI.AssetLibrary.Utilities.Extensions {
    public static class StringExt {
        public static string ToSha1(this string str) {
            return Encoding.UTF8.GetBytes(str).ToSha1();
        }

        public static int Hash(this string StrToHash) {
            int num = 5381;
            for (int i = 0; i < StrToHash.Length; i++) {
                byte strToHash = (byte)StrToHash[i];
                num = (num * 33) ^ strToHash;
            }
            return num;
        }

        public static string ToSha1(this byte[] strArray) {
            byte[] retArray;
            using (SHA1CryptoServiceProvider provider = new SHA1CryptoServiceProvider()) {
                retArray = provider.ComputeHash(strArray);
            }
            return retArray.ToHex();
        }
    }
}
