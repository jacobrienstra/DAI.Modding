using System;

namespace DAI.Mod.Manager.Utilities {
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
            for(int i = 0; i < 20; i++) {
                if (A.Sha1Value[i] != B.Sha1Value[i]) {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(Sha1 A, Sha1 B) {
            for (int i = 0; i < 20; i++) {
                if (A.Sha1Value[i] != B.Sha1Value[i]) {
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
                sum += BitConverter.ToInt32(Sha1Value, i * 4).GetHashCode();
            }
            return sum;
        }

        public override string ToString() {
            string text = "";
            for (int i = 0; i < 20; i++) {
                text += Sha1Value[i].ToString("X2");
            }
            return text;
        }
    }
}
