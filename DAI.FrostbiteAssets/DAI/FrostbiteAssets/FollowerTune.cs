namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FollowerTune : Asset
	{
		[FieldOffset(12, 72)]
		public float circulate_minTime { get; set; }

		[FieldOffset(16, 76)]
		public float circulate_maxTime { get; set; }

		[FieldOffset(20, 80)]
		public float startupSlowness { get; set; }

		[FieldOffset(24, 84)]
		public float startupBulk { get; set; }

		[FieldOffset(28, 88)]
		public float packingPadding { get; set; }

		[FieldOffset(32, 92)]
		public bool circulate_enable { get; set; }
	}
}
