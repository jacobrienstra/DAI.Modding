using DAI.AssetLibrary.Utilities;

namespace DAI.AssetLibrary.Assets.References {
    public class CatalogEntry {
        internal Sha1 Sha1 { get; set; }

        internal int Offset { get; set; }

        internal int Size { get; set; }

        internal string Path { get; set; }

        internal bool IsNew { get; set; }

        internal CatalogEntry() {
            IsNew = false;
        }
    }
}
