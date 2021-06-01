using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MapBinaryChoiceInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public LocalizedStringReference Title { get; set; }

		[FieldOffset(4, 24)]
		public LocalizedStringReference Description { get; set; }

		[FieldOffset(8, 48)]
		public string ImageName { get; set; }

		[FieldOffset(12, 56)]
		public WarTableMapChoiceId WarTableMapChoiceId { get; set; }
	}
}
