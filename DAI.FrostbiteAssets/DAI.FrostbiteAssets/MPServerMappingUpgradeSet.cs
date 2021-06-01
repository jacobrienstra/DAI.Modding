namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPServerMappingUpgradeSet : MPServerMappingBase
	{
		[FieldOffset(12, 48)]
		public ExternalObject<UpgradeSet> GameUpgradeSet { get; set; }
	}
}
