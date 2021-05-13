namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StatReferenceConfigurationEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<StatReferenceConfiguration> Configuration { get; set; }
	}
}
