using System;
using System.Runtime.InteropServices;

using SlimDX.Direct3D11;
using SlimDX.Direct3D9;

namespace Flaxen.SlimDXControlLib {
    internal static class D3DDeviceManager {
        internal static class SafeNativeMethods {
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
        }

        private static int s_numActiveImages;

        private static Direct3DEx s_d3dContext;

        private static DeviceEx s_d3dDevice;

        public static Texture SharedTexture { get; private set; }

        static D3DDeviceManager() {
            s_numActiveImages = 0;
        }

        public static void ClearSharedTexture() {
            if (SharedTexture != null) {
                SharedTexture.Dispose();
                SharedTexture = null;
            }
        }

        public static void Create() {
            if (s_numActiveImages <= 0) {
                InitD3D9();
                s_numActiveImages++;
            }
        }

        public static void CreateSharedTexture(Texture2D texture) {
            SlimDX.Direct3D9.Format format = TranslateFormat(texture);
            if (format == SlimDX.Direct3D9.Format.Unknown) {
                throw new ArgumentException("Texture format is not compatible with OpenSharedResource");
            }
            IntPtr sharedHandle = GetSharedHandle(texture);
            if (sharedHandle == IntPtr.Zero) {
                throw new ArgumentException("Texture handle is null");
            }
            DeviceEx device = s_d3dDevice;
            int width = texture.Description.Width;
            SharedTexture = new Texture(device, width, texture.Description.Height, 1, SlimDX.Direct3D9.Usage.RenderTarget, format, Pool.Default, ref sharedHandle);
        }

        public static void Destroy() {
            s_numActiveImages--;
            ClearSharedTexture();
            ShutdownD3D9();
        }

        private static IntPtr GetSharedHandle(Texture2D texture) {
            SlimDX.DXGI.Resource resource = new SlimDX.DXGI.Resource(texture);
            IntPtr sharedHandle = resource.SharedHandle;
            resource.Dispose();
            return sharedHandle;
        }

        private static void InitD3D9() {
            s_d3dContext = new Direct3DEx();
            PresentParameters presentParameter = new PresentParameters {
                Windowed = true,
                SwapEffect = SlimDX.Direct3D9.SwapEffect.Discard,
                DeviceWindowHandle = SafeNativeMethods.GetDesktopWindow(),
                PresentationInterval = PresentInterval.Immediate
            };
            s_d3dDevice = new DeviceEx(s_d3dContext, 0, DeviceType.Hardware, IntPtr.Zero, CreateFlags.Multithreaded | CreateFlags.HardwareVertexProcessing | CreateFlags.FpuPreserve, presentParameter);
        }

        private static void ShutdownD3D9() {
            if (s_d3dDevice != null) {
                s_d3dDevice.Dispose();
                s_d3dDevice = null;
            }
            if (s_d3dContext != null) {
                s_d3dContext.Dispose();
                s_d3dContext = null;
            }
        }

        private static SlimDX.Direct3D9.Format TranslateFormat(Texture2D texture) {
            switch (texture.Description.Format) {
                case SlimDX.DXGI.Format.R16G16B16A16_Float:
                    return SlimDX.Direct3D9.Format.A16B16G16R16F;
                case SlimDX.DXGI.Format.R10G10B10A2_UNorm:
                    return SlimDX.Direct3D9.Format.A2B10G10R10;
                case SlimDX.DXGI.Format.B8G8R8A8_UNorm:
                    return SlimDX.Direct3D9.Format.A8R8G8B8;
                default:
                    return SlimDX.Direct3D9.Format.Unknown;
            }
        }
    }
}
