using SlimDX;

namespace DAI.ModMaker.DAIRender
{
    public struct DirectionalLight
    {
        public Color4 Ambient;

        public Color4 Diffuse;

        public Color4 Specular;

        public Vector3 Direction;

        private float Padding;
    }
}
