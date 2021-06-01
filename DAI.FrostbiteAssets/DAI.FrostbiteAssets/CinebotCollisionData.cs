using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotCollisionData : DataContainer
	{
		[FieldOffset(8, 24)]
		public CameraCollisionTestType CollisionTestType { get; set; }

		[FieldOffset(12, 28)]
		public CinebotSprungArmData CollisionArm { get; set; }

		[FieldOffset(60, 76)]
		public float PillDistanceToTarget { get; set; }

		[FieldOffset(64, 80)]
		public float PillMinimumCollisionRadius { get; set; }

		[FieldOffset(68, 84)]
		public float PillMaximumCollisionRadius { get; set; }

		[FieldOffset(72, 88)]
		public float PillMinimumCollisionLength { get; set; }

		[FieldOffset(76, 92)]
		public float PillLengthToRadiusRatio { get; set; }

		[FieldOffset(80, 96)]
		public float PillMaximumExpandSpeed { get; set; }

		[FieldOffset(84, 100)]
		public float PillMaximumShrinkSpeed { get; set; }

		[FieldOffset(88, 104)]
		public float AccelerationLength { get; set; }

		[FieldOffset(92, 108)]
		public float SpeedScaleAtLow { get; set; }

		[FieldOffset(96, 112)]
		public float SpeedScaleAtHigh { get; set; }

		[FieldOffset(100, 116)]
		public float OuterCapsuleSize { get; set; }

		[FieldOffset(104, 120)]
		public float YThreshold { get; set; }

		[FieldOffset(108, 124)]
		public int YawControl { get; set; }

		[FieldOffset(112, 128)]
		public float YawSpeed { get; set; }

		[FieldOffset(116, 132)]
		public float YawDeadZone { get; set; }

		[FieldOffset(120, 136)]
		public int PitchControl { get; set; }

		[FieldOffset(124, 140)]
		public float PitchSpeed { get; set; }

		[FieldOffset(128, 144)]
		public float PitchDeadZone { get; set; }

		[FieldOffset(132, 148)]
		public bool TestCollisionWithAnchor { get; set; }

		[FieldOffset(133, 149)]
		public bool FixRadius { get; set; }

		[FieldOffset(134, 150)]
		public bool AddSpeedScaler { get; set; }

		[FieldOffset(135, 151)]
		public bool AutoWrapAroundObstacles { get; set; }
	}
}
