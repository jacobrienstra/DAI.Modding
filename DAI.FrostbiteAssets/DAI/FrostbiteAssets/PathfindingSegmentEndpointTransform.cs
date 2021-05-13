namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PathfindingSegmentEndpointTransform : CSMTransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider> GoalPosition { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<FloatProvider> CorridorRadius { get; set; }
	}
}
