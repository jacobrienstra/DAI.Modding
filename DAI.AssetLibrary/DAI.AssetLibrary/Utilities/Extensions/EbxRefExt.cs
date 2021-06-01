using DAI.AssetLibrary.Assets.References;

namespace DAI.AssetLibrary.Utilities.Extensions {
    public static class EbxRefExt {

        public static string GetDisplayFullName(this EbxRef ebx) {
            string ebxName = ebx.Name;
            int index = ebxName.LastIndexOf("/");
            if (index != -1) {
                ebxName = ebxName.Substring(index + 1);
            }
            return $"[{ebx.AssetType}] {ebxName}";
        }
    }
}
