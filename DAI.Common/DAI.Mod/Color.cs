namespace DAI.Mod {
    public class Color {
        public float R;

        public float G;

        public float B;

        public float A;

        public Color(float InR, float InG, float InB, float InA) {
            R = InR;
            G = InG;
            B = InB;
            A = InA;
        }

        public override string ToString() {
            object[] r = new object[4] { R, G, B, A };
            return string.Format("({0:0.000}, {1:0.000}, {2:0.000}, {3:0.000})", r);
        }
    }
}
