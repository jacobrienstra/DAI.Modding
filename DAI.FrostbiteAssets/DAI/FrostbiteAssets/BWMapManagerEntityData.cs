namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMapManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<BWMapConfigurationAsset> Configuration { get; set; }
	}
}
