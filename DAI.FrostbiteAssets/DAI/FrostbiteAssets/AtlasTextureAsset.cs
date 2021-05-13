namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class AtlasTextureAsset : Asset
	{
		[FieldOffset(12, 72)]
		public int AnimationColumnCount { get; set; }

		[FieldOffset(16, 80)]
		public long Resource { get; set; }

		[FieldOffset(24, 88)]
		public int AnimationFrameCount { get; set; }
	}
}
