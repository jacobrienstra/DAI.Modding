using System.Collections.Generic;

namespace DAI.Mod.Maker {
    public class LevelLayer {
        public string Name;

        public bool IsVisible;

        public int Index;

        public LevelLayer Parent;

        public List<LevelLayer> Children;

        public List<LevelObject> Objects;

        public LevelLayer(string InName, int InIndex, LevelLayer InParent = null) {
            Name = InName;
            Index = InIndex;
            IsVisible = true;
            Parent = InParent;
            Children = new List<LevelLayer>();
            Objects = new List<LevelObject>();
        }

        public void SetVisibility(bool NewVisible) {
            IsVisible = NewVisible;
            foreach (LevelLayer child in Children) {
                child.SetVisibility(NewVisible);
            }
        }

        public override string ToString() {
            return "[" + (IsVisible ? "X" : " ") + "] " + Name;
        }
    }
}
