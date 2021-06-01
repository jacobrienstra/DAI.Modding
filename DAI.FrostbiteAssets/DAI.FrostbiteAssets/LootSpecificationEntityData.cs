namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootSpecificationEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<LootData> Loot { get; set; }
	}
}
