using System;
using System.Collections.Generic;
using System.IO;

using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary.Assets.Bases {
    public class Mesh {
        public class MeshObjLOD {
            public int LodIndex { get; private set; }

            public Dictionary<string, MeshObjGroup> MeshObjGroups { get; private set; }

            public MeshObjLOD(int lodIndex) {
                LodIndex = lodIndex;
                MeshObjGroups = new Dictionary<string, MeshObjGroup>();
            }
        }

        public class MeshObjGroup {
            public string GroupName { get; private set; }

            public string GroupFullName { get; private set; }

            public List<Vector3> Vertices { get; private set; }

            public List<Vector3> VerticeNormals { get; private set; }

            public List<Vector2> Textures { get; private set; }

            public List<FaceElement> FaceElements { get; private set; }

            public MeshObjGroup(string groupName) {
                GroupFullName = groupName;
                GroupName = groupName.Substring(groupName.LastIndexOf("_"));
                Vertices = new List<Vector3>();
                VerticeNormals = new List<Vector3>();
                Textures = new List<Vector2>();
                FaceElements = new List<FaceElement>();
            }
        }

        public Vector3 MinPosition;

        public float Unknown01;

        public Vector3 MaxPosition;

        public float Unknown02;

        public List<LODLevel> LODLevels;

        public string MeshPath;

        public string MeshName;

        public uint MeshNameHash;

        public int Unknown04;

        public int Unknown05;

        public int TotalLODCount;

        public int TotalSubObjectCount;

        public byte[] Unknowns;

        public LODLevel GetLODByName(string Name) {
            for (int i = 0; i < LODLevels.Count; i++) {
                if (LODLevels[i].String03 == Name) {
                    return LODLevels[i];
                }
            }
            return null;
        }

        public static Mesh FromRes(ResRef resEntry) {
            byte[] data = PayloadProvider.GetAssetPayload(resEntry);
            if (data == null || data.Length == 0) {
                return null;
            }
            Mesh m = new Mesh();
            using (MemoryStream ms = new MemoryStream(data)) {
                using (BinaryReader Reader = new BinaryReader(ms)) {
                    m.MinPosition = Reader.ReadVector();
                    m.Unknown01 = Reader.ReadSingle();
                    m.MaxPosition = Reader.ReadVector();
                    m.Unknown02 = Reader.ReadSingle();
                    long[] lodOffsets = new long[6];
                    for (int i = 0; i < 6; i++) {
                        lodOffsets[i] = Reader.ReadInt64();
                    }
                    m.MeshPath = m.SerializeString(Reader);
                    m.MeshName = m.SerializeString(Reader);
                    m.MeshNameHash = Reader.ReadUInt32();
                    m.Unknown04 = Reader.ReadInt32();
                    m.Unknown05 = Reader.ReadInt32();
                    m.TotalLODCount = Reader.ReadInt16();
                    m.TotalSubObjectCount = Reader.ReadInt16();
                    m.LODLevels = new List<LODLevel>();
                    for (int j = 0; j < 6; j++) {
                        if (lodOffsets[j] != 0L) {
                            Reader.BaseStream.Seek(lodOffsets[j], SeekOrigin.Begin);
                            LODLevel dAILODLevel = new LODLevel();
                            dAILODLevel.Serialize(Reader, m);
                            if (j + 1 < 6 && lodOffsets[j + 1] != 0L) {
                                dAILODLevel.Size = lodOffsets[j + 1] - lodOffsets[j];
                            }
                            m.LODLevels.Add(dAILODLevel);
                        }
                    }
                    while (Reader.BaseStream.Position % 16 != 0L) {
                        Reader.ReadByte();
                    }
                    for (byte k = Reader.ReadByte(); k != 0; k = Reader.ReadByte()) {
                        Reader.BaseStream.Seek(-1L, SeekOrigin.Current);
                        while (k != 0) {
                            k = Reader.ReadByte();
                        }
                        k = Reader.ReadByte();
                    }
                    while (Reader.BaseStream.Position % 16 != 0L) {
                        Reader.ReadByte();
                    }
                    foreach (LODLevel lODLevel in m.LODLevels) {
                        lODLevel.DataActualValues = new byte[4];
                        for (int l = 0; l < 4; l++) {
                            Reader.BaseStream.Seek(lODLevel.DataOffsets[l], SeekOrigin.Begin);
                            lODLevel.DataActualValues[l] = Reader.ReadByte();
                        }
                        for (int n = 0; n < lODLevel.BoneDataCount * 2; n++) {
                            Reader.BaseStream.Seek(lODLevel.BoneData[n], SeekOrigin.Begin);
                            lODLevel.BoneDataValues.Add(new byte[lODLevel.BoneCount * 4]);
                            lODLevel.BoneDataValues[n] = Reader.ReadBytes(lODLevel.BoneCount * 4);
                        }
                    }
                    while (Reader.BaseStream.Position % 16 != 0L) {
                        Reader.ReadByte();
                    }
                    m.Unknowns = new byte[Reader.BaseStream.Length - Reader.BaseStream.Position];
                    m.Unknowns = Reader.ReadBytes((int)(Reader.BaseStream.Length - Reader.BaseStream.Position));
                    return m;
                }
            }
        }

        public string SerializeString(BinaryReader Reader) {
            long num = Reader.ReadInt64();
            long position = Reader.BaseStream.Position;
            Reader.BaseStream.Seek(num, SeekOrigin.Begin);
            string result = Reader.ReadNullTerminatedString();
            Reader.BaseStream.Seek(position, SeekOrigin.Begin);
            return result;
        }

        public void ExportAsObj(string filename, int maxLOD, float meshScale, string suffix) {
            using (FileStream fs = new FileStream(filename, FileMode.Create)) {
                using (StreamWriter streamWriter = new StreamWriter(fs)) {
                    uint vertexCount = 0u;
                    for (int lodIndex = 0; lodIndex < LODLevels.Count && lodIndex < maxLOD; lodIndex++) {
                        for (int soIndex = 0; soIndex < LODLevels[lodIndex].SubObjects.Count; soIndex++) {
                            LODSubObject subObject = LODLevels[lodIndex].SubObjects[soIndex];
                            if (!(subObject.SubObjectName == "")) {
                                string groupName = subObject.SubObjectName.Replace(" ", "_");
                                groupName = groupName.Replace("-", "_");
                                streamWriter.WriteLine($"g {groupName}{suffix}_{soIndex}_lod{lodIndex}");
                                for (int i = 0; i < subObject.MeshBuffer.VertexBuffer.Count; i++) {
                                    float x = subObject.MeshBuffer.VertexBuffer[i].Position.X * meshScale;
                                    float y = subObject.MeshBuffer.VertexBuffer[i].Position.Y * meshScale;
                                    float z = subObject.MeshBuffer.VertexBuffer[i].Position.Z * meshScale;
                                    streamWriter.WriteLine($"v {x:F3} {y:F3} {z:F3}".Replace(",", "."));
                                }
                                for (int j = 0; j < subObject.MeshBuffer.VertexBuffer.Count; j++) {
                                    streamWriter.WriteLine($"vn {subObject.MeshBuffer.VertexBuffer[j].Normals.X:F3} {subObject.MeshBuffer.VertexBuffer[j].Normals.Y:F3} {subObject.MeshBuffer.VertexBuffer[j].Normals.Z:F3}".Replace(",", "."));
                                }
                                for (int k = 0; k < subObject.MeshBuffer.VertexBuffer.Count; k++) {
                                    streamWriter.WriteLine($"vt {subObject.MeshBuffer.VertexBuffer[k].TexCoords.X:F3} {subObject.MeshBuffer.VertexBuffer[k].TexCoords.Y:F3}".Replace(",", "."));
                                }
                                for (int l = 0; l < subObject.TriangleCount; l++) {
                                    FaceElement dAIFace = subObject.MeshBuffer.IndexBuffer[l];
                                    uint v1 = vertexCount + dAIFace.V1 + 1;
                                    uint v2 = vertexCount + dAIFace.V2 + 1;
                                    uint v3 = vertexCount + dAIFace.V3 + 1;
                                    streamWriter.WriteLine(string.Format("f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}", v1, v2, v3));
                                }
                                vertexCount += (uint)subObject.VertexCount;
                            }
                        }
                    }
                }
            }
        }

        public Dictionary<int, MeshObjLOD> ImportFromObj(string filename) {
            Dictionary<int, MeshObjLOD> lods = new Dictionary<int, MeshObjLOD>();
            int lodIndex = 0;
            int nbVertices = 0;
            string groupName = "";
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
                using (StreamReader streamReader = new StreamReader(fs)) {
                    while (!streamReader.EndOfStream) {
                        string[] strParams = streamReader.ReadLine().Replace("# object ", "g ").Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (strParams.Length == 0) {
                            continue;
                        }
                        switch (strParams[0]) {
                            case "g":
                            case "o":
                                groupName = strParams[1];
                                lodIndex = int.Parse(strParams[1].Substring(strParams[1].IndexOf("lod") + 3, 1));
                                if (!lods.ContainsKey(lodIndex)) {
                                    int num = lodIndex;
                                    lods.Add(num, new MeshObjLOD(num));
                                }
                                if (!lods[lodIndex].MeshObjGroups.ContainsKey(groupName)) {
                                    Dictionary<string, MeshObjGroup> meshObjGroups = lods[lodIndex].MeshObjGroups;
                                    string text = groupName;
                                    meshObjGroups.Add(text, new MeshObjGroup(text));
                                }
                                break;
                            case "v": {
                                    float x = float.Parse(strParams[1]);
                                    float y = float.Parse(strParams[2]);
                                    float z = float.Parse(strParams[3]);
                                    lods[lodIndex].MeshObjGroups[groupName].Vertices.Add(new Vector3(x, y, z));
                                    nbVertices++;
                                    break;
                                }
                            case "vt":
                                lods[lodIndex].MeshObjGroups[groupName].Textures.Add(new Vector2(float.Parse(strParams[1]), float.Parse(strParams[2])));
                                break;
                            case "vn":
                                lods[lodIndex].MeshObjGroups[groupName].VerticeNormals.Add(new Vector3(float.Parse(strParams[1]), float.Parse(strParams[2]), float.Parse(strParams[3])));
                                break;
                            case "f": {
                                    string[] vertex1Params = strParams[1].Split('/');
                                    string[] vertex2Params = strParams[2].Split('/');
                                    string[] vertex3Params = strParams[3].Split('/');
                                    FaceElement dAIFace = new FaceElement {
                                        V1 = uint.Parse(vertex1Params[2]),
                                        V2 = uint.Parse(vertex2Params[2]),
                                        V3 = uint.Parse(vertex3Params[2])
                                    };
                                    lods[lodIndex].MeshObjGroups[groupName].FaceElements.Add(dAIFace);
                                    break;
                                }
                        }
                    }
                    return lods;
                }
            }
        }

        public static bool TryImport(Dictionary<int, MeshObjLOD> lods, Mesh mesh, string suffix, float globalMeshScale, out string Errors) {
            try {
                for (int i = 0; i < mesh.LODLevels.Count; i++) {
                    if (!lods.ContainsKey(i)) {
                        continue;
                    }
                    for (int soIndex = 0; soIndex < mesh.LODLevels[i].SubObjects.Count; soIndex++) {
                        LODSubObject current = mesh.LODLevels[i].SubObjects[soIndex];
                        if (current.SubObjectName == "") {
                            continue;
                        }
                        string groupName = current.SubObjectName.Replace(" ", "_");
                        groupName = groupName.Replace("-", "_");
                        groupName = string.Format("{0}_{1}{2}_lod{1}", groupName, soIndex, suffix, i);
                        if (lods[i].MeshObjGroups.ContainsKey(groupName)) {
                            MeshObjGroup group = lods[i].MeshObjGroups[groupName];
                            if (current.MeshBuffer.VertexBuffer.Count != group.Vertices.Count) {
                                Errors = "Imported obj does not contain the same number of vertices as the base mesh in one of its LODs";
                                return false;
                            }
                            if (current.MeshBuffer.VertexBuffer.Count != group.Textures.Count) {
                                Errors = "Imported obj does not contain the same number of texture coordinates as the base mesh in one of its LODs";
                                return false;
                            }
                            if (current.MeshBuffer.IndexBuffer.Count != group.FaceElements.Count) {
                                Errors = "Imported obj does not contain the same number of normals as the base mesh in one of its LODs";
                                return false;
                            }
                            for (int j = 0; j < lods[i].MeshObjGroups[groupName].Vertices.Count; j++) {
                                current.MeshBuffer.VertexBuffer[j].Position = new Vector3(group.Vertices[j].X / globalMeshScale, group.Vertices[j].Y / globalMeshScale, group.Vertices[j].Z / globalMeshScale);
                                current.MeshBuffer.VertexBuffer[j].TexCoords = new Vector2(group.Textures[j].X, group.Textures[j].Y);
                            }
                            for (int k = 0; k < current.MeshBuffer.IndexBuffer.Count; k++) {
                                Vertex v1 = current.MeshBuffer.VertexBuffer[(int)current.MeshBuffer.IndexBuffer[k].V1];
                                Vertex v2 = current.MeshBuffer.VertexBuffer[(int)current.MeshBuffer.IndexBuffer[k].V2];
                                Vertex vertex = current.MeshBuffer.VertexBuffer[(int)current.MeshBuffer.IndexBuffer[k].V3];
                                Vector3 normals1 = group.VerticeNormals[(int)(group.FaceElements[k].V1 - 1)];
                                Vector3 normals2 = group.VerticeNormals[(int)(group.FaceElements[k].V2 - 1)];
                                Vector3 normals3 = group.VerticeNormals[(int)(group.FaceElements[k].V3 - 1)];
                                v1.Normals = new Vector3(normals1.X, normals1.Y, normals1.Z);
                                v2.Normals = new Vector3(normals2.X, normals2.Y, normals2.Z);
                                vertex.Normals = new Vector3(normals3.X, normals3.Y, normals3.Z);
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                Errors = "Exception: " + ex.Message;
                return false;
            }
            Errors = "";
            return true;
        }
    }
}
