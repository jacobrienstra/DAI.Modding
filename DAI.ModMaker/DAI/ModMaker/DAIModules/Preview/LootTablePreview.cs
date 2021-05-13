using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;

namespace DAI.ModMaker.DAIModules.Preview
{
    public class LootTablePreview : DAIBasePreviewer
    {
        public string[] GetAssetTypes()
        {
            return new string[1] { "LootTableObject" };
        }

        public void Run(AssetContainer InContainer, EbxRef InAsset)
        {
            new LootTablePreviewWindow(InContainer, (LootTableObject)InContainer.RootObject, InAsset).Show();
        }
    }
}
