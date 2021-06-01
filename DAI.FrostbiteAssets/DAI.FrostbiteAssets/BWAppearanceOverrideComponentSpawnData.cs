namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAppearanceOverrideComponentSpawnData : DataContainer
	{
		[FieldOffset(8, 24)]
		public int HeadOverrideId { get; set; }

		[FieldOffset(12, 32)]
		public MorphTargetBundleReference MorphTargetBundleRef { get; set; }

		[FieldOffset(16, 40)]
		public MorphTexturesBundleReference MorphTexturesBundleRef { get; set; }
	}
}
