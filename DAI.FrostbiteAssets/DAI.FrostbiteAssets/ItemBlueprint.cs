using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemBlueprint : Blueprint
	{
		[FieldOffset(32, 176)]
		public ExternalObject<ObjectBlueprint> Appearance { get; set; }

		[FieldOffset(36, 184)]
		public List<VariationLink> VariationLinks { get; set; }

		[FieldOffset(40, 192)]
		public List<ExternalObject<ClothAssetInstance>> ClothInstances { get; set; }

		[FieldOffset(44, 200)]
		public List<ExternalObject<Asset>> ClothAppearances { get; set; }

		[FieldOffset(48, 208)]
		public ExternalObject<AppearanceTintSet> TintOverrides { get; set; }

		[FieldOffset(52, 216)]
		public bool ReuseClothInstances { get; set; }

		[FieldOffset(53, 217)]
		public bool IncludeGen3Appearances { get; set; }

		public ItemBlueprint()
		{
			VariationLinks = new List<VariationLink>();
			ClothInstances = new List<ExternalObject<ClothAssetInstance>>();
			ClothAppearances = new List<ExternalObject<Asset>>();
		}
	}
}
