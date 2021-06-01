using System.IO;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.FrostbiteAssets;

namespace DAI.Mod.Maker.DAIModules.Export {
    public class ScaleformExport : DAIBaseExporter {
        public string[] GetAssetTypes() {
            return new string[2] { "UIAsset", "UIWidgetAsset" };
        }

        public string[] GetExtensions() {
            return new string[1] { "gfx" };
        }

        public bool Run(AssetContainer InContainer, string OutPath, out string Errors) {
            UIAsset rootObject = (UIAsset)InContainer.RootObject;
            ResRef res = null;
            res = ((rootObject.SwfMovieResource != 0L) ? Library.GetResByResRid(rootObject.SwfMovieResource) : Library.GetResByName(rootObject.Name.ToLower()));
            if (res == null) {
                Errors = $"Could not find related Res [{res.ResRid}]";
                return false;
            }
            BinaryReader binaryReader = new BinaryReader(new MemoryStream(PayloadProvider.GetAssetPayload(res)));
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(OutPath, FileMode.Create));
            while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length) {
                binaryWriter.Write(binaryReader.ReadByte());
            }
            binaryWriter.Close();
            binaryReader.Close();
            Errors = "";
            return true;
        }
    }
}
