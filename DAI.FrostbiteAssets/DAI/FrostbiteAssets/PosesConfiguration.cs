namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PosesConfiguration : SystemSettings
	{
		[FieldOffset(16, 40)]
		public ExternalObject<PosesGlobalAsset> PosesGlobalAsset { get; set; }
	}
}
