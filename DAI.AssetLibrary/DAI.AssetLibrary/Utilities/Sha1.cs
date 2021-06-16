using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DAI.AssetLibrary.Utilities
{
    public static class BinaryWriterExt {
        public static void Write(this BinaryWriter Writer, Sha1 Value) {
            Writer.Write(Value.BytesValue);
        }
    }

    public static class BinaryReaderExt {
        public static Sha1 ReadSha1(this BinaryReader reader)
        {
            Sha1 sha = new Sha1();
            int num = 0;
            while (num < 20)
            {
                sha.BytesValue[num] = reader.ReadByte();
                int num2 = num + 1;
                num = num2;
            }
            return sha;
        }
    }

    public static class StringExt {
        public static Sha1 EncodeAsSha1(this string str) {
            return EncodeAsSha1(Encoding.UTF8.GetBytes(str));
        }

        public static Sha1 EncodeAsSha1(this byte[] strArray) {
            byte[] retArray;
            using (SHA1CryptoServiceProvider provider = new SHA1CryptoServiceProvider()) {
                retArray = provider.ComputeHash(strArray);
            }
            return new Sha1(retArray);
        }       
    }

    
    public class Sha1 {
        public static Sha1 Empty = new Sha1();
        public byte[] BytesValue { get; set; }
        public string HexStringValue {
            get => ToHexString();
            private set { }
        }

        public int HashCodeValue {
            get => GetHashCode();
            private set { }
        }

        public Sha1() {
            BytesValue = new byte[20];
        }

        public bool IsEmpty() {
            return this == Empty;
        }

        public Sha1(byte[] Values) => BytesValue = Values;
        public Sha1(string HexString) => BytesValue = Get20Sha1From40Sha1(HexString);

        public override int GetHashCode() {
            int sum = 0;
            for (int i = 0; i < 5; i++) {
                sum += BitConverter.ToInt32(BytesValue, i * 4).GetHashCode();
            }
            return sum;
        }

        public string ToHexString() {
            string text = "";
            for (int i = 0; i < 20; i++) {
                text += BytesValue[i].ToString("X2");
            }
            return text;
        }

        public override string ToString() {
            return ToHexString();
        }


        public static bool operator ==(Sha1 A, Sha1 B) {
            for(int i = 0; i < 20; i++) {
                if (A.BytesValue[i] != B.BytesValue[i]) {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(Sha1 A, Sha1 B) {
            for (int i = 0; i < 20; i++) {
                if (A.BytesValue[i] != B.BytesValue[i]) {
                    return true;
                }
            }
            return false;
        }

        public override bool Equals(object obj) {
            if (obj.GetType() == typeof(Sha1)) {
                return this == (Sha1)obj;
            }
            return false;
        }

       
        public byte[] Get20Sha1From40Sha1(string value) {
            if (string.IsNullOrEmpty(value)) {
                return null;
            }
            byte[] bytes = new byte[20];
            for (int i = 0; i < 40; i += 2) {
                string s = value.Substring(0, 2);
                value = value.Remove(0, 2);
                byte num4 = byte.Parse(s, NumberStyles.HexNumber);
                bytes[i / 2] = num4;
            }
            return bytes;
        }
    }
}
