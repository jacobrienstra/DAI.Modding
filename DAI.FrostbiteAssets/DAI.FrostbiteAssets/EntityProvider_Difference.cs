namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntityProvider_Difference : EntityListProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<PartyMembersEntityList> EntityListA { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<EntityProvider_Self> EntityListB { get; set; }
	}
}
