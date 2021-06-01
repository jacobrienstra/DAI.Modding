using System.Collections.Generic;
using System.IO;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.FrostbiteAssets;

namespace DAI.ModMaker.DAIModules.Export {
    public class TextureExport : DAIBaseExporter {
        public Dictionary<TextureFormat, int> PixelFormatTypes = new Dictionary<TextureFormat, int>
        {
            {
                TextureFormat.TF_DXT1,
                827611204
            },
            {
                TextureFormat.TF_NormalDXT1,
                827611204
            },
            {
                TextureFormat.TF_DXT1A,
                1093752900
            },
            {
                TextureFormat.TF_DXT5,
                894720068
            },
            {
                TextureFormat.TF_DXT5A,
                826889281
            },
            {
                TextureFormat.TF_ABGR32F,
                116
            },
            {
                TextureFormat.TF_NormalDXN,
                843666497
            }
        };

        public string[] GetAssetTypes() {
            return new string[1] { "TextureAsset" };
        }

        public string[] GetExtensions() {
            return new string[1] { "dds" };
        }

        public bool Run(AssetContainer InContainer, string OutPath, out string Errors) {
            ResRef res = Library.GetResByResRid(((TextureAsset)InContainer.RootObject).Resource);
            if (res == null) {
                Errors = $"Could not find related Res [{res.ResRid}]";
                return false;
            }
            Texture dAITexture = Texture.FromRes(res);
            if (dAITexture.PixelFormat == TextureFormat.TF_R9G9B9E5F) {
                Errors = "Unable to export shared exponent textures at this time";
                return false;
            }
            FileStream fileStream = new FileStream(OutPath, FileMode.Create);
            DDS_HEADER dDS_HEADER = default(DDS_HEADER);
            dDS_HEADER.dwSize = 124;
            dDS_HEADER.dwFlags = 659471;
            dDS_HEADER.dwHeight = dAITexture.Height;
            dDS_HEADER.dwWidth = dAITexture.Width;
            dDS_HEADER.dwPitchOrLinearSize = dAITexture.MipSizes[0];
            dDS_HEADER.dwDepth = dAITexture.Depth;
            dDS_HEADER.dwMipMapCount = dAITexture.NumSizes;
            dDS_HEADER.dwReserved1 = new int[11];
            dDS_HEADER.dwCaps = 4096;
            DDS_HEADER dDSHEADER = dDS_HEADER;
            for (int i = 0; i < 11; i++) {
                dDSHEADER.dwReserved1[i] = 0;
            }
            SetPixelFormatData(ref dDSHEADER, dAITexture.PixelFormat, dAITexture.TextureType);
            byte[] array = PayloadProvider.GetAssetPayload(Library.GetChunkById(dAITexture.ChunkID));
            dDSHEADER.Write(fileStream);
            fileStream.Write(array, 0, array.Length);
            fileStream.Close();
            Errors = "";
            return true;
        }

        public void SetPixelFormatData(ref DDS_HEADER Header, TextureFormat InFormat, TextureType InType) {
            Header.ddspf = default(DDS_HEADER.DDS_PIXELFORMAT);
            Header.dwCaps2 = 0;
            Header.ddspf.dwSize = 32;
            Header.ddspf.dwFlags = 4;
            Header.ddspf.dwFourCC = 827611204;
            Header.ddspf.dwRGBBitCount = 0;
            Header.ddspf.dwRBitMask = 0u;
            Header.ddspf.dwGBitMask = 0u;
            Header.ddspf.dwBBitMask = 0u;
            Header.ddspf.dwABitMask = 0;
            if (InType == TextureType.TT_Cube) {
                Header.dwCaps2 = 65024;
                Header.dwCaps |= 8;
            }
            if (!PixelFormatTypes.ContainsKey(InFormat)) {
                switch (InFormat) {
                    case TextureFormat.TF_ARGB8888:
                    case TextureFormat.TF_ABGR32F:
                        Header.ddspf.dwFourCC = 0;
                        Header.ddspf.dwRGBBitCount = ((InFormat == TextureFormat.TF_ABGR32F) ? 128 : 32);
                        Header.ddspf.dwRBitMask = 16711680u;
                        Header.ddspf.dwGBitMask = 65280u;
                        Header.ddspf.dwBBitMask = 255u;
                        Header.ddspf.dwABitMask = -16777216;
                        Header.ddspf.dwFlags = 65;
                        Header.dwFlags = -524289;
                        Header.dwFlags |= 8;
                        break;
                    case TextureFormat.TF_L8:
                        Header.ddspf.dwFourCC = 0;
                        Header.ddspf.dwRGBBitCount = 8;
                        Header.ddspf.dwABitMask = 255;
                        Header.ddspf.dwFlags = 2;
                        Header.dwFlags = -524289;
                        Header.dwFlags |= 8;
                        break;
                    case TextureFormat.TF_L16:
                        Header.ddspf.dwFourCC = 0;
                        Header.ddspf.dwRGBBitCount = 16;
                        Header.ddspf.dwRBitMask = 65535u;
                        Header.ddspf.dwFlags = 131072;
                        Header.dwFlags = -524289;
                        Header.dwFlags |= 8;
                        break;
                    case TextureFormat.TF_ABGR16:
                    case TextureFormat.TF_ABGR16F:
                        break;
                }
            } else {
                Header.ddspf.dwFourCC = PixelFormatTypes[InFormat];
                if (InFormat == TextureFormat.TF_DXT1A) {
                    Header.ddspf.dwFlags = Header.ddspf.dwFlags | 1;
                }
            }
        }
    }
}
