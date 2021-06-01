namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WorldForcesData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float ForcesMultiplier { get; set; }

		[FieldOffset(20, 68)]
		public float PerParticleRandomness { get; set; }
	}
}
