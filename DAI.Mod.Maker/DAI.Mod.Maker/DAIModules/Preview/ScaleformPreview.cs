using System.IO;
using System.Windows;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.FrostbiteAssets;
using DAI.Mod.Maker.Utilities;


namespace DAI.Mod.Maker.DAIModules.Preview {
    public class ScaleformPreview : DAIBasePreviewer {
        public string[] GetAssetTypes() {
            return new string[2] { "UIAsset", "UIWidgetAsset" };
        }

        public void Run(AssetContainer InContainer, EbxRef InAsset) {
            UIAsset rootObject = (UIAsset)InContainer.RootObject;
            ResRef res = null;
            if (rootObject.SwfMovieResource == 0L) {
                rootObject.Name.ToLower();
                res = Library.GetResByName(rootObject.Name);
            } else {
                res = Library.GetResByResRid(rootObject.SwfMovieResource);
            }
            if (res == null) {
                MessageBox.Show($"Could not find related Res [{res.ResRid}]");
                return;
            }
            BinaryReader binaryReader = new BinaryReader(new MemoryStream(PayloadProvider.GetAssetPayload(res)));
            binaryReader.BaseStream.Seek(8L, SeekOrigin.Begin);
            byte[] numArray = new byte[binaryReader.BaseStream.Length - 8];
            binaryReader.BaseStream.Read(numArray, 0, (int)(binaryReader.BaseStream.Length - 8));
            byte[] numArray2 = null;
            AssetLibrary.Utilities.Utils.DecompressZlib(numArray, out numArray2);
            binaryReader.Close();
            new ScaleformPreviewWindow(numArray2).Show();
        }
    }
}
