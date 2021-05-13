namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MovementBehaviorFollowLeader : MovementBehavior
	{
		[FieldOffset(24, 40)]
		public float StopThreshold { get; set; }

		[FieldOffset(28, 44)]
		public float SustainSpeedThreshold { get; set; }

		[FieldOffset(32, 48)]
		public float ArcSpread { get; set; }
	}
}
