using DAI.FrostbiteAssets;

namespace DAI.Mod.Maker.DAIModules {
    public interface DAIBaseImporter {
        string[] GetAssetTypes();

        string[] GetExtensions();

        bool Run(AssetContainer InContainer, string InPath, out string Errors);
    }
}
