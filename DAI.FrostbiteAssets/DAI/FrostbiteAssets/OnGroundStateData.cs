namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OnGroundStateData : CharacterStateData
	{
		[FieldOffset(12, 32)]
		public float JumpDelay { get; set; }

		[FieldOffset(16, 36)]
		public float JumpStaminaPenalty { get; set; }

		[FieldOffset(20, 40)]
		public float AllowedDistanceFromGround { get; set; }

		[FieldOffset(24, 44)]
		public float UphillSpeedModifier { get; set; }

		[FieldOffset(28, 48)]
		public float UphillSpeedModifierMaxAngle { get; set; }

		[FieldOffset(32, 52)]
		public float DownhillSpeedModifier { get; set; }

		[FieldOffset(36, 56)]
		public float DownhillSpeedModifierMaxAngle { get; set; }

		[FieldOffset(40, 60)]
		public float HillSpeedModifierDeadZone { get; set; }

		[FieldOffset(44, 64)]
		public bool GroundHugging { get; set; }

		[FieldOffset(45, 65)]
		public bool LimitDownwardVelocity { get; set; }
	}
}
