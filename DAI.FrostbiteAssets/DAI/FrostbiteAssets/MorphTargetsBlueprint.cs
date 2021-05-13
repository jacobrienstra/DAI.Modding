using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MorphTargetsBlueprint : Blueprint
	{
		[FieldOffset(32, 176)]
		public ExternalObject<MeshAsset> Mesh { get; set; }

		[FieldOffset(36, 184)]
		public ModelAssetType ModelAssetType { get; set; }

		[FieldOffset(40, 192)]
		public List<VariationLink> VariationLinks { get; set; }

		public MorphTargetsBlueprint()
		{
			VariationLinks = new List<VariationLink>();
		}
	}
}
