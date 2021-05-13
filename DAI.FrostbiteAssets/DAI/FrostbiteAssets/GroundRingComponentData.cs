namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class GroundRingComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<GroundRingConfigurationAsset> Configuration { get; set; }

		[FieldOffset(100, 184)]
		public bool ShowGroundRing { get; set; }
	}
}
