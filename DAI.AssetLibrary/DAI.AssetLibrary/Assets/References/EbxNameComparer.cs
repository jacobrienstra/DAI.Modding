using System.Collections.Generic;

namespace DAI.AssetLibrary.Assets.References {
    public class EbxNameComparer : IEqualityComparer<EbxRef> {
        public bool Equals(EbxRef x, EbxRef e) {
            return x.Name == e.Name;
        }

        public int GetHashCode(EbxRef obj) {
            return obj.Name.GetHashCode();
        }
    }
}
