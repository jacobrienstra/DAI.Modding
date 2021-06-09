using DAI.AssetLibrary.Utilities;

namespace DAI.AssetLibrary.Assets.References {
    public class DbxRef : EntryRef {
        public string Name { get; set; }

        public Sha1 Sha1 { get; set; }

        public long Size { get; set; }

        public long OriginalSize { get; set; }

        public byte[] IData { get; set; }
    }
}
