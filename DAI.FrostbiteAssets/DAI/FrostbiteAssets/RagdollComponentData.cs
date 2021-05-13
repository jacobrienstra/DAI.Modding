using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class RagdollComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<SkeletonAsset> SkeletonAsset { get; set; }

		[FieldOffset(100, 184)]
		public ExternalObject<RagdollAsset> RagdollAsset { get; set; }

		[FieldOffset(104, 192)]
		public ExternalObject<SkeletonCollisionData> SkeletonCollisionData { get; set; }

		[FieldOffset(108, 200)]
		public RagdollBinding Binding { get; set; }

		[FieldOffset(228, 488)]
		public string LeftLegBoneName { get; set; }

		[FieldOffset(232, 496)]
		public string RightLegBoneName { get; set; }

		[FieldOffset(236, 504)]
		public List<MaterialDecl> BoneMaterials { get; set; }

		[FieldOffset(240, 512)]
		public List<BuoyantPartsData> BuoyantParts { get; set; }

		[FieldOffset(244, 520)]
		public bool AllowClientTriggerOnBlend { get; set; }

		public RagdollComponentData()
		{
			BoneMaterials = new List<MaterialDecl>();
			BuoyantParts = new List<BuoyantPartsData>();
		}
	}
}
