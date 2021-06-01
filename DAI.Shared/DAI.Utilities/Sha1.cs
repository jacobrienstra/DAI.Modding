using System;
using System.Security.Cryptography;

namespace DAI.Utilities {

    public class Sha1 {
        public static Sha1 ZeroSha1 = new Sha1();

        public byte[] Sha1Value;

        public Sha1() {
            Sha1Value = new byte[20];
        }

        public Sha1(byte[] Values) {
            Sha1Value = Values;
        }

        public static bool operator ==(Sha1 A, Sha1 B) {
            int num = 0;
            while (num < 20) {
                if (A.Sha1Value[num] != B.Sha1Value[num]) {
                    return false;
                }
                int num2 = num + 1;
                num = num2;
            }
            return true;
        }

        public static bool operator !=(Sha1 A, Sha1 B) {
            int num = 0;
            while (num < 20) {
                if (A.Sha1Value[num] != B.Sha1Value[num]) {
                    return true;
                }
                int num2 = num + 1;
                num = num2;
            }
            return false;
        }

        public override bool Equals(object obj) {
            if (obj.GetType() == typeof(Sha1)) {
                return this == (Sha1)obj;
            }
            return false;
        }

        public override int GetHashCode() {
            int num = 0;
            int num2 = 0;
            while (num2 < 5) {
                num += BitConverter.ToInt32(Sha1Value, num2 * 4).GetHashCode();
                int num3 = num2 + 1;
                num2 = num3;
            }
            return num;
        }

        public override string ToString() {
            string text = "";
            int num = 0;
            while (num < 20) {
                text += Sha1Value[num].ToString("X2");
                int num2 = num + 1;
                num = num2;
            }
            return text;
        }

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
    }
}
