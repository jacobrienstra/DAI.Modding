using System;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.Utilities {
    public static class BinaryWriterExt {
        public static void Write(this BinaryWriter Writer, Sha1 Value) {
            Writer.Write(Value.BytesValue);
        }
    }
    public class Sha1 {

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

        public Sha1(byte[] Values) => BytesValue = Values;

        public Sha1(string Value) {
            BytesValue = Value.ToSha1Bytes();
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

        public string Get20Sha1From40Sha1(string value) {
            if (string.IsNullOrEmpty(value)) {
                return null;
            }
            char[] bytes = new char[20];
            for (int i = 0; i < 40; i += 2) {
                string s = value.Substring(0, 2);
                value = value.Remove(0, 2);
                char num4 = (char)byte.Parse(s, NumberStyles.HexNumber);
                bytes[i / 2] = num4;
            }
            return new string(bytes);
        }
    }
}
