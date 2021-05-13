namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PartyMemberComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<PartyMemberData> PartyMember { get; set; }
	}
}
