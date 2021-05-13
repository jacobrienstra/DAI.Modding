namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWPartyExtraSpawnData : ExtraSpawnData
	{
		[FieldOffset(8, 24)]
		public int PartyMemberID { get; set; }
	}
}
