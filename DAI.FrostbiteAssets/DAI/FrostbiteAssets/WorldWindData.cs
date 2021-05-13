namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WorldWindData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float WindMultiplier { get; set; }

		[FieldOffset(20, 68)]
		public float PerParticleRandomness { get; set; }
	}
}
