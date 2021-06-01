using System;

using DAI.AssetLibrary.Utilities;

namespace DAI.AssetLibrary.Assets.References {
    public class AssetEntryRef : EntryRef {
        public Guid LibraryId { get; internal set; }

        public bool IsDelta { get; set; }

        public HashedList<SubBundleRef> ParentSbs { get; private set; }

        public HashedList<SubBundleRef> AddedSbs { get; private set; }

        public HashedList<SubBundleRef> RemovedSbs { get; private set; }

        public byte[] ModifiedData { get; internal set; }

        public long DataOriginalSize { get; internal set; }

        public EntryState State { get; internal set; }

        internal AssetEntryRef() {
            LibraryId = Guid.NewGuid();
            IsDelta = false;
            ParentSbs = new HashedList<SubBundleRef>();
            AddedSbs = new HashedList<SubBundleRef>();
            RemovedSbs = new HashedList<SubBundleRef>();
            State = EntryState.NoChanges;
            ModifiedData = null;
            DataOriginalSize = 0L;
        }
    }
}
