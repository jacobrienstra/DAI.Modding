using System;

using DAI.AssetLibrary.Utilities.Extensions;
using DAI.AssetLibrary.Utilities;

namespace DAI.AssetLibrary.Assets.References {
    public class EbxRef : AssetEntryRef {
        public string Name { get; set; }

        public Sha1 Sha1 { get; set; }

        public long Size { get; set; }

        public long OriginalSize { get; set; }

        public int CasPatchType { get; set; }

        public Sha1 BaseSha1 { get; set; }

        public Sha1 DeltaSha1 { get; set; }

        public string AssetType { get; set; }

        public Guid FileGuid { get; set; }

        public uint NameHash => (uint)Name.Hash();

        public EbxRef() {
            Name = string.Empty;
            Sha1 = Sha1.Empty;
            AssetType = string.Empty;
            CasPatchType = 0;
            BaseSha1 = Sha1.Empty;
            DeltaSha1 = Sha1.Empty;
        }
    }
}
