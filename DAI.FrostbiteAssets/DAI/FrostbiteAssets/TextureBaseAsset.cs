namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class TextureBaseAsset : Asset
	{
		[FieldOffset(16, 72)]
		public long Resource { get; set; }
	}
}
