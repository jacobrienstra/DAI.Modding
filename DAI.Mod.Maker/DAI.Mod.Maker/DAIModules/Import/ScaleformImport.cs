using System.IO;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.FrostbiteAssets;

namespace DAI.Mod.Maker.DAIModules.Import {
    public class ScaleformImport : DAIBaseImporter {
        public string[] GetAssetTypes() {
            return new string[2] { "UIAsset", "UIWidgetAsset" };
        }

        public string[] GetExtensions() {
            return new string[1] { "gfx" };
        }

        public bool Run(AssetContainer InContainer, string InPath, out string Errors) {
            FileStream fileStream = new FileStream(InPath, FileMode.Open, FileAccess.Read);
            byte[] numArray = new byte[fileStream.Length];
            fileStream.Read(numArray, 0, (int)fileStream.Length);
            fileStream.Close();
            if ((numArray[0] != 71 && numArray[0] != 67) || numArray[1] != 70 || numArray[2] != 88) {
                Errors = "Not a valid import file";
                return false;
            }
            UIAsset rootObject = (UIAsset)InContainer.RootObject;
            ResRef res = null;
            res = ((rootObject.SwfMovieResource != 0L) ? Library.GetResByResRid(rootObject.SwfMovieResource) : Library.GetResByName(rootObject.Name));
            if (res == null) {
                Errors = $"Could not find related Res [{res.ResRid}]";
                return false;
            }
            LibraryManager.ModifyRes(res, numArray, false);
            Errors = "";
            return true;
        }
    }
}
