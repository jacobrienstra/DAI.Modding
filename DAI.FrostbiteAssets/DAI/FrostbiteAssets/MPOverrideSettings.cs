namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPOverrideSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public ExternalObject<MPOverrideTable> BakedOverridesAsset { get; set; }
	}
}
