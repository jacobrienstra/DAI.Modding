using System;
using System.Collections.Generic;
using System.IO;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;
using DAI.FrostbiteAssets;
using DAI.Mod.Maker.Utilities;
using DAI.Mod.Maker.Properties;

namespace DAI.Mod.Maker.DAIModules.Import {
    public class HeadMorphImport : DAIBaseImporter {
        public string[] GetAssetTypes() {
            return new string[1] { "MorphStatic" };
        }

        public string[] GetExtensions() {
            return new string[1] { "obj" };
        }

        public bool Run(AssetContainer InContainer, string InFile, out string Errors) {
            MorphStatic rootObject = (MorphStatic)InContainer.RootObject;
            ResRef res = Library.GetResByResRid(rootObject.MorphResource);
            if (res == null) {
                Errors = $"Could not find related Res [{res.ResRid}]";
                return false;
            }
            byte[] assetPayload = PayloadProvider.GetAssetPayload(res);
            ResRef resAsset = Library.GetResByResRid(Utilities.Utils.GetNativeObject<SkinnedMeshAsset>(Library.GetEbxByGuid(rootObject.RuntimeHeadBase.Id.FileGuid)).MeshSetResource);
            try {
                Mesh dAIMesh = Mesh.FromRes(resAsset);
                if (dAIMesh == null) {
                    Errors = "Could not load mesh";
                    return false;
                }
                using (MemoryStream resultMs = new MemoryStream()) {
                    using (BinaryReader payloadReader = new BinaryReader(new MemoryStream(assetPayload))) {
                        using (BinaryWriter resultWriter = new BinaryWriter(resultMs)) {
                            string str = payloadReader.ReadNullTerminatedString();
                            resultWriter.WriteNullTerminatedString(str);
                            resultWriter.Write(payloadReader.ReadBytes(20));
                            Dictionary<int, Mesh.MeshObjLOD> lods = dAIMesh.ImportFromObj(InFile);
                            for (int lodIndex = 0; lodIndex < dAIMesh.LODLevels.Count && lodIndex < 3; lodIndex++) {
                                for (int soIndex = 0; soIndex < dAIMesh.LODLevels[lodIndex].SubObjects.Count; soIndex++) {
                                    LODSubObject current = dAIMesh.LODLevels[lodIndex].SubObjects[soIndex];
                                    if (current.SubObjectName == "") {
                                        continue;
                                    }
                                    string subObjectFullName = $"{current.SubObjectName.ToString()}_headmorph_{soIndex}_lod{lodIndex}";
                                    if (!lods.ContainsKey(lodIndex) || !lods[lodIndex].MeshObjGroups.ContainsKey(subObjectFullName)) {
                                        for (int i = 0; i < current.MeshBuffer.VertexBuffer.Count; i++) {
                                            resultWriter.Write(payloadReader.ReadSingle());
                                        }
                                        continue;
                                    }
                                    if (current.MeshBuffer.VertexBuffer.Count == lods[lodIndex].MeshObjGroups[subObjectFullName].Vertices.Count) {
                                        for (int j = 0; j < lods[lodIndex].MeshObjGroups[subObjectFullName].Vertices.Count; j++) {
                                            resultWriter.Write(lods[lodIndex].MeshObjGroups[subObjectFullName].Vertices[j].X / Settings.Default.GlobalMeshScale);
                                            resultWriter.Write(lods[lodIndex].MeshObjGroups[subObjectFullName].Vertices[j].Y / Settings.Default.GlobalMeshScale);
                                            resultWriter.Write(lods[lodIndex].MeshObjGroups[subObjectFullName].Vertices[j].Z / Settings.Default.GlobalMeshScale);
                                            payloadReader.ReadSingle();
                                            payloadReader.ReadSingle();
                                            payloadReader.ReadSingle();
                                            float sng = payloadReader.ReadSingle();
                                            resultWriter.Write(sng);
                                        }
                                        continue;
                                    }
                                    Errors = "Imported obj does not contain the same number of vertices as the base mesh in one of its LODs";
                                    return false;
                                }
                            }
                            while (payloadReader.BaseStream.Position < payloadReader.BaseStream.Length) {
                                resultWriter.Write(payloadReader.ReadByte());
                            }
                            LibraryManager.ModifyRes(res, resultMs.ToArray(), false);
                        }
                    }
                }
            } catch (Exception ex) {
                Errors = ex.Message;
                return false;
            }
            Errors = "";
            return true;
        }
    }
}
