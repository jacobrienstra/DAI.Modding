namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LocalForceData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public Vec3 LocalForce { get; set; }

		[FieldOffset(32, 80)]
		public float PerParticleRandomness { get; set; }

		[FieldOffset(36, 84)]
		public bool EmitterLocalSpaceForce { get; set; }
	}
}
