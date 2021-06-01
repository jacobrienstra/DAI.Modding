namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameProjectileHomingSteeringData : GameProjectileVelocityMoverModifierData
	{
		[FieldOffset(12, 32)]
		public float MinSecondsBeforeHoming { get; set; }

		[FieldOffset(16, 36)]
		public float MaxSecondsBeforeHoming { get; set; }

		[FieldOffset(20, 40)]
		public float HomingDegreesTurnedPerSecond { get; set; }

		[FieldOffset(24, 44)]
		public float HomingStrengthRampUpDistance { get; set; }

		[FieldOffset(28, 48)]
		public float HomingStrengthMaxOutDistance { get; set; }

		[FieldOffset(32, 52)]
		public float HomingStrengthRampUpTime { get; set; }

		[FieldOffset(36, 56)]
		public float MaxHomingAngle { get; set; }

		[FieldOffset(40, 60)]
		public float CurveTension { get; set; }

		[FieldOffset(44, 64)]
		public ExternalObject<GameProjectileTargetSelectionData> TargetSelectionData { get; set; }

		[FieldOffset(48, 72)]
		public bool LateralHomingOnly { get; set; }
	}
}
