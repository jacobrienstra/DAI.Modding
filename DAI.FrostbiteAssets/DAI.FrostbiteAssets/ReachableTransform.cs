namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ReachableTransform : CSMTransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider> Transform { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<TransformProvider> ReachableToTransform { get; set; }

		[FieldOffset(16, 48)]
		public float MaximumDistance { get; set; }

		[FieldOffset(20, 52)]
		public float DistanceTolerance { get; set; }

		[FieldOffset(24, 56)]
		public bool ShouldTestWithinTetherRange { get; set; }
	}
}
