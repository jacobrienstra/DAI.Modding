using System;
using System.IO;
using System.Windows;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.FrostbiteAssets;

namespace DAI.Mod.Maker.DAIModules.Import {
    public class TextureImport : DAIBaseImporter {
        public string[] GetAssetTypes() {
            return new string[1] { "TextureAsset" };
        }

        public string[] GetExtensions() {
            return new string[1] { "dds" };
        }

        public bool Run(AssetContainer InContainer, string InFile, out string Errors) {
            Errors = "";
            TextureAsset obj = (TextureAsset)InContainer.RootObject;
            FileStream fileStream = new FileStream(InFile, FileMode.Open, FileAccess.Read);
            DDS_HEADER dDSHEADER = default(DDS_HEADER);
            dDSHEADER.Read(fileStream);
            byte[] numArray = new byte[fileStream.Length - 128];
            fileStream.Read(numArray, 0, (int)(fileStream.Length - 128));
            fileStream.Close();
            ResRef res = Library.GetResByResRid(obj.Resource);
            if (res == null) {
                Errors = $"Could not find related Res [{res.ResRid}]";
                return false;
            }
            Texture dAITexture = Texture.FromRes(res);
            if (dAITexture.PixelFormat == TextureFormat.TF_NormalDXT1 && dDSHEADER.ddspf.dwFourCC != 827611204 && MessageBox.Show("Original format was a DXT1 normalmap, are you sure you want to change the format?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.No) {
                return false;
            }
            if (dAITexture.TextureType == TextureType.TT_Cube && dDSHEADER.dwCaps2 != 65024) {
                Errors = "Original texture type is a cubemap. Imported texture format is not. Unable to continue";
                return false;
            }
            Texture firstMip = new Texture {
                MipOneEndOffset = 0u,
                MipTwoEndOffset = 0u,
                Unknown04 = dAITexture.Unknown04,
                PixelFormat = TextureFormat.TF_Unknown
            };
            switch (dDSHEADER.ddspf.dwFourCC) {
                case 0:
                    switch (dDSHEADER.ddspf.dwRGBBitCount) {
                        case 8:
                            firstMip.PixelFormat = TextureFormat.TF_L8;
                            break;
                        case 16:
                            firstMip.PixelFormat = TextureFormat.TF_L16;
                            break;
                        case 128:
                            firstMip.PixelFormat = TextureFormat.TF_ABGR32F;
                            break;
                        default:
                            firstMip.PixelFormat = TextureFormat.TF_ARGB8888;
                            break;
                    }
                    break;
                case 116:
                    firstMip.PixelFormat = TextureFormat.TF_ABGR32F;
                    break;
                case 827611204:
                    firstMip.PixelFormat = TextureFormat.TF_DXT1;
                    break;
                case 843666497:
                    firstMip.PixelFormat = TextureFormat.TF_NormalDXN;
                    break;
                case 894720068:
                    firstMip.PixelFormat = TextureFormat.TF_DXT5;
                    break;
            }
            if (firstMip.PixelFormat == TextureFormat.TF_Unknown) {
                Errors = "Attempted to import an unknown format";
                return false;
            }
            firstMip.FirstMip = dAITexture.FirstMip;
            firstMip.TextureType = ((dDSHEADER.dwCaps2 == 65024) ? TextureType.TT_Cube : TextureType.TT_2d);
            firstMip.NameHash = dAITexture.NameHash;
            firstMip.Width = (short)dDSHEADER.dwWidth;
            firstMip.Height = (short)dDSHEADER.dwHeight;
            firstMip.Depth = 1;
            firstMip.SliceCount = 1;
            firstMip.NumSizes = Convert.ToByte(dDSHEADER.dwMipMapCount);
            if (firstMip.NumSizes == 0) {
                firstMip.NumSizes = 1;
            }
            firstMip.ChunkSize = numArray.Length;
            int num2 = dDSHEADER.dwWidth;
            int num3 = dDSHEADER.dwHeight;
            if (dDSHEADER.ddspf.dwFourCC == 0) {
                int num4 = 0;
                switch (firstMip.PixelFormat) {
                    case TextureFormat.TF_ARGB8888:
                        num4 = 32;
                        break;
                    case TextureFormat.TF_L8:
                        num4 = 8;
                        break;
                    case TextureFormat.TF_L16:
                        num4 = 16;
                        break;
                    case TextureFormat.TF_ABGR16:
                    case TextureFormat.TF_ABGR16F: {
                            for (int i = 0; i < dDSHEADER.dwMipMapCount; i++) {
                                int num5 = num2;
                                int num6 = num3;
                                num5 = ((num5 < 1) ? 1 : num5);
                                num6 = ((num6 < 1) ? 1 : num6);
                                firstMip.MipSizes[i] = (num5 * num4 + 7) / 8 * num6;
                                num2 >>= 1;
                                num3 >>= 1;
                            }
                            break;
                        }
                    case TextureFormat.TF_ABGR32F:
                        num4 = 128;
                        break;
                }
            } else {
                int num7 = 8;
                TextureFormat pixelFormat = firstMip.PixelFormat;
                if (pixelFormat == TextureFormat.TF_DXT5 || pixelFormat == TextureFormat.TF_NormalDXN) {
                    num7 = 16;
                }
                for (int j = 0; j < dDSHEADER.dwMipMapCount; j++) {
                    int num8 = (num2 + 3) / 4;
                    int num9 = (num3 + 3) / 4;
                    num8 = ((num8 < 1) ? 1 : num8);
                    num9 = ((num9 < 1) ? 1 : num9);
                    firstMip.MipSizes[j] = num8 * num7 * num9;
                    num2 >>= 1;
                    num3 >>= 1;
                }
            }
            firstMip.Name = dAITexture.Name;
            LibraryManager.DeleteChunk(Library.GetChunkById(dAITexture.ChunkID));
            ChunkRef chunkAsset = new ChunkRef {
                Sha1 = Sha1.Empty
            };
            chunkAsset.ChunkId = Guid.NewGuid();
            chunkAsset.H32 = (int)firstMip.NameHash;
            chunkAsset.Meta = new byte[15]
            {
                8, 102, 105, 114, 115, 116, 77, 105, 112, 0,
                0, 0, 0, 0, 0
            };
            if (firstMip.NumSizes > 1) {
                chunkAsset.Meta[10] = 0;
            }
            firstMip.ChunkID = chunkAsset.ChunkId;
            ImportCompressData importCompressDatum = new ImportCompressData {
                FirstMipSize = firstMip.MipSizes[0],
                SecondMipSize = firstMip.MipSizes[0] + firstMip.MipSizes[1],
                MipSize = 0
            };
            int mipSizes = 0;
            for (int k = 0; k < chunkAsset.Meta[10]; k++) {
                mipSizes = (importCompressDatum.MipSize = mipSizes + firstMip.MipSizes[k]);
            }
            byte[] numArray2 = Utils.CompressData(numArray, ref importCompressDatum);
            firstMip.MipOneEndOffset = (uint)importCompressDatum.FirstMipEndOffset;
            firstMip.MipTwoEndOffset = (uint)importCompressDatum.SecondMipEndOffset;
            if (firstMip.NumSizes > 1) {
                chunkAsset.RangeStart = importCompressDatum.RangeStart;
                chunkAsset.RangeEnd = importCompressDatum.RangeEnd;
                chunkAsset.LogicalOffset = mipSizes;
            }
            chunkAsset.LogicalSize = numArray.Length - chunkAsset.LogicalOffset;
            LibraryManager.AddChunk(chunkAsset, numArray2, true);
            LibraryManager.AddToBundles(chunkAsset, res.ParentSbs);
            LibraryManager.ModifyRes(res, firstMip.WriteToStream().ToArray(), false);
            return true;
        }
    }
}
