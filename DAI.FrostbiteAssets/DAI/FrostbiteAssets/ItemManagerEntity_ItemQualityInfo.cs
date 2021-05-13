using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ItemManagerEntity_ItemQualityInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public Vec3 Color { get; set; }

		[FieldOffset(16, 16)]
		public ItemQuality Quality { get; set; }

		[FieldOffset(20, 24)]
		public LocalizedStringReference DisplayName { get; set; }

		[FieldOffset(24, 48)]
		public string ModSlotFrameLabel { get; set; }

		[FieldOffset(28, 56)]
		public string RuneSlotFrameLabel { get; set; }
	}
}
