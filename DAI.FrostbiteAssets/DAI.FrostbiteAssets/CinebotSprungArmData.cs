namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotSprungArmData
	{
		[FieldOffset(0, 0)]
		public float Minimum { get; set; }

		[FieldOffset(4, 4)]
		public float Maximum { get; set; }

		[FieldOffset(8, 8)]
		public float SoftZone { get; set; }

		[FieldOffset(12, 12)]
		public float HardZone { get; set; }

		[FieldOffset(16, 16)]
		public float PushSpring { get; set; }

		[FieldOffset(20, 20)]
		public float PushDamper { get; set; }

		[FieldOffset(24, 24)]
		public float PushTimer { get; set; }

		[FieldOffset(28, 28)]
		public float ReturnSpring { get; set; }

		[FieldOffset(32, 32)]
		public float ReturnDamper { get; set; }

		[FieldOffset(36, 36)]
		public float ReturnTimer { get; set; }

		[FieldOffset(40, 40)]
		public float Velocity { get; set; }

		[FieldOffset(44, 44)]
		public bool DA3Control { get; set; }
	}
}
