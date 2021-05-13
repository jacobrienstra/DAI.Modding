using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;

namespace DAI.ModMaker.DAIModules
{
    public interface DAIBasePreviewer
    {
        string[] GetAssetTypes();

        void Run(AssetContainer InContainer, EbxRef InAsset);
    }
}
