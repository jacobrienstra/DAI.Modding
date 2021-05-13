namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SetPartyPickerUIDataEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<UIPartyMemberDataAsset> PartyMembers { get; set; }
	}
}
