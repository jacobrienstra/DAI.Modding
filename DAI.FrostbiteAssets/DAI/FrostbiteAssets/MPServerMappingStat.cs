namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPServerMappingStat : MPServerMappingBase
	{
		[FieldOffset(12, 48)]
		public ExternalObject<BWIntegralStat> Stat { get; set; }
	}
}
