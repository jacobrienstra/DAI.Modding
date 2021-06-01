namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpawnDirectionData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float DirectionFromEmitterOrigin { get; set; }

		[FieldOffset(20, 68)]
		public float InheritSpeedAmount { get; set; }

		[FieldOffset(24, 72)]
		public float InheritSpeedSmoothingFactor { get; set; }

		[FieldOffset(28, 76)]
		public float InheritSpeedRandomness { get; set; }

		[FieldOffset(32, 80)]
		public bool InheritSpeedAndDirectionFromEmitter { get; set; }
	}
}
