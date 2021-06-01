namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PathfindingPositionTransform : CSMTransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<CSMTransformProvider> Transform { get; set; }

		[FieldOffset(12, 40)]
		public bool GetPhysicsPosition { get; set; }
	}
}
