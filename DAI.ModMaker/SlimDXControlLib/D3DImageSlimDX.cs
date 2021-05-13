using System;
using System.Windows;
using System.Windows.Interop;

using SlimDX.Direct3D11;
using SlimDX.Direct3D9;

namespace Flaxen.SlimDXControlLib
{
    internal class D3DImageSlimDX : D3DImage, IDisposable
    {
        public D3DImageSlimDX()
        {
            D3DDeviceManager.Create();
        }

        public void Dispose()
        {
            SetBackBufferSlimDX(null);
            D3DDeviceManager.Destroy();
        }

        public void InvalidateD3DImage()
        {
            if (D3DDeviceManager.SharedTexture != null)
            {
                Lock();
                AddDirtyRect(new Int32Rect(0, 0, base.PixelWidth, base.PixelHeight));
                Unlock();
            }
        }

        private static bool IsShareable(Texture2D texture)
        {
            return (texture.Description.OptionFlags & ResourceOptionFlags.Shared) != 0;
        }

        public void SetBackBufferSlimDX(Texture2D texture)
        {
            D3DDeviceManager.ClearSharedTexture();
            if (texture == null)
            {
                Lock();
                SetBackBuffer(D3DResourceType.IDirect3DSurface9, IntPtr.Zero);
                Unlock();
                return;
            }
            if (!IsShareable(texture))
            {
                throw new ArgumentException("Texture must be created with ResourceOptionFlags.Shared");
            }
            D3DDeviceManager.CreateSharedTexture(texture);
            using (Surface surfaceLevel = D3DDeviceManager.SharedTexture.GetSurfaceLevel(0))
            {
                Lock();
                SetBackBuffer(D3DResourceType.IDirect3DSurface9, surfaceLevel.ComPointer);
                Unlock();
            }
        }
    }
}
