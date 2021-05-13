namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FreeLookLerpData : LinkObject
	{
		[FieldOffset(0, 0)]
		public int LerpControl { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<Dummy> LerpControlRaw { get; set; }

		[FieldOffset(8, 16)]
		public float LerpDeadZone { get; set; }

		[FieldOffset(12, 20)]
		public float LerpFallOff { get; set; }

		[FieldOffset(16, 24)]
		public float LerpRecenterFallOff { get; set; }

		[FieldOffset(20, 28)]
		public float LerpCenterPosition { get; set; }

		[FieldOffset(24, 32)]
		public float FreeLookLerpAcceleration { get; set; }

		[FieldOffset(28, 36)]
		public float FreeLookLerpDeceleration { get; set; }

		[FieldOffset(32, 40)]
		public float FreeLookLerpMaxSpeed { get; set; }

		[FieldOffset(36, 44)]
		public float FreeLookLerpResetAcceleration { get; set; }

		[FieldOffset(40, 48)]
		public float FreeLookLerpResetMaxSpeed { get; set; }

		[FieldOffset(44, 52)]
		public bool OverrideCenterPosition { get; set; }
	}
}
