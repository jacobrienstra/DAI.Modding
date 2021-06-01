using System;
using System.Windows;

using SlimDX;
using SlimDX.Direct3D11;
using SlimDX.DXGI;

namespace Flaxen.SlimDXControlLib {
    public abstract class SimpleRenderEngine : RenderEngine {
        protected Texture2D DepthTexture { get; set; }

        protected DepthStencilView SampleDepthView { get; set; }

        protected RenderTargetView SampleRenderView { get; set; }

        protected override void DisposeManaged() {
            if (SampleRenderView != null) {
                SampleRenderView.Dispose();
                SampleRenderView = null;
            }
            if (SampleDepthView != null) {
                SampleDepthView.Dispose();
                SampleDepthView = null;
            }
            if (DepthTexture != null) {
                DepthTexture.Dispose();
                DepthTexture = null;
            }
            if (base.Device != null) {
                base.Device.Dispose();
                base.Device = null;
            }
            base.DisposeManaged();
        }

        protected override void DisposeUnmanaged() {
        }

        public override void Initialize(SlimDXControl control) {
            try {
                base.Control = control;
                SwapChainDescription swapChainDescription = default(SwapChainDescription);
                swapChainDescription.BufferCount = 1;
                swapChainDescription.Usage = Usage.RenderTargetOutput;
                swapChainDescription.OutputHandle = (IntPtr)0;
                swapChainDescription.IsWindowed = true;
                swapChainDescription.ModeDescription = new ModeDescription(0, 0, new Rational(60, 1), Format.R8G8B8A8_UNorm);
                swapChainDescription.SampleDescription = new SampleDescription(1, 0);
                swapChainDescription.Flags = SwapChainFlags.AllowModeSwitch;
                swapChainDescription.SwapEffect = SwapEffect.Discard;
                FeatureLevel[] featureLevelArray = new FeatureLevel[1] { FeatureLevel.Level_11_0 };
                base.Device = new SlimDX.Direct3D11.Device(DriverType.Hardware, DeviceCreationFlags.None, featureLevelArray);
                Reinitialize(400, 400);
            } catch (Exception ex) {
                if (ex.Message.Contains("DXGI_ERROR_UNSUPPORTED")) {
                    MessageBox.Show("Could not load SlimDX.\nPlease make sure you have SlimDX SDK and DirectX11 installed on your computer.");
                    return;
                }
                throw;
            }
        }

        public override void Reinitialize(int width, int height) {
            try {
                if (width <= 0) {
                    throw new ArgumentOutOfRangeException("width", "width must be greater than zero");
                }
                if (height <= 0) {
                    throw new ArgumentOutOfRangeException("height", "height must be greater than zero");
                }
                if (base.SharedTexture != null) {
                    base.SharedTexture.Dispose();
                    base.SharedTexture = null;
                    DepthTexture.Dispose();
                    DepthTexture = null;
                    SampleRenderView.Dispose();
                    SampleRenderView = null;
                    SampleDepthView.Dispose();
                    SampleDepthView = null;
                }
                base.WindowWidth = width;
                base.WindowHeight = height;
                Texture2DDescription texture2DDescription3 = default(Texture2DDescription);
                texture2DDescription3.BindFlags = BindFlags.ShaderResource | BindFlags.RenderTarget;
                texture2DDescription3.Format = Format.B8G8R8A8_UNorm;
                texture2DDescription3.Width = base.WindowWidth;
                texture2DDescription3.Height = base.WindowHeight;
                texture2DDescription3.MipLevels = 1;
                texture2DDescription3.SampleDescription = new SampleDescription(1, 0);
                texture2DDescription3.Usage = ResourceUsage.Default;
                texture2DDescription3.OptionFlags = ResourceOptionFlags.Shared;
                texture2DDescription3.CpuAccessFlags = CpuAccessFlags.None;
                texture2DDescription3.ArraySize = 1;
                Texture2DDescription texture2DDescription = texture2DDescription3;
                texture2DDescription3 = default(Texture2DDescription);
                texture2DDescription3.BindFlags = BindFlags.DepthStencil;
                texture2DDescription3.Format = Format.D24_UNorm_S8_UInt;
                texture2DDescription3.Width = base.WindowWidth;
                texture2DDescription3.Height = base.WindowHeight;
                texture2DDescription3.MipLevels = 1;
                texture2DDescription3.SampleDescription = new SampleDescription(1, 0);
                texture2DDescription3.Usage = ResourceUsage.Default;
                texture2DDescription3.OptionFlags = ResourceOptionFlags.None;
                texture2DDescription3.CpuAccessFlags = CpuAccessFlags.None;
                texture2DDescription3.ArraySize = 1;
                Texture2DDescription texture2DDescription2 = texture2DDescription3;
                base.SharedTexture = new Texture2D(base.Device, texture2DDescription);
                DepthTexture = new Texture2D(base.Device, texture2DDescription2);
                SampleRenderView = new RenderTargetView(base.Device, base.SharedTexture);
                SampleDepthView = new DepthStencilView(base.Device, DepthTexture);
            } catch (Exception ex) {
                if (ex.Message.Contains("DXGI_ERROR_UNSUPPORTED")) {
                    MessageBox.Show("Could not load SlimDX.\nPlease make sure you have SlimDX SDK and DirectX11 installed on your computer.");
                }
            }
        }
    }
}
