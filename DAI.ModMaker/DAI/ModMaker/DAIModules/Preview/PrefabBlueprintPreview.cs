using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;

namespace DAI.ModMaker.DAIModules.Preview
{
    public class PrefabBlueprintPreview : DAIBasePreviewer
    {
        public string[] GetAssetTypes()
        {
            return new string[2] { "LogicPrefabBlueprint", "PrefabBlueprint" };
        }

        public void Run(AssetContainer InContainer, EbxRef InAsset)
        {
            new PrefabBlueprintPreviewWindow((PrefabBlueprint)InContainer.RootObject).Show();
        }
    }
}
