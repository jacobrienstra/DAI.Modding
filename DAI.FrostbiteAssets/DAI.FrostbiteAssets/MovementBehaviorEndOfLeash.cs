namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MovementBehaviorEndOfLeash : MovementBehavior
	{
		[FieldOffset(24, 40)]
		public float StopThreshold { get; set; }

		[FieldOffset(28, 48)]
		public ExternalObject<TransformProvider_Facing> OrientTransform { get; set; }
	}
}
