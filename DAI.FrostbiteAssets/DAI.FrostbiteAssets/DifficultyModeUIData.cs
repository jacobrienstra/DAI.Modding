using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DifficultyModeUIData : LinkObject
	{
		[FieldOffset(0, 0)]
		public int DifficultyID { get; set; }

		[FieldOffset(4, 8)]
		public string DifficultyCardName { get; set; }

		[FieldOffset(8, 16)]
		public List<SkuTextureAsset> SkuOverrides { get; set; }

		[FieldOffset(12, 24)]
		public LocalizedStringReference DifficultyName { get; set; }

		[FieldOffset(16, 48)]
		public LocalizedStringReference DifficultyDescription { get; set; }

		public DifficultyModeUIData()
		{
			SkuOverrides = new List<SkuTextureAsset>();
		}
	}
}
