using System.Security.Cryptography;
using System.Text;

using DAI.AssetLibrary.Utilities;

namespace DAI.AssetLibrary.Utilities.Extensions {
    public static class StringExt {
        

        public static int Hash(this string StrToHash) {
            int num = 5381;
            for (int i = 0; i < StrToHash.Length; i++) {
                byte strToHash = (byte)StrToHash[i];
                num = (num * 33) ^ strToHash;
            }
            return num;
        }
    }
}
