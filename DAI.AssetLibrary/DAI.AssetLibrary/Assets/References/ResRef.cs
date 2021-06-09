using DAI.AssetLibrary.Utilities;

namespace DAI.AssetLibrary.Assets.References {
    public class ResRef : AssetEntryRef {
        public string Name { get; set; }

        public Sha1 Sha1 { get; set; }

        public long Size { get; set; }

        public long OriginalSize { get; set; }

        public int ResType { get; set; }

        public byte[] ResMeta { get; set; }

        public long ResRid { get; set; }

        public int CasPatchType { get; set; }

        public Sha1 BaseSha1 { get; set; }

        public Sha1 DeltaSha1 { get; set; }

        public ResRef() {
            Name = string.Empty;
            Sha1 = Sha1.Empty;
            BaseSha1 = Sha1.Empty;
            DeltaSha1 = Sha1.Empty;
            CasPatchType = 0;
        }
    }
}
