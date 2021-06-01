namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<LootConfiguration> LootConfiguration { get; set; }
	}
}
