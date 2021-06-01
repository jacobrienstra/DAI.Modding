namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MorphTexturesBundleData : LinkObject
	{
		[FieldOffset(0, 0)]
		public BlueprintBundleReference TextureBundle { get; set; }

		[FieldOffset(28, 88)]
		public uint TextureHash { get; set; }
	}
}
