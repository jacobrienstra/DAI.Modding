using SlimDX;

namespace DAI.ModMaker {
    public class LevelObject {
        public string Name;

        public string FullName;

        public Vector3 Position;

        public LevelObject(string InName, Matrix InMatrix) {
            Name = InName.Remove(0, InName.LastIndexOf('/') + 1);
            FullName = InName;
            Position = new Vector3(InMatrix.M41, InMatrix.M42, InMatrix.M43);
        }

        public override string ToString() {
            return Name;
        }
    }
}
