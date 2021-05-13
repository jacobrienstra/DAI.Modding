using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntryComponentHudData
	{
		[FieldOffset(0, 0)]
		public int Index { get; set; }

		[FieldOffset(4, 4)]
		public EntrySeatType SeatType { get; set; }

		[FieldOffset(8, 8)]
		public bool Frustum { get; set; }

		[FieldOffset(9, 9)]
		public bool Visible { get; set; }

		[FieldOffset(10, 10)]
		public bool MaximizeMiniMapOnEntry { get; set; }
	}
}
