namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LootContainerEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public ExternalObject<LootContainerData> DefaultProperties { get; set; }
	}
}
