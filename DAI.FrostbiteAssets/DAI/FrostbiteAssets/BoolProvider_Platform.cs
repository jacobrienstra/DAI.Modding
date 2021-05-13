namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_Platform : BoolProvider
	{
		[FieldOffset(8, 32)]
		public PlatformScalableBool Platforms { get; set; }
	}
}
