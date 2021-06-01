namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PresenceCharGenBosServiceData : PresenceServiceData
	{
		[FieldOffset(12, 72)]
		public string ConfigurationUrl { get; set; }

		[FieldOffset(16, 80)]
		public string SlotsDocUrl { get; set; }

		[FieldOffset(20, 88)]
		public string ActiceSlotDocUrl { get; set; }

		[FieldOffset(24, 96)]
		public string DocUrl { get; set; }

		[FieldOffset(28, 104)]
		public string ImageUrl { get; set; }
	}
}
