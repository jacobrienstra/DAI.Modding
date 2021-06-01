using System.Collections.Generic;

using SlimDX;

namespace DAI.Mod.Maker.DAIRender {
    public class Octree {
        public List<OctreeBranch> Branches;

        public Octree() {
            Branches = new List<OctreeBranch>();
            float single = 4096f;
            float single2 = 4096f;
            float single3 = 4096f;
            _ = Vector3.Zero;
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 2; j++) {
                    for (int k = 0; k < 2; k++) {
                        OctreeBranch octreeBranch = new OctreeBranch(new Vector3(((k < 1) ? (0f - single) : single) * 0.5f, ((j < 1) ? (0f - single2) : single2) * 0.5f, ((i < 1) ? (0f - single3) : single3) * 0.5f), new Vector3(single, single2, single3));
                        Branches.Add(octreeBranch);
                    }
                }
            }
        }

        public void AddMesh(RenderMesh Mesh) {
            foreach (OctreeBranch branch in Branches) {
                if (BoundingBox.Contains(branch.BBox, Mesh.BSphere.Center) != 0) {
                    branch.AddMesh(Mesh);
                    break;
                }
            }
        }
    }
}
