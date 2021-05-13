namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWAppearanceOverrideComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public int HeadOverrideId { get; set; }

		[FieldOffset(100, 184)]
		public MorphTargetBundleReference MorphTargetBundleRef { get; set; }

		[FieldOffset(104, 192)]
		public MorphTexturesBundleReference TexturesBundleRef { get; set; }
	}
}
