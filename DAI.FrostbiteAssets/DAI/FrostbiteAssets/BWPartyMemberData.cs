namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWPartyMemberData : Asset
	{
		[FieldOffset(12, 72)]
		public int PartyMemberID { get; set; }

		[FieldOffset(16, 76)]
		public bool InitiallyAvailable { get; set; }
	}
}
