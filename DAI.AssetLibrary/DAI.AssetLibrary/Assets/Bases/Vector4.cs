namespace DAI.AssetLibrary.Assets.Bases {
    public class Vector4 : Vector3 {
        public float W;

        public Vector4(float inX, float inY, float inZ, float inW) {
            X = inX;
            Y = inY;
            Z = inZ;
            W = inW;
        }

        public Vector4() {
            float single = 0f;
            W = single;
            float single2 = single;
            Z = single2;
            X = (Y = single2);
        }
    }
}
