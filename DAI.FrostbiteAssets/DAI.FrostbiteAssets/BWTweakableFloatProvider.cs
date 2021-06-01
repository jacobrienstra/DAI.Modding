namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTweakableFloatProvider : CSMFloatProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<FloatProvider> DefaultProvider { get; set; }

		[FieldOffset(12, 40)]
		public bool AllowOverride { get; set; }
	}
}
