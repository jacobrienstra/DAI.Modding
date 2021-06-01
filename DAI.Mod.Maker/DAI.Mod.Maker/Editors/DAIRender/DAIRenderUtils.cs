using DAI.AssetLibrary.Assets.Bases;

using SlimDX.DXGI;

namespace DAI.Mod.Maker.DAIRender {
    public static class DAIRenderUtils {
        public static Format GetPixelFormat(TextureFormat PixelFormat) {
            switch (PixelFormat) {
                case TextureFormat.TF_DXT1:
                case TextureFormat.TF_DXT1A:
                    return Format.BC1_UNorm;
                case TextureFormat.TF_DXT5:
                    return Format.BC3_UNorm;
                case TextureFormat.TF_DXT5A:
                    return Format.R8_UNorm;
                case TextureFormat.TF_ARGB8888:
                    return Format.B8G8R8A8_UNorm;
                case TextureFormat.TF_L8:
                    return Format.R8_UNorm;
                case TextureFormat.TF_L16:
                    return Format.R16_UNorm;
                case TextureFormat.TF_ABGR32F:
                    return Format.R32G32B32A32_Float;
                case TextureFormat.TF_NormalDXN:
                    return Format.BC5_UNorm;
                case TextureFormat.TF_NormalDXT1:
                    return Format.BC1_UNorm;
                case TextureFormat.TF_R9G9B9E5F:
                    return Format.R9G9B9E5_SharedExp;
                default:
                    return Format.BC1_UNorm;
            }
        }

        public static int GetTexturePitch(TextureFormat PixelFormat, int Width) {
            switch (PixelFormat) {
                case TextureFormat.TF_DXT1:
                case TextureFormat.TF_DXT1A:
                    return (Width + 3) / 4 * 8;
                case TextureFormat.TF_DXT5:
                    return (Width + 3) / 4 * 16;
                case TextureFormat.TF_DXT5A:
                    return (Width * 8 + 7) / 8;
                case TextureFormat.TF_ARGB8888:
                    return (Width * 32 + 7) / 8;
                case TextureFormat.TF_L8:
                    return (Width * 8 + 7) / 8;
                case TextureFormat.TF_L16:
                    return (Width * 16 + 7) / 8;
                case TextureFormat.TF_ABGR32F:
                    return (Width * 128 + 7) / 8;
                case TextureFormat.TF_NormalDXN:
                    return (Width + 3) / 4 * 16;
                case TextureFormat.TF_NormalDXT1:
                    return (Width + 3) / 4 * 8;
                case TextureFormat.TF_R9G9B9E5F:
                    return (Width * 32 + 7) / 8;
                default:
                    return 0;
            }
        }
    }
}
