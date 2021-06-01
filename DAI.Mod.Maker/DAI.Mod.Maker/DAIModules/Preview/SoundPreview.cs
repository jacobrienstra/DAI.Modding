using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;

namespace DAI.ModMaker.DAIModules.Preview {
    public class SoundPreview : DAIBasePreviewer {
        public string[] GetAssetTypes() {
            return new string[1] { "SoundWaveAsset" };
        }

        public void Run(AssetContainer InContainer, EbxRef InAsset) {
            new SoundPreviewWindow((SoundWaveAsset)InContainer.RootObject).Show();
        }
    }
}
