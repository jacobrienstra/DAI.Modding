using System;
using System.Windows.Forms;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;
using DAI.ModMaker.Properties;

namespace DAI.ModMaker.DAIModules.Export {
    public class HeadMorphExport : DAIBaseExporter {
        public string[] GetAssetTypes() {
            return new string[1] { "MorphStatic" };
        }

        public string[] GetExtensions() {
            return new string[1] { "obj" };
        }

        public Mesh GetHeadMorphAsMesh(MorphStatic MorphAsset) {
            ResRef res = Library.GetResByResRid(MorphAsset.MorphResource);
            if (res == null) {
                MessageBox.Show($"Could not find related Res [{res.ResRid}]");
                return null;
            }
            return Mesh.FromRes(Library.GetResByResRid(DAI.ModMaker.Utilities.Utilities.GetNativeObject<SkinnedMeshAsset>(Library.GetEbxByGuid(MorphAsset.RuntimeHeadBase.Id.FileGuid)).MeshSetResource));
        }

        public bool Run(AssetContainer InContainer, string OutPath, out string Errors) {
            MeshExportConfig meshExportConfig = new MeshExportConfig();
            meshExportConfig.ShowDialog();
            if (meshExportConfig.Cancelled) {
                Errors = "";
                return false;
            }
            Mesh headMorphAsMesh = GetHeadMorphAsMesh((MorphStatic)InContainer.RootObject);
            if (headMorphAsMesh == null) {
                Errors = "Could not load headmorph";
                return false;
            }
            try {
                headMorphAsMesh.ExportAsObj(OutPath, 3, Settings.Default.GlobalMeshScale, "_headmorph");
            } catch (Exception ex) {
                Errors = "Could not export mesh.  Exception:" + ex.Message;
                return false;
            }
            Errors = "";
            return true;
        }
    }
}
