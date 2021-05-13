namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPServerMappingDetailedItemType : MPServerMappingBase
	{
		[FieldOffset(12, 48)]
		public ExternalObject<EquipItemType> itemTypeAsset { get; set; }
	}
}
