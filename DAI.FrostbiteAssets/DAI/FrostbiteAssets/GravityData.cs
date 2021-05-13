namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GravityData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float Gravity { get; set; }

		[FieldOffset(20, 68)]
		public float PerParticleRandomness { get; set; }
	}
}
