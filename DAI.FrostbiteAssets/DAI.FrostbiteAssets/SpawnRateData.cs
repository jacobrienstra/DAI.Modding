namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpawnRateData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float SpawnRate { get; set; }

		[FieldOffset(20, 68)]
		public bool DistributeOverTime { get; set; }

		[FieldOffset(21, 69)]
		public bool DistributeOverDistance { get; set; }
	}
}
