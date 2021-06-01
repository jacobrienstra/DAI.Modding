namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SetTacticsUIDataEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<UIPartyMemberDataAsset> PartyMembers { get; set; }
	}
}
