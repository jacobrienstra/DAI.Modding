using System.Windows;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;

namespace DAI.Mod.Maker.DAIModules.Preview {
    public class MeshPreview : DAIBasePreviewer {
        public string[] GetAssetTypes() {
            return new string[3] { "SkinnedMeshAsset", "RigidMeshAsset", "CompositeMeshAsset" };
        }

        public void Run(AssetContainer InContainer, EbxRef InAsset) {
            ResRef res = Library.GetResByResRid(((MeshAsset)InContainer.RootObject).MeshSetResource);
            if (res == null) {
                MessageBox.Show($"Could not find related Res [{res.ResRid}]");
            } else {
                new MeshPreviewWindow(Mesh.FromRes(res)).Show();
            }
        }
    }
}
