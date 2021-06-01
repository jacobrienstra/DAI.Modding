using DAI.FrostbiteAssets;

namespace DAI.Mod.Maker.DAIModules {
    public interface DAIBaseExporter {
        string[] GetAssetTypes();

        string[] GetExtensions();

        bool Run(AssetContainer InContainer, string OutFile, out string Errors);
    }
}
