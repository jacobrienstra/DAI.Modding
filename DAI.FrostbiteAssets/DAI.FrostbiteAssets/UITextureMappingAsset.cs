using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITextureMappingAsset : Asset
	{
		[FieldOffset(12, 72)]
		public UITextureMappingCompartment Compartment { get; set; }

		[FieldOffset(16, 80)]
		public List<UITextureMappingOutputEntry> Output { get; set; }

		[FieldOffset(20, 88)]
		public bool DisableAtlas { get; set; }

		[FieldOffset(21, 89)]
		public bool ForceAtlas { get; set; }

		public UITextureMappingAsset()
		{
			Output = new List<UITextureMappingOutputEntry>();
		}
	}
}
