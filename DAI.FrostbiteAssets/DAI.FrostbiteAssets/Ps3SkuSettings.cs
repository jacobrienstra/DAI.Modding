namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Ps3SkuSettings : LinkObject
	{
		[FieldOffset(0, 0)]
		public string TitleId { get; set; }

		[FieldOffset(4, 8)]
		public string SpId { get; set; }

		[FieldOffset(8, 16)]
		public Ps3ServiceId TicketingServiceId { get; set; }

		[FieldOffset(16, 32)]
		public bool GrantsOnlinePass { get; set; }
	}
}
