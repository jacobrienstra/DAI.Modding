using SlimDX.Direct3D11;

namespace DAI.ModMaker.DAIRender {
    public abstract class RenderScene {
        public Device Device { get; set; }

        protected DeviceContext DeviceContext => Device.ImmediateContext;

        public bool UpdateRender { get; set; }

        public abstract void Dispose();

        public abstract void Initialize(Device InDevice);

        public abstract void Reinitialize(int width, int height);

        public abstract void Render(double DeltaTime);

        public abstract void Update(double DeltaTime);
    }
}
