namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWPartyMemberBlueprintCollectionEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<CharacterBlueprintBundleCollection> Collection { get; set; }
	}
}
