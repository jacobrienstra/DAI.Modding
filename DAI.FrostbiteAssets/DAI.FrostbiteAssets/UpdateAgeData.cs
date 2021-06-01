namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpdateAgeData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float Lifetime { get; set; }

		[FieldOffset(20, 68)]
		public float RandomLifetimeScale { get; set; }

		[FieldOffset(24, 72)]
		public float MaxFactor { get; set; }
	}
}
