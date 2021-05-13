using System;
using System.IO;
using System.Windows.Forms;
using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;
using DAI.FrostbiteAssets;

namespace DAI.ModMaker.DAIModules.Preview
{
	public class HeadMorphPreview : DAIBasePreviewer
	{
		public string[] GetAssetTypes()
		{
			return new string[1] { "MorphStatic" };
		}

		public void Run(AssetContainer InContainer, EbxRef InAsset)
		{
			try
			{
				MorphStatic rootObject = (MorphStatic)InContainer.RootObject;
				ResRef res = Library.GetResByResRid(rootObject.MorphResource);
				if (res == null)
				{
					MessageBox.Show($"Could not find related Res [{res.ResRid}]");
					return;
				}
				Mesh dAIMesh = Mesh.FromRes(Library.GetResByResRid(rootObject.RuntimeHeadBase.GetObject(InContainer).MeshSetResource));
				using (MemoryStream ms = new MemoryStream(PayloadProvider.GetAssetPayload(res)))
				{
					using (BinaryReader binaryReader = new BinaryReader(ms))
					{
						binaryReader.ReadNullTerminatedString();
						binaryReader.BaseStream.Seek(20L, SeekOrigin.Current);
						for (int i = 0; i < 3; i++)
						{
							foreach (LODSubObject subObject in dAIMesh.LODLevels[i].SubObjects)
							{
								if (!(subObject.SubObjectName == ""))
								{
									LODSubObject dAISubObject = subObject;
									dAISubObject.SubObjectName += "_headmorph";
									MeshBuffer meshBuffer = subObject.MeshBuffer;
									for (int j = 0; j < meshBuffer.VertexBuffer.Count; j++)
									{
										meshBuffer.VertexBuffer[j].Position.X = binaryReader.ReadSingle();
										meshBuffer.VertexBuffer[j].Position.Y = binaryReader.ReadSingle();
										meshBuffer.VertexBuffer[j].Position.Z = binaryReader.ReadSingle();
										binaryReader.ReadSingle();
									}
								}
							}
						}
					}
				}
				new MeshPreviewWindow(dAIMesh).Show();
			}
			catch (Exception)
			{
				MessageBox.Show("Error while trying to preview this mesh.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
