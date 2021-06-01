using System.IO;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;
using DAI.FrostbiteAssets;
using DAI.ModMaker.Utilities;

namespace DAI.ModMaker.DAIModules.Export {
    public class ScriptExport : DAIBaseExporter {
        public string[] GetAssetTypes() {
            return new string[1] { "Script" };
        }

        public string[] GetExtensions() {
            return new string[1] { "lua" };
        }

        public bool Run(AssetContainer InContainer, string OutPath, out string Errors) {
            EbxRef ebx = Library.GetEbxByGuid(((Script)InContainer.RootObject).CompiledLua.Id.FileGuid);
            if (ebx != null) {
                AssetContainer container = EbxBase.FromEbx(ebx).GetContainer();
                if (container.IsValid()) {
                    BinaryReader binaryReader = new BinaryReader(new MemoryStream(PayloadProvider.GetAssetPayload(Library.GetResByResRid(((LuaRunnerCompiledLua)container.RootObject).CompiledLuaResource))));
                    StreamWriter streamWriter = new StreamWriter(OutPath);
                    if (binaryReader.ReadUInt32() != 3783589897u) {
                        Errors = "Bad DAI luac header magic";
                        return false;
                    }
                    binaryReader.BaseStream.Seek(24L, SeekOrigin.Begin);
                    binaryReader.ReadNullTerminatedString();
                    binaryReader.ReadNullTerminatedString();
                    if (binaryReader.ReadUInt32() != 1635077147) {
                        Errors = "Bad luac header magic";
                        return false;
                    }
                    binaryReader.BaseStream.Seek(12L, SeekOrigin.Current);
                    streamWriter.Write(binaryReader.ReadNullTerminatedString());
                    streamWriter.Close();
                    binaryReader.Close();
                    Errors = "";
                    return true;
                }
            }
            Errors = "Unable to obtain luac resource";
            return false;
        }
    }
}
