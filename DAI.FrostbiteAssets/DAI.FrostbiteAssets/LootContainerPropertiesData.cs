namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootContainerPropertiesData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<LootContainerData> LootContainerData { get; set; }
	}
}
