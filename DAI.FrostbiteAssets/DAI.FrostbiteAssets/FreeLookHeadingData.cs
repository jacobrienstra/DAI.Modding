namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FreeLookHeadingData : LinkObject
	{
		[FieldOffset(0, 0)]
		public int HeadingControl { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<Dummy> HeadingControlRaw { get; set; }

		[FieldOffset(8, 16)]
		public float HeadingDeadZone { get; set; }

		[FieldOffset(12, 20)]
		public float FreeLookHeadingAcceleration { get; set; }

		[FieldOffset(16, 24)]
		public float FreeLookHeadingDeceleration { get; set; }

		[FieldOffset(20, 28)]
		public float FreeLookHeadingMaxSpeed { get; set; }

		[FieldOffset(24, 32)]
		public float FreeLookHeadingAutoSteerFadeIn { get; set; }

		[FieldOffset(28, 36)]
		public float FreeLookHeadingAutoSteerMinSpeed { get; set; }

		[FieldOffset(32, 40)]
		public float FreeLookHeadingAutoSteerMaxSpeed { get; set; }

		[FieldOffset(36, 44)]
		public float FreeLookHeadingAutoSteerFactor { get; set; }

		[FieldOffset(40, 48)]
		public float FreeLookHeadingDeltaSlop { get; set; }

		[FieldOffset(44, 52)]
		public float FreeLookHeadingDeltaSlopTime { get; set; }

		[FieldOffset(48, 56)]
		public bool FreeLookHeadingAnchorRelative { get; set; }
	}
}
