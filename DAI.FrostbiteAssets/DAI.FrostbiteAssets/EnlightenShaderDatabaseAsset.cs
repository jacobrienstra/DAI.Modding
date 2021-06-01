namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class EnlightenShaderDatabaseAsset : Asset
	{
		[FieldOffset(12, 72)]
		public uint NumShaders { get; set; }

		[FieldOffset(16, 80)]
		public long DatabaseResource { get; set; }
	}
}
