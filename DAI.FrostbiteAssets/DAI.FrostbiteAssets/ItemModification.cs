using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemModification : LinkObject
	{
		[FieldOffset(0, 0)]
		public int DamageType { get; set; }

		[FieldOffset(4, 4)]
		public ItemModificationTiming Timing { get; set; }

		[FieldOffset(8, 8)]
		public BWTimelineReference TimelineRef { get; set; }
	}
}
