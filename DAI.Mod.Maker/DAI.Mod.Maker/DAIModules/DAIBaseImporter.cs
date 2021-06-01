using DAI.FrostbiteAssets;

namespace DAI.ModMaker.DAIModules {
    public interface DAIBaseImporter {
        string[] GetAssetTypes();

        string[] GetExtensions();

        bool Run(AssetContainer InContainer, string InPath, out string Errors);
    }
}
