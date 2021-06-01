namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWTargetPrioritizationComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<TargetPrioritizationProfile> Profile { get; set; }
	}
}
