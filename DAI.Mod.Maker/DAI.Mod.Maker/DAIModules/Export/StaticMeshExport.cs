using System;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;
using DAI.ModMaker.Properties;

namespace DAI.ModMaker.DAIModules.Export {
    public class StaticMeshExport : DAIBaseExporter {
        public string[] GetAssetTypes() {
            return new string[1] { "RigidMeshAsset" };
        }

        public string[] GetExtensions() {
            return new string[1] { "obj" };
        }

        public bool Run(AssetContainer InContainer, string OutPath, out string Errors) {
            MeshExportConfig meshExportConfig = new MeshExportConfig();
            meshExportConfig.ShowDialog();
            if (meshExportConfig.Cancelled) {
                Errors = "";
                return false;
            }
            ResRef res = Library.GetResByResRid(((RigidMeshAsset)InContainer.RootObject).MeshSetResource);
            if (res == null) {
                Errors = $"Could not find related Res [{res.ResRid}]";
                return false;
            }
            Mesh dAIMesh = Mesh.FromRes(res);
            try {
                dAIMesh.ExportAsObj(OutPath, 6, Settings.Default.GlobalMeshScale, "");
            } catch (Exception ex) {
                Errors = "Could not export mesh.  Exception:" + ex.Message;
                return false;
            }
            Errors = "";
            return true;
        }
    }
}
