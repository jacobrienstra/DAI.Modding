namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RuntimeRegion
	{
		[FieldOffset(0, 0)]
		public int IncreaseAmount { get; set; }

		[FieldOffset(4, 4)]
		public int MaxPopulation { get; set; }

		[FieldOffset(8, 8)]
		public int MinPopulation { get; set; }

		[FieldOffset(12, 12)]
		public int PopulationChangeDelay { get; set; }

		[FieldOffset(16, 16)]
		public float ProbabilityOfIncrease { get; set; }

		[FieldOffset(20, 20)]
		public float StartingPopulationFraction { get; set; }

		[FieldOffset(24, 24)]
		public int EnabledPropertyHash { get; set; }

		[FieldOffset(28, 28)]
		public int RegionLinkHash { get; set; }

		[FieldOffset(32, 32)]
		public bool AllowManualDecrement { get; set; }

		[FieldOffset(33, 33)]
		public bool AllowAutoDecrement { get; set; }
	}
}
