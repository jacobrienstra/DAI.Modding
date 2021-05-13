using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ClothAssetInstance : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<ClothObjectBlueprint> Cloth { get; set; }

		[FieldOffset(16, 80)]
		public List<VariationLink> VariationLinks { get; set; }

		[FieldOffset(20, 88)]
		public bool WorldCollision { get; set; }

		public ClothAssetInstance()
		{
			VariationLinks = new List<VariationLink>();
		}
	}
}
