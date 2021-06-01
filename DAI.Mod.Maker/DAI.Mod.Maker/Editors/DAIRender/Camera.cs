using SlimDX;

namespace DAI.Mod.Maker.DAIRender {
    public class Camera {
        public Matrix Proj { get; protected set; }

        public Matrix View { get; protected set; }

        public Matrix ViewProj => View * Proj;
    }
}
