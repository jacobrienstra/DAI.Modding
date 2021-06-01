using System.IO;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.FrostbiteAssets;
using DAI.ModMaker.Utilities;

namespace DAI.ModMaker.DAIModules.Import {
    public class ScriptImporter : DAIBaseImporter {
        public string[] GetAssetTypes() {
            return new string[1] { "Script" };
        }

        public string[] GetExtensions() {
            return new string[1] { "luac" };
        }

        public bool Run(AssetContainer InContainer, string InPath, out string Errors) {
            FileStream fileStream = new FileStream(InPath, FileMode.Open, FileAccess.Read);
            byte[] numArray = new byte[fileStream.Length];
            fileStream.Read(numArray, 0, (int)fileStream.Length);
            fileStream.Close();
            EbxRef ebx = Library.GetEbxByGuid(((Script)InContainer.RootObject).CompiledLua.Id.FileGuid);
            if (ebx != null) {
                AssetContainer container = EbxBase.FromEbx(ebx).GetContainer();
                if (container.IsValid()) {
                    LibraryManager.ModifyRes(Library.GetResByResRid(((LuaRunnerCompiledLua)container.RootObject).CompiledLuaResource), numArray, false);
                    Errors = "";
                    return true;
                }
            }
            Errors = "Something went wrong!";
            return false;
        }
    }
}
