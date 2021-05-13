namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MovementBehaviorRandom : MovementBehavior
	{
		[FieldOffset(24, 40)]
		public float Radius { get; set; }
	}
}
