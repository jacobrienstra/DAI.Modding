using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpgradeItemAsset : StatItemAsset
	{
		[FieldOffset(124, 320)]
		public ExternalObject<ItemPartAppearance> UpgradeItemAppearance { get; set; }

		[FieldOffset(128, 328)]
		public ExternalObject<UpgradeItemType> CastedItemType { get; set; }

		[FieldOffset(132, 336)]
		public RuneCategory RuneCategory { get; set; }

		[FieldOffset(136, 340)]
		public bool AOEDamage { get; set; }
	}
}
