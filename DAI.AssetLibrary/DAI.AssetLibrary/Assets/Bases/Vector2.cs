namespace DAI.AssetLibrary.Assets.Bases {
    public class Vector2 {
        public float X;

        public float Y;

        public Vector2(float inU, float inV) {
            X = inU;
            Y = inV;
        }

        public Vector2() {
            X = (Y = 0f);
        }
    }
}
