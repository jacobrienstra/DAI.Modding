namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FreeLookData : LinkObject
	{
		[FieldOffset(0, 0)]
		public float FreeLookResetTime { get; set; }

		[FieldOffset(4, 4)]
		public float RecenterTime { get; set; }

		[FieldOffset(8, 8)]
		public FreeLookHeadingData Heading { get; set; }

		[FieldOffset(60, 72)]
		public FreeLookLerpData Lerp { get; set; }

		[FieldOffset(108, 128)]
		public bool EnableFreeLookControls { get; set; }
	}
}
