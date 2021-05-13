namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PartyMemberData : DataContainer
	{
		[FieldOffset(8, 24)]
		public bool ConsiderForAnyPartyMember { get; set; }
	}
}
