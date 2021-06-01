using SlimDX;

namespace DAI.Mod.Maker.DAIRender {
    internal struct GridVertex {
        public const int Stride = 12;

        public Vector3 Position;

        public GridVertex(Vector3 InPos) {
            Position = InPos;
        }
    }
}
