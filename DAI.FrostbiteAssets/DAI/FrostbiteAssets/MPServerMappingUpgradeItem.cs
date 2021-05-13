namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPServerMappingUpgradeItem : MPServerMappingBase
	{
		[FieldOffset(12, 48)]
		public ExternalObject<UpgradeItemType> GameUpgradeItem { get; set; }
	}
}
