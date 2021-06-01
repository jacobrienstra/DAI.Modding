using SlimDX;

namespace DAI.ModMaker.DAIRender {
    internal struct QuadVertex {
        public const int Stride = 20;

        public Vector3 Position;

        public Vector2 TexCoord;

        public QuadVertex(Vector3 InPosition, Vector2 InTexCoord) {
            Position = InPosition;
            TexCoord = InTexCoord;
        }
    }
}
