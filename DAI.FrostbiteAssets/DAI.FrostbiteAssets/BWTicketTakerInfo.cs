namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTicketTakerInfo
	{
		[FieldOffset(0, 0)]
		public int Cost { get; set; }

		[FieldOffset(4, 4)]
		public int Priority { get; set; }
	}
}
