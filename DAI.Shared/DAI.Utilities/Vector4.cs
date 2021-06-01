namespace DAI.ModManager.Utils {
    public class Vector4 : Vector {
        public float W;

        public Vector4(float inX, float inY, float inZ, float inW) {
            X = inX;
            Y = inY;
            Z = inZ;
            W = inW;
        }

        public Vector4() {
            X = (Y = (Z = (W = 0f)));
        }
    }
}
