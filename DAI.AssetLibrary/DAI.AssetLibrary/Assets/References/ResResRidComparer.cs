using System.Collections.Generic;

namespace DAI.AssetLibrary.Assets.References {
    public class ResResRidComparer : IEqualityComparer<ResRef> {
        public bool Equals(ResRef x, ResRef y) {
            return x.ResRid == y.ResRid;
        }

        public int GetHashCode(ResRef obj) {
            return obj.ResRid.GetHashCode();
        }
    }
}
