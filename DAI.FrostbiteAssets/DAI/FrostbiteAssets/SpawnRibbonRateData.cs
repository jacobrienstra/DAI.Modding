namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpawnRibbonRateData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float SpawnRate { get; set; }

		[FieldOffset(20, 68)]
		public float AngleDeviation { get; set; }

		[FieldOffset(24, 72)]
		public bool DistributeOverDistance { get; set; }
	}
}
