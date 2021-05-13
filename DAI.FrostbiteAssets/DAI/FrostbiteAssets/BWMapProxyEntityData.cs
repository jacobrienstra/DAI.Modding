namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMapProxyEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int RegionStringID { get; set; }
	}
}
