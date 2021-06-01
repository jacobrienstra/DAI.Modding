using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProfileOptionData : Asset
	{
		[FieldOffset(12, 72)]
		public string UniqueId { get; set; }

		[FieldOffset(16, 80)]
		public ProfileOptionsType Category { get; set; }
	}
}
