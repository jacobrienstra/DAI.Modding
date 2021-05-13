namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWDepletableStat : BWStat
	{
		[FieldOffset(44, 152)]
		public ExternalObject<BWModifiableStat> RegenerationRate { get; set; }

		[FieldOffset(48, 160)]
		public ExternalObject<BWStat> MaxStat { get; set; }

		[FieldOffset(52, 168)]
		public bool RegenRateIsPercentageOfMaxValue { get; set; }

		[FieldOffset(53, 169)]
		public bool RegenerateWhenDead { get; set; }

		[FieldOffset(54, 170)]
		public bool InitializeToMaximumValue { get; set; }

		[FieldOffset(55, 171)]
		public bool IncreaseOnMaxValIncrease { get; set; }
	}
}
