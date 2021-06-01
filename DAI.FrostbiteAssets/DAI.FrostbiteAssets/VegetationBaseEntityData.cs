using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class VegetationBaseEntityData : GameComponentEntityData
	{
		[FieldOffset(112, 208)]
		public List<LinearTransform> BasePoseTransforms { get; set; }

		[FieldOffset(116, 216)]
		public List<int> Hierarchy { get; set; }

		[FieldOffset(120, 224)]
		public List<int> PartIndirection { get; set; }

		[FieldOffset(124, 232)]
		public List<int> PartHierarchy { get; set; }

		[FieldOffset(128, 240)]
		public List<float> PartInitialHealths { get; set; }

		[FieldOffset(132, 248)]
		public List<bool> BoneIsStem { get; set; }

		[FieldOffset(136, 256)]
		public ExternalObject<MeshAsset> Mesh { get; set; }

		[FieldOffset(140, 264)]
		public ExternalObject<Dummy> ShadowMesh { get; set; }

		[FieldOffset(144, 272)]
		public ExternalObject<PhysicsEntityData> PhysicsData { get; set; }

		public VegetationBaseEntityData()
		{
			BasePoseTransforms = new List<LinearTransform>();
			Hierarchy = new List<int>();
			PartIndirection = new List<int>();
			PartHierarchy = new List<int>();
			PartInitialHealths = new List<float>();
			BoneIsStem = new List<bool>();
		}
	}
}
