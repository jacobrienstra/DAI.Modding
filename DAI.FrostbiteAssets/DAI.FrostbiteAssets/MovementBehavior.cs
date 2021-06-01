namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MovementBehavior : DataContainer
	{
		[FieldOffset(8, 24)]
		public int BehaviorIdentifier { get; set; }

		[FieldOffset(12, 28)]
		public MoverTuneId BaseMoverTuneId { get; set; }

		[FieldOffset(16, 32)]
		public float BaseMoveSpeedMultiplier { get; set; }

		[FieldOffset(20, 36)]
		public bool Breakout { get; set; }
	}
}
