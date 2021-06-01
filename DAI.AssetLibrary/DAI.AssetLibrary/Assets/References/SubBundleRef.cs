using System.Linq;

using DAI.AssetLibrary.Utilities;

namespace DAI.AssetLibrary.Assets.References {
    public class SubBundleRef : EntryRef {
        public string Path { get; set; }

        internal HashedList<ChunkRef> Chunks { get; set; }

        internal HashedList<EbxRef> Ebx { get; set; }

        internal HashedList<ResRef> Res { get; set; }

        internal HashedList<ChunkMetaRef> ChunkMeta { get; set; }

        public bool Base { get; set; }

        public bool Delta { get; set; }

        public EntryState State { get; internal set; }

        public bool IsJson { get; internal set; }

        public SubBundleRef() {
            Path = string.Empty;
            Base = false;
            Delta = false;
            Chunks = new HashedList<ChunkRef>();
            Ebx = new HashedList<EbxRef>();
            Res = new HashedList<ResRef>();
            ChunkMeta = new HashedList<ChunkMetaRef>();
            State = EntryState.NoChanges;
        }

        public ResRef[] GetSbRes() {
            return Res.ToArray();
        }

        public EbxRef[] GetSbEbx() {
            return Ebx.ToArray();
        }

        public ChunkRef[] GetSbChunks() {
            return Chunks.ToArray();
        }

        public bool Contains(ResRef res) {
            return Res.Contains(res);
        }

        public bool Contains(EbxRef ebx) {
            return Ebx.Contains(ebx);
        }

        public bool Contains(ChunkRef chunk) {
            return Chunks.Contains(chunk);
        }
    }
}
