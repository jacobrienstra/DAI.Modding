namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IdleTune : Asset
	{
		[FieldOffset(12, 72)]
		public float tetherDist { get; set; }

		[FieldOffset(16, 76)]
		public float returnDelay { get; set; }
	}
}
