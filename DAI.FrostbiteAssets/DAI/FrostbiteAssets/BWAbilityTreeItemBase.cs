using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbilityTreeItemBase : DataContainer
	{
		[FieldOffset(8, 24)]
		public int PointsRequiredInAbilityTree { get; set; }

		[FieldOffset(12, 28)]
		public BWAbilityState MPAvailability { get; set; }

		[FieldOffset(16, 32)]
		public int MPSlotId { get; set; }

		[FieldOffset(20, 36)]
		public int MPId { get; set; }
	}
}
