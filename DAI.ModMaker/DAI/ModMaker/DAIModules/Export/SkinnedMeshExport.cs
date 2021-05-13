using System;
using System.Collections.Generic;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;
using DAI.ModMaker.Properties;
using DAI.ModMaker.Utilities;

namespace DAI.ModMaker.DAIModules.Export
{
    public class SkinnedMeshExport : DAIBaseExporter
    {
        public string[] GetAssetTypes()
        {
            return new string[1] { "SkinnedMeshAsset" };
        }

        public string[] GetExtensions()
        {
            return new string[2] { "obj", "psk" };
        }

        private SkeletonAsset GetSkeleton(EbxRef InAsset)
        {
            return (SkeletonAsset)EbxBase.FromEbx(InAsset).GetContainer().RootObject;
        }

        public bool Run(AssetContainer InContainer, string OutPath, out string Errors)
        {
            ResRef res = Library.GetResByResRid(((SkinnedMeshAsset)InContainer.RootObject).MeshSetResource);
            if (res == null)
            {
                Errors = "Unable to obtain UI asset resource";
                return false;
            }
            if (res == null)
            {
                Errors = $"Could not find related Res [{res.ResRid}]";
                return false;
            }
            Mesh dAIMesh = Mesh.FromRes(res);
            MeshExportConfig meshExportConfig = new MeshExportConfig((!OutPath.EndsWith(".obj")) ? true : false);
            meshExportConfig.ShowDialog();
            if (meshExportConfig.Cancelled)
            {
                Errors = "";
                return false;
            }
            if (!OutPath.EndsWith(".psk"))
            {
                try
                {
                    dAIMesh.ExportAsObj(OutPath, 6, Settings.Default.GlobalMeshScale, "");
                }
                catch (Exception ex)
                {
                    Errors = "Could not export mesh.  Exception:" + ex.Message;
                    return false;
                }
                Errors = "";
                return true;
            }
            SkeletonAsset skeleton = GetSkeleton(meshExportConfig.SelectedSkeleton);
            PSKFile pSKFile = new PSKFile
            {
                points = new List<PSKFile.PSKPoint>(),
                edges = new List<PSKFile.PSKEdge>(),
                materials = new List<PSKFile.PSKMaterial>(),
                bones = new List<PSKFile.PSKBone>(),
                faces = new List<PSKFile.PSKFace>(),
                weights = new List<PSKFile.PSKWeight>()
            };
            int i;
            for (i = 0; i < skeleton.BoneNames.Count; i++)
            {
                List<int> nums = skeleton.Hierarchy.FindAll((int A) => A == i);
                PSKFile.PSKBone pSKBone = default(PSKFile.PSKBone);
                pSKBone.name = skeleton.BoneNames[i];
                pSKBone.childs = nums.Count;
                pSKBone.parent = skeleton.Hierarchy[i];
                pSKBone.index = i;
                pSKBone.location = new PSKFile.PSKPoint(skeleton.LocalPose[i].trans.x * Settings.Default.GlobalMeshScale, skeleton.LocalPose[i].trans.y * Settings.Default.GlobalMeshScale, skeleton.LocalPose[i].trans.z * Settings.Default.GlobalMeshScale);
                pSKBone.rotation = new PSKFile.PSKQuad(0f, 0f, 0f, 0f);
                PSKFile.PSKBone pSKQuad = pSKBone;
                float[][] singleArray = new float[4][]
                {
                    new float[4],
                    new float[4],
                    new float[4],
                    new float[4]
                };
                singleArray[0][0] = skeleton.LocalPose[i].right.x;
                singleArray[0][1] = skeleton.LocalPose[i].right.y;
                singleArray[0][2] = skeleton.LocalPose[i].right.z;
                singleArray[0][3] = 0f;
                singleArray[1][0] = skeleton.LocalPose[i].up.x;
                singleArray[1][1] = skeleton.LocalPose[i].up.y;
                singleArray[1][2] = skeleton.LocalPose[i].up.z;
                singleArray[1][3] = 0f;
                singleArray[2][0] = skeleton.LocalPose[i].forward.x;
                singleArray[2][1] = skeleton.LocalPose[i].forward.y;
                singleArray[2][2] = skeleton.LocalPose[i].forward.z;
                singleArray[2][3] = 0f;
                singleArray[3][0] = 0f;
                singleArray[3][1] = 0f;
                singleArray[3][2] = 0f;
                singleArray[3][3] = 1f;
                Vector4 vector4 = new Vector4();
                float single2 = singleArray[0][0] + singleArray[1][1] + singleArray[2][2];
                if (single2 <= 0f)
                {
                    int num2 = 0;
                    if (singleArray[1][1] > singleArray[0][0])
                    {
                        num2 = 1;
                    }
                    if (singleArray[2][2] > singleArray[num2][num2])
                    {
                        num2 = 2;
                    }
                    int[] obj = new int[3] { 1, 2, 0 };
                    int num3 = obj[num2];
                    int num4 = obj[num3];
                    float single = singleArray[num2][num2] - singleArray[num3][num3] - singleArray[num4][num4] + 1f;
                    float single3 = 1f / (float)Math.Sqrt(single);
                    float[] singleArray2 = new float[4];
                    singleArray2[num2] = 0.5f * (1f / single3);
                    single = 0.5f * single3;
                    singleArray2[3] = (singleArray[num3][num4] - singleArray[num4][num3]) * single;
                    singleArray2[num3] = (singleArray[num2][num3] + singleArray[num3][num2]) * single;
                    singleArray2[num4] = (singleArray[num2][num4] + singleArray[num4][num2]) * single;
                    vector4.X = singleArray2[0];
                    vector4.Y = singleArray2[1];
                    vector4.Z = singleArray2[2];
                    vector4.W = singleArray2[3];
                }
                else
                {
                    float single4 = 1f / (float)Math.Sqrt(single2 + 1f);
                    vector4.W = 0.5f * (1f / single4);
                    float single = 0.5f * single4;
                    vector4.X = (singleArray[1][2] - singleArray[2][1]) * single;
                    vector4.Y = (singleArray[2][0] - singleArray[0][2]) * single;
                    vector4.Z = (singleArray[0][1] - singleArray[1][0]) * single;
                }
                pSKQuad.rotation = new PSKFile.PSKQuad(vector4);
                pSKFile.bones.Add(pSKQuad);
            }
            int vertexCount1 = 0;
            int num5 = 0;
            foreach (LODSubObject dAISubObject in dAIMesh.LODLevels[0].SubObjects)
            {
                MeshBuffer meshBuffer = dAISubObject.MeshBuffer;
                if (dAISubObject.SubObjectName == "")
                {
                    continue;
                }
                for (int j = 0; j < meshBuffer.VertexBuffer.Count; j++)
                {
                    pSKFile.points.Add(new PSKFile.PSKPoint(meshBuffer.VertexBuffer[j].Position * Settings.Default.GlobalMeshScale));
                    pSKFile.edges.Add(new PSKFile.PSKEdge((ushort)(vertexCount1 + j), meshBuffer.VertexBuffer[j].TexCoords, Convert.ToByte(num5)));
                    for (int o = 0; o < 4; o++)
                    {
                        float boneWeights = meshBuffer.VertexBuffer[j].BoneWeights[o];
                        int boneIndices = meshBuffer.VertexBuffer[j].BoneIndices[o];
                        int subBoneList = dAISubObject.SubBoneList[boneIndices];
                        pSKFile.weights.Add(new PSKFile.PSKWeight(boneWeights, vertexCount1 + j, subBoneList));
                    }
                }
                for (int p = 0; p < meshBuffer.IndexBuffer.Count; p++)
                {
                    pSKFile.faces.Add(new PSKFile.PSKFace((int)(vertexCount1 + meshBuffer.IndexBuffer[p].V1), (int)(vertexCount1 + meshBuffer.IndexBuffer[p].V2), (int)(vertexCount1 + meshBuffer.IndexBuffer[p].V3), Convert.ToByte(num5)));
                }
                pSKFile.materials.Add(new PSKFile.PSKMaterial("", num5));
                vertexCount1 += dAISubObject.VertexCount;
                num5++;
            }
            pSKFile.Save(OutPath);
            Errors = "";
            return true;
        }
    }
}
