namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ClosestPathfindingPositionTransform : CSMTransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider> Transform { get; set; }

		[FieldOffset(12, 40)]
		public float DistanceAllowed { get; set; }

		[FieldOffset(16, 44)]
		public bool GetPhysicsPosition { get; set; }
	}
}
