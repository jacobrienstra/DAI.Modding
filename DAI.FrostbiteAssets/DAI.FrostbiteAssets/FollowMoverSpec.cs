using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FollowMoverSpec
	{
		[FieldOffset(0, 0)]
		public FollowFormation formation { get; set; }

		[FieldOffset(4, 4)]
		public float followDistance { get; set; }

		[FieldOffset(8, 8)]
		public float arcSpread { get; set; }
	}
}
