using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3MPDragonLevelVariant : LinkObject
	{
		[FieldOffset(0, 0)]
		public DA3MPDragonType DragonType { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference LevelNameOverride { get; set; }
	}
}
