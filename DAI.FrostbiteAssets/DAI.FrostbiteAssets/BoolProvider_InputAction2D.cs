namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_InputAction2D : BoolProvider
	{
		[FieldOffset(8, 32)]
		public int ActionXAxis { get; set; }

		[FieldOffset(12, 36)]
		public int ActionYAxis { get; set; }

		[FieldOffset(16, 40)]
		public float MinValue { get; set; }

		[FieldOffset(20, 44)]
		public float MaxValue { get; set; }

		[FieldOffset(24, 48)]
		public float TargetAngle { get; set; }

		[FieldOffset(28, 52)]
		public float HalfAngleTolerance { get; set; }
	}
}
