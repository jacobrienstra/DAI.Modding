namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ThirdPersonGameCameraControllerEnemyTypeBoomOffset
	{
		[FieldOffset(0, 0)]
		public Vec3 BoomOffset { get; set; }

		[FieldOffset(16, 16)]
		public int EnemyType { get; set; }

		[FieldOffset(20, 20)]
		public float MaximumEnemyDistance { get; set; }

		[FieldOffset(24, 24)]
		public float HighBoomLengthOffset { get; set; }

		[FieldOffset(28, 28)]
		public float LowBoomLengthOffset { get; set; }

		[FieldOffset(32, 32)]
		public bool UseDefaultBoomLengthOffset { get; set; }
	}
}
