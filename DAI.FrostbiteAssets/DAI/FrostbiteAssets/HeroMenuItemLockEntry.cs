using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class HeroMenuItemLockEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public MenuItemLock Reason { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference Text { get; set; }

		[FieldOffset(8, 32)]
		public PlotFlagReference PlotFlag { get; set; }
	}
}
