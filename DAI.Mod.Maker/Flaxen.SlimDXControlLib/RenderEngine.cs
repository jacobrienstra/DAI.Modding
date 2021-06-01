using System;

using SlimDX.Direct3D11;
using SlimDX.DXGI;

namespace Flaxen.SlimDXControlLib {
    public abstract class RenderEngine : IDisposable {
        private bool m_disposed;

        protected SlimDXControl Control { get; set; }

        protected SlimDX.Direct3D11.Device Device { get; set; }

        protected DeviceContext DeviceContext => Device.ImmediateContext;

        public Texture2D SharedTexture { get; set; }

        protected SwapChain SwapChain { get; set; }

        protected int WindowHeight { get; set; }

        protected int WindowWidth { get; set; }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (!m_disposed) {
                if (disposing) {
                    DisposeManaged();
                }
                DisposeUnmanaged();
                m_disposed = true;
            }
        }

        protected virtual void DisposeManaged() {
        }

        protected virtual void DisposeUnmanaged() {
        }

        ~RenderEngine() {
            Dispose(false);
        }

        public abstract void Initialize(SlimDXControl control);

        public abstract void Reinitialize(int width, int height);

        public abstract void Render(double DeltaTime);
    }
}
