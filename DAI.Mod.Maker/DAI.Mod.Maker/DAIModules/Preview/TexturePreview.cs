using System.Windows;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;

namespace DAI.Mod.Maker.DAIModules.Preview {
    public class TexturePreview : DAIBasePreviewer {
        public string[] GetAssetTypes() {
            return new string[1] { "TextureAsset" };
        }

        public void Run(AssetContainer InContainer, EbxRef InAsset) {
            TextureAsset rootObject = (TextureAsset)InContainer.RootObject;
            ResRef res = Library.GetResByResRid(rootObject.Resource);
            if (res == null) {
                MessageBox.Show($"Could not find related Res [{rootObject.Resource}]");
                return;
            }
            Texture dAITexture = Texture.FromRes(res);
            if (dAITexture.PixelFormat == TextureFormat.TF_DXT5A) {
                MessageBox.Show("Unable to preview DXT5A textures at this time.");
            } else {
                new TexturePreviewWindow(dAITexture).Show();
            }
        }
    }
}
