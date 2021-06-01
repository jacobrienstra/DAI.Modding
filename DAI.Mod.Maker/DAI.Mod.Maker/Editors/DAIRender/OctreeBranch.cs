using System.Collections.Generic;

using SlimDX;

namespace DAI.ModMaker.DAIRender {
    public class OctreeBranch {
        public List<OctreeBranch> Branches;

        public List<RenderMesh> Meshes;

        public Vector3 Center;

        public Vector3 Sizes;

        public BoundingBox BBox {
            get {
                Vector3 sizes = Sizes / 2f;
                return new BoundingBox(new Vector3(Center.X - sizes.X, Center.Y - sizes.Y, Center.Z - sizes.Z), new Vector3(Center.X + sizes.X, Center.Y + sizes.Y, Center.Z + sizes.Z));
            }
        }

        public OctreeBranch(Vector3 InCenter, Vector3 InSizes) {
            Branches = new List<OctreeBranch>();
            Meshes = new List<RenderMesh>();
            Center = InCenter;
            Sizes = InSizes;
        }

        public void AddMesh(RenderMesh Mesh) {
            if (Branches.Count == 0) {
                if (Meshes.Count + 1 <= 100) {
                    Meshes.Add(Mesh);
                    return;
                }
                Split();
            }
            foreach (OctreeBranch branch in Branches) {
                if (BoundingBox.Contains(branch.BBox, Mesh.BSphere.Center) != 0) {
                    branch.AddMesh(Mesh);
                    break;
                }
            }
        }

        public void Split() {
            float x = Sizes.X * 0.5f;
            float y = Sizes.Y * 0.5f;
            float z = Sizes.Z * 0.5f;
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 2; j++) {
                    for (int k = 0; k < 2; k++) {
                        OctreeBranch octreeBranch = new OctreeBranch(Center + new Vector3(((k < 1) ? (0f - x) : x) * 0.5f, ((j < 1) ? (0f - y) : y) * 0.5f, ((i < 1) ? (0f - z) : z) * 0.5f), new Vector3(x, y, z));
                        Branches.Add(octreeBranch);
                    }
                }
            }
            foreach (RenderMesh mesh in Meshes) {
                foreach (OctreeBranch branch in Branches) {
                    if (BoundingBox.Contains(branch.BBox, mesh.BSphere.Center) != 0) {
                        branch.AddMesh(mesh);
                        break;
                    }
                }
            }
            Meshes.Clear();
        }
    }
}
