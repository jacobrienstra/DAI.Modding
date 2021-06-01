using System.Collections.Generic;

namespace DAI.AssetLibrary.Assets.References {
    public class ResNameComparer : IEqualityComparer<ResRef> {
        public bool Equals(ResRef x, ResRef y) {
            return x.Name == y.Name;
        }

        public int GetHashCode(ResRef obj) {
            return obj.Name.GetHashCode();
        }
    }
}
