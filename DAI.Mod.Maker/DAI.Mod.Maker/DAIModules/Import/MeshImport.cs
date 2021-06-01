using System;
using System.Collections.Generic;
using System.IO;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;
using DAI.FrostbiteAssets;
using DAI.Mod.Maker.Properties;
using DAI.Mod.Maker.Utilities;

using AssetUtils = DAI.AssetLibrary.Utilities.Utilities;

namespace DAI.Mod.Maker.DAIModules.Import {
    public class MeshImport : DAIBaseImporter {
        private void ComputeTangentBasis(ref MeshBuffer MeshBuffer) {
            List<SlimDX.Vector3> vector3s = new List<SlimDX.Vector3>();
            List<SlimDX.Vector3> vector3s2 = new List<SlimDX.Vector3>();
            for (int i = 0; i < MeshBuffer.VertexBuffer.Count; i++) {
                vector3s.Add(default(SlimDX.Vector3));
                vector3s2.Add(default(SlimDX.Vector3));
            }
            for (int j = 0; j < MeshBuffer.IndexBuffer.Count; j++) {
                uint v1 = MeshBuffer.IndexBuffer[j].V1;
                uint v2 = MeshBuffer.IndexBuffer[j].V2;
                uint v3 = MeshBuffer.IndexBuffer[j].V3;
                SlimDX.Vector3 slimDXVector4 = MeshBuffer.VertexBuffer[(int)v1].Position.ToSlimDXVector3();
                SlimDX.Vector3 vector8 = MeshBuffer.VertexBuffer[(int)v2].Position.ToSlimDXVector3();
                SlimDX.Vector3 slimDXVector5 = MeshBuffer.VertexBuffer[(int)v3].Position.ToSlimDXVector3();
                SlimDX.Vector2 slimDXVector2 = MeshBuffer.VertexBuffer[(int)v1].TexCoords.ToSlimDXVector2();
                SlimDX.Vector2 vector2 = MeshBuffer.VertexBuffer[(int)v2].TexCoords.ToSlimDXVector2();
                SlimDX.Vector2 slimDXVector3 = MeshBuffer.VertexBuffer[(int)v3].TexCoords.ToSlimDXVector2();
                float x = vector8.X - slimDXVector4.X;
                float single = slimDXVector5.X - slimDXVector4.X;
                float y = vector8.Y - slimDXVector4.Y;
                float y2 = slimDXVector5.Y - slimDXVector4.Y;
                float z = vector8.Z - slimDXVector4.Z;
                float z2 = slimDXVector5.Z - slimDXVector4.Z;
                float x2 = vector2.X - slimDXVector2.X;
                float single2 = slimDXVector3.X - slimDXVector2.X;
                float y3 = vector2.Y - slimDXVector2.Y;
                float single3 = slimDXVector3.Y - slimDXVector2.Y;
                float single4 = 1f / (x2 * single3 - single2 * y3);
                SlimDX.Vector3 vector3 = new SlimDX.Vector3((single3 * x - y3 * single) * single4, (single3 * y - y3 * y2) * single4, (single3 * z - y3 * z2) * single4);
                SlimDX.Vector3 vector4 = new SlimDX.Vector3((x2 * single - single2 * x) * single4, (x2 * y2 - single2 * y) * single4, (x2 * z2 - single2 * z) * single4);
                List<SlimDX.Vector3> vector3s3;
                List<SlimDX.Vector3> list = (vector3s3 = vector3s);
                uint num = v1;
                int num2 = (int)num;
                list[(int)num] = vector3s3[num2] + vector3;
                List<SlimDX.Vector3> vector3s4;
                List<SlimDX.Vector3> list2 = (vector3s4 = vector3s);
                uint num5 = v2;
                int num6 = (int)num5;
                list2[(int)num5] = vector3s4[num6] + vector3;
                List<SlimDX.Vector3> vector3s5;
                List<SlimDX.Vector3> list3 = (vector3s5 = vector3s);
                uint num7 = v3;
                int num8 = (int)num7;
                list3[(int)num7] = vector3s5[num8] + vector3;
                List<SlimDX.Vector3> vector3s6;
                List<SlimDX.Vector3> list4 = (vector3s6 = vector3s2);
                uint num9 = v1;
                int num10 = (int)num9;
                list4[(int)num9] = vector3s6[num10] + vector4;
                List<SlimDX.Vector3> vector3s7;
                List<SlimDX.Vector3> list5 = (vector3s7 = vector3s2);
                uint num11 = v2;
                int num12 = (int)num11;
                list5[(int)num11] = vector3s7[num12] + vector4;
                List<SlimDX.Vector3> vector3s8;
                List<SlimDX.Vector3> list6 = (vector3s8 = vector3s2);
                uint num3 = v3;
                int num4 = (int)num3;
                list6[(int)num3] = vector3s8[num4] + vector4;
            }
            for (int k = 0; k < MeshBuffer.VertexBuffer.Count; k++) {
                SlimDX.Vector3 slimDXVector6 = MeshBuffer.VertexBuffer[k].Normals.ToSlimDXVector3();
                SlimDX.Vector3 vector5 = vector3s[k];
                SlimDX.Vector3 vector6 = vector5 - slimDXVector6 * SlimDX.Vector3.Dot(slimDXVector6, vector5);
                vector6.Normalize();
                SlimDX.Vector3 vector7 = SlimDX.Vector3.Cross(slimDXVector6, vector5) * ((SlimDX.Vector3.Dot(SlimDX.Vector3.Cross(slimDXVector6, vector5), vector3s2[k]) < 0f) ? (-1f) : 1f);
                MeshBuffer.VertexBuffer[k].Tangents = new Vector3 {
                    X = vector6.X,
                    Y = vector6.Y,
                    Z = vector6.Z
                };
                MeshBuffer.VertexBuffer[k].Bitangents = new Vector3 {
                    X = vector7.X,
                    Y = vector7.Y,
                    Z = vector7.Z
                };
            }
        }

        public string[] GetAssetTypes() {
            return new string[2] { "RigidMeshAsset", "SkinnedMeshAsset" };
        }

        public string[] GetExtensions() {
            return new string[1] { "obj" };
        }

        public bool Run(AssetContainer InContainer, string InFile, out string Errors) {
            try {
                MeshImportConfig meshImportConfig = new MeshImportConfig();
                meshImportConfig.ShowDialog();
                if (meshImportConfig.Cancelled) {
                    Errors = "";
                    return false;
                }
                ResRef res = Library.GetResByResRid(((MeshAsset)InContainer.RootObject).MeshSetResource);
                if (res == null) {
                    Errors = "Could not find Res";
                    return false;
                }
                Mesh dAIMesh = Mesh.FromRes(res);
                if (!Mesh.TryImport(dAIMesh.ImportFromObj(InFile), dAIMesh, "", Settings.Default.GlobalMeshScale, out Errors)) {
                    return false;
                }
                using (MemoryStream memoryStream = new MemoryStream()) {
                    using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream)) {
                        byte[] assetPayload = PayloadProvider.GetAssetPayload(res);
                        binaryWriter.Write(assetPayload);
                        foreach (LODLevel lODLevel in dAIMesh.LODLevels) {
                            ChunkRef chunk = Library.GetChunkById(lODLevel.ChunkID);
                            byte[] newChunkPayload = GetNewChunkPayload(chunk, lODLevel);
                            LibraryManager.DeleteChunk(chunk);
                            ChunkRef newChunk = AddNewChunk(chunk, newChunkPayload, (int)dAIMesh.MeshNameHash, res);
                            using (MemoryStream ms2 = new MemoryStream(assetPayload)) {
                                using (BinaryReader binaryReader = new BinaryReader(ms2)) {
                                    while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length) {
                                        long position1 = binaryReader.BaseStream.Position;
                                        if (GuidExt.GetGuidFromDoubleULong(binaryReader.ReadUInt64(), binaryReader.ReadUInt64()) != chunk.ChunkId) {
                                            binaryReader.BaseStream.Position -= 15L;
                                            continue;
                                        }
                                        binaryWriter.BaseStream.Seek(position1, SeekOrigin.Begin);
                                        binaryWriter.Write(newChunk.ChunkId);
                                        break;
                                    }
                                }
                            }
                        }
                        LibraryManager.ModifyRes(res, memoryStream.ToArray(), false);
                    }
                }
                Errors = "";
                return true;
            } catch (Exception ex) {
                Errors = ex.Message;
                return false;
            }
        }

        private byte[] GetNewChunkPayload(ChunkRef chunk, LODLevel lODLevel) {
            byte[] chunkPayload = PayloadProvider.GetAssetPayload(chunk);
            using (MemoryStream chunkMs = new MemoryStream()) {
                using (BinaryWriter chunkWriter = new BinaryWriter(chunkMs)) {
                    chunkWriter.Write(chunkPayload);
                    chunkWriter.BaseStream.Position = 0L;
                    foreach (LODSubObject subObject in lODLevel.SubObjects) {
                        ComputeTangentBasis(ref subObject.MeshBuffer);
                        chunkWriter.BaseStream.Seek(subObject.VertexBufferOffset, SeekOrigin.Begin);
                        for (int i = 0; i < subObject.VertexCount; i++) {
                            long position = chunkWriter.BaseStream.Position;
                            foreach (VertexEntry vertexEntry in subObject.VertexEntries) {
                                chunkWriter.BaseStream.Seek(position + vertexEntry.Offset, SeekOrigin.Begin);
                                if (vertexEntry.VertexType == 769) {
                                    chunkWriter.Write(subObject.MeshBuffer.VertexBuffer[i].Position.X);
                                    chunkWriter.Write(subObject.MeshBuffer.VertexBuffer[i].Position.Y);
                                    chunkWriter.Write(subObject.MeshBuffer.VertexBuffer[i].Position.Z);
                                } else if (vertexEntry.VertexType == 1793) {
                                    chunkWriter.Write(HalfUtils.Pack(subObject.MeshBuffer.VertexBuffer[i].Position.X));
                                    chunkWriter.Write(HalfUtils.Pack(subObject.MeshBuffer.VertexBuffer[i].Position.Y));
                                    chunkWriter.Write(HalfUtils.Pack(subObject.MeshBuffer.VertexBuffer[i].Position.Z));
                                } else if (vertexEntry.VertexType == 2054) {
                                    chunkWriter.Write(HalfUtils.Pack(subObject.MeshBuffer.VertexBuffer[i].Normals.X));
                                    chunkWriter.Write(HalfUtils.Pack(subObject.MeshBuffer.VertexBuffer[i].Normals.Y));
                                    chunkWriter.Write(HalfUtils.Pack(subObject.MeshBuffer.VertexBuffer[i].Normals.Z));
                                } else if (vertexEntry.VertexType == 2055) {
                                    chunkWriter.Write(HalfUtils.Pack(subObject.MeshBuffer.VertexBuffer[i].Tangents.X));
                                    chunkWriter.Write(HalfUtils.Pack(subObject.MeshBuffer.VertexBuffer[i].Tangents.Y));
                                    chunkWriter.Write(HalfUtils.Pack(subObject.MeshBuffer.VertexBuffer[i].Tangents.Z));
                                } else if (vertexEntry.VertexType != 2056) {
                                    if (vertexEntry.VertexType == 1569) {
                                        chunkWriter.Write(HalfUtils.Pack(subObject.MeshBuffer.VertexBuffer[i].TexCoords.X));
                                        chunkWriter.Write(HalfUtils.Pack(subObject.MeshBuffer.VertexBuffer[i].TexCoords.Y));
                                    }
                                } else {
                                    chunkWriter.Write(HalfUtils.Pack(subObject.MeshBuffer.VertexBuffer[i].Bitangents.X));
                                    chunkWriter.Write(HalfUtils.Pack(subObject.MeshBuffer.VertexBuffer[i].Bitangents.Y));
                                    chunkWriter.Write(HalfUtils.Pack(subObject.MeshBuffer.VertexBuffer[i].Bitangents.Z));
                                }
                            }
                            chunkWriter.BaseStream.Seek(position + subObject.VertexStride, SeekOrigin.Begin);
                        }
                    }
                    return chunkMs.ToArray();
                }
            }
        }

        private ChunkRef AddNewChunk(ChunkRef oldChunk, byte[] chunkPayload, int meshNameHash, ResRef res) {
            ChunkRef obj = new ChunkRef {
                Sha1 = "00000000000000000000",
                ChunkId = Guid.NewGuid(),
                H32 = meshNameHash,
                Meta = new byte[1],
                LogicalOffset = 0,
                LogicalSize = chunkPayload.Length,
                Size = oldChunk.Size
            };
            byte[] modifiedData = AssetUtils.CompressData(chunkPayload);
            LibraryManager.AddChunk(obj, modifiedData, true);
            LibraryManager.AddToBundles(obj, res.ParentSbs);
            if (oldChunk.State != 0) {
                LibraryManager.DeleteChunk(oldChunk);
            }
            return obj;
        }
    }
}
