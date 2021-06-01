using DAI.AssetLibrary.Assets.References;

namespace DAI.ModMaker.Utilities {
    public class EbxRefWrapper {
        public EbxRef Ebx { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string DisplayFullName { get; set; }

        public string AssetType { get; set; }

        public bool IsAdded => Ebx.State == EntryState.Added;

        public bool IsModified => Ebx.State == EntryState.Modified;

        public bool IsDeleted => Ebx.State == EntryState.Deleted;

        public EbxRefWrapper(EbxRef ebx) {
            Ebx = ebx;
            string ebxName = Ebx.Name;
            int index = ebxName.LastIndexOf("/");
            if (index != -1) {
                ebxName = ebxName.Substring(index + 1);
            }
            Name = ebxName;
            DisplayName = string.Format("{0,-50} {1}", $"[{Ebx.AssetType}]", ebxName);
            DisplayFullName = $"[{Ebx.AssetType}] {Ebx.Name}";
            AssetType = ebx.AssetType;
        }
    }
}
