using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GivePotionEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<PotionItemAsset> PotionAsset { get; set; }

		[FieldOffset(20, 104)]
		public PotionSlot PotionSlot { get; set; }

		[FieldOffset(24, 108)]
		public int Count { get; set; }

		[FieldOffset(28, 112)]
		public ExternalObject<Dummy> InputCreatures { get; set; }

		[FieldOffset(32, 120)]
		public bool IgnorePotionAsset { get; set; }
	}
}
