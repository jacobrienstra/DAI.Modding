namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class HdrSetting : DataContainer
	{
		[FieldOffset(8, 24)]
		public float WindowMinTop { get; set; }

		[FieldOffset(12, 28)]
		public float WindowMinBottom { get; set; }

		[FieldOffset(16, 32)]
		public float WindowTopMinReleaseTime { get; set; }

		[FieldOffset(20, 36)]
		public float WindowTopMaxReleaseTime { get; set; }

		[FieldOffset(24, 40)]
		public float WindowTopAttackTime { get; set; }

		[FieldOffset(28, 44)]
		public float WindowBottomReleaseTime { get; set; }

		[FieldOffset(32, 48)]
		public AudioCurve WindowTopReleaseTimeCurve { get; set; }

		[FieldOffset(40, 64)]
		public float DischargeFactor { get; set; }

		[FieldOffset(44, 68)]
		public float MaxAllowedEnergy { get; set; }

		[FieldOffset(48, 72)]
		public float WindowBottomAttackTime { get; set; }

		[FieldOffset(52, 76)]
		public float WindowSize { get; set; }

		[FieldOffset(56, 80)]
		public float CompressFactor { get; set; }

		[FieldOffset(60, 84)]
		public float Headroom { get; set; }

		[FieldOffset(64, 88)]
		public float AllowedOvershoot { get; set; }
	}
}
